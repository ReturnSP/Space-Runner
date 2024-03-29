using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Runner
{
    internal class Starship
    {
        //Constructor variables
        public int x, y;

        //Starship dimensions
        public int sWidth = 70;
        public int sHeight = 40;
        
        //Starship speeds
        public float Xspeed = 6;
        public float Yspeed = 7;

        public bool movingForward = false;


        public Starship(int x, int y) 
        {
            this.x = x;
            this.y = y;

        }

        public bool Collision(Asteroids ast)
        {
            Rectangle starshipRect = new Rectangle(x, y, sWidth, sHeight);
            Rectangle asteroidRect = new Rectangle(ast.x, ast.y, ast.size, ast.size);

            if (starshipRect.IntersectsWith(asteroidRect))
            {
                return true;
            }

            return false;
        }

        public void dragDownEffect()
        {
            //Drag Starship down if you aren't going upwards
            y += 2;
            if (y > GameScreen.height - sHeight  -40)
            {
                y = GameScreen.height - sHeight - 40;
            }
        }

        public void Move(int Mode)
        {
            #region Movement Control
            //Up Movement
            if (Mode == 1)
            {
                y -= (int)Yspeed;

                if (y < 0)
                {
                    y = 0;
                }
            }
            //Down Movement
            if (Mode == 2)
            {
                y += (int)Yspeed;

                if (y > GameScreen.height - sHeight)
                {
                    y = GameScreen.height - sHeight;
                }
            }
            //Left Movement
            if (Mode == 3)
            {
                // Increase speed value when going backwards for forward flying effect
                x -= (int)Xspeed*2;

                if (x < 0)
                {
                    x = 0;
                }
            }
            //Right Movement
            if (Mode == 4)
            {
                // Decreace speed value when going forwards for forward flying effect
                x += (int)Xspeed/2;
                movingForward = true;

                if (x > GameScreen.width - sWidth)
                {
                    x = GameScreen.width - sWidth;
                }
            }
            else
            {
                movingForward = false;
            }
            #endregion
        }
    }
}
