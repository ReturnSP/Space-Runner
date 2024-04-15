using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Space_Runner
{
    internal class blaster
    {
        public int x, y;
        public int blasterXspeed = 9;
        public int width = 15;
        public int height = 3;
        public blaster(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Move()
        {
            x += blasterXspeed;
        }

        public bool Collision(Asteroids ast)
        {
            Rectangle blasterRec = new Rectangle(x, y, width, height);
            Rectangle asteroidRec = new Rectangle(ast.x, ast.y, ast.size, ast.size);

            if (blasterRec.IntersectsWith(asteroidRec))
            {
                return true;
            }
            return false;
        }
    }
}
