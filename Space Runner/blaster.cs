using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Runner
{
    internal class blaster
    {
        public int blasterXspeed, blasterYspeed, x, y;

        public blaster(int x, int y, int blasterXspeed, int blasterYspeed)
        {
            this.x = x;
            this.y = y;
            this.blasterXspeed = blasterXspeed;
            this.blasterYspeed = blasterYspeed;
        }

        public void Move()
        {
            x += blasterXspeed;
            y += blasterYspeed;
        }
    }
}
