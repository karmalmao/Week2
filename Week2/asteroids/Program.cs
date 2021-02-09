using System;
using Raylib_cs;
using System.Numerics;

namespace asteroids
{
    class Program
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "shooty ship game";

        Player player;
        Asteroid asteroid;
        bullet[] bullets = new bullet[100];
        Asteroid[] asteroids = new Asteroid[100];

        float asteroidSpawnCooldown = 4.0f;
        float asteroidSpawnCooldownReset = 4.0f;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunGame();
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
            Raylib.SetTargetFPS(0);

            LoadGame();

            while (!Raylib.WindowShouldClose())
            {
                Update();
                Draw();

            }
        }

        void DoBulletAsteroidCollision(bullet bullet, Asteroid asteroid)
        {
            if (bullet == null || asteroid == null)
                return;

            float distance = (bullet.pos - asteroid.pos).Length();
            if (distance < asteroid.radius)
            {

                SpawnAsteroid(asteroid.pos, asteroid.dir, asteroid.radius/2);
                SpawnAsteroid(asteroid.pos, -asteroid.dir, asteroid.radius/2);
                for (int i = 0; i < bullets.Length; i++)
                {
                    if(bullets[i] == bullet)
                    {
                        bullets[i] = null;
                        break;
                    }
                }
                for (int i = 0; i < asteroids.Length; i++)
                {
                    if (asteroids[i] == asteroid)
                    {
                        asteroids[i] = null;
                        break;
                    }
                }
            }
        }

        void Update()
        {
            Raylib.DrawFPS(700, 20);

            asteroidSpawnCooldown -= Raylib.GetFrameTime();
            if (asteroidSpawnCooldown < 0.0f)
            {
                // true loop insta spawn asteroids
                asteroidSpawnCooldown = asteroidSpawnCooldownReset;
                SpawnNewAsteroid();
            }



            player.Update();
            for (int i = 0; i <bullets.Length; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Update();
                }
            }
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] != null)
                {
                    asteroids[i].Update();
                }
            }

            foreach (var bullet in bullets)
            {
                foreach (var asteroid in asteroids)
                {
                    DoBulletAsteroidCollision(bullet, asteroid);
                }
            }




        }

       

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DARKGRAY);

            player.Draw();
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Draw();
                }
            }
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] != null)
                {
                    asteroids[i].Draw();
                }
            }

            Raylib.EndDrawing();
        }
        void LoadGame()
        {
            Assets.LoadAssets();

            player = new Player(
                this,
                new Vector2(windowWidth / 2, windowHeight / 2),
                new Vector2(64, 64));
            //initialise things
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = null;
            }
        }
       


        public void SpawnBullet(Vector2 pos, Vector2 dir)
        {
            bullet bullet = new bullet(this, pos, dir);
            for (int i = 0; i < bullets.Length; i++)
            {
                if(bullets[i] == null)
                {
                    bullets[i] = bullet;
                    break;
                }
            }
        }
        public void SpawnAsteroid(Vector2 pos, Vector2 dir, float radius)
        {
            Asteroid asteroid = new Asteroid(this, pos, dir) ;
            asteroid.radius = radius;

            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] == null)
                {
                    asteroids[i] = asteroid;
                    break;
                }
            }
        }
        public void SpawnNewAsteroid()
          {
            Random rand = new Random();
            int side = rand.Next(0, 4);


            float rot = (float)rand.NextDouble() * MathF.PI * 2.0f;
            Vector2 dir = new Vector2(MathF.Cos(rot), MathF.Sin(rot));

            float radius = 40f;
            
            
            //left
            if (side == 0) SpawnAsteroid(new Vector2(0, rand.Next(0, windowHeight)), dir, radius);
            //top
            if (side == 1) SpawnAsteroid(new Vector2(rand.Next(0, windowWidth), 0), dir, radius);
            //right
            if (side == 2) SpawnAsteroid(new Vector2(windowWidth, rand.Next(0, windowHeight)), dir, radius);
            //bottom
            if (side == 3) SpawnAsteroid(new Vector2(rand.Next(0, windowWidth), windowHeight), dir, radius);


        }




    }

}
