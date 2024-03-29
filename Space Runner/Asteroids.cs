using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Runner
{
    internal class Asteroids
    {
        public int x, y, size, Xspeed, Yspeed;
        public Random randomCurve = new Random();

        public Asteroids(int x, int y, int size, int Xspeed)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.Xspeed = Xspeed;
            AsteroidCurve();
        }

        public void Move()
        {
            SpeedLimit();

            x -= Xspeed;
            y -= Yspeed;

            if(y < GameScreen.height && y > GameScreen.height - 70)
            {
                Yspeed++;
            }
            if (y > 0 && y < 70)
            {
                Yspeed--;
            }
        }
        private void AsteroidCurve()
        {
            int direction = randomCurve.Next(1, 3);

            if (direction == 1) 
            {
                //Moving the asteroid down
                Yspeed = randomCurve.Next(1, 5);
            }
            if (direction == 2)
            {
                //Moving the asteroid up
                Yspeed = randomCurve.Next(-5, -1);
            }
        }
        private void SpeedLimit()
        {
            int speedLimit = 10;

            if (Math.Abs(Yspeed) > speedLimit)
            {
                if (Yspeed > 0)
                {
                    Yspeed = 5;
                }
                if(Yspeed < 0)
                {
                    Yspeed = -5;
                }
            }
            if (Math.Abs(Xspeed) > speedLimit)
            {
                if (Xspeed > 0)
                {
                    Xspeed = 5;
                }
                if (Xspeed < 0)
                {
                    Xspeed = -5;
                }
            }
        }
        
    }
}
