using System;
using System.Collections.Generic;
using System.Text;

namespace raylib_test_rn
{
    class GameSettings
    {
        public int windowWidth;
        public int windowHeight;
        public string windowTitle;

        public GameSettings(int width, int height, string title)
        {
            windowHeight = height;
            windowWidth = width;
            windowTitle = title;
        }
    }
}
