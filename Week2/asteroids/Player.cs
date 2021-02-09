using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace asteroids
{
    class Player
    {
        Program program;

        public Vector2 pos = new Vector2();
        public Vector2 size = new Vector2(64, 64);

        public float rotation = 0.0f;
        public float rotationSpeed = 7.5f;
        public float accSpeed = 0.1f;
        public Vector2 velocity = new Vector2();
        

        public Player(Program program, Vector2 pos, Vector2 size)
        {
            this.program = program;
            this.pos = pos;
            this.size = size;
        }
        public void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                program.SpawnBullet(pos, GetFacingDirection());
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) || Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                rotation -= rotationSpeed;
                rotation = rotation * Raylib.GetFrameTime();
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) || Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                rotation += rotationSpeed;
                rotation = rotation * Raylib.GetFrameTime();
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_R))
            {
                pos = new Vector2(program.windowWidth / 2,program.windowHeight / 2);
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                var dir = GetFacingDirection();
                velocity += dir * accSpeed * (Raylib.GetFrameTime() * 60);
            }
            pos += velocity * (Raylib.GetFrameTime() * 60);

            if (pos.X < 0) pos.X = program.windowWidth;
            if (pos.X > program.windowWidth) pos.X = 0;
            if (pos.Y < 0) pos.Y = program.windowHeight;
            if (pos.Y > program.windowHeight) pos.Y = 0;





        }

        public Vector2 GetFacingDirection()
        {
            return new Vector2(
                MathF.Cos((MathF.PI / 180) * rotation),
                MathF.Sin((MathF.PI / 180) * rotation));
        }



        public void Draw()
        {
            Texture2D texture = Assets.shipTexture;
            Raylib.DrawTexturePro(
                texture,
                new Rectangle(0, 0, texture.width, texture.height),
                new Rectangle(pos.X, pos.Y, size.X, size.Y),
                new Vector2(0.5f * size.X, 0.5f * size.Y),
                rotation,
                Color.WHITE);
        }
    }











}
