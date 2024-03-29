using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Runner
{
    internal class HyperSpaceAnimation
    {
        public Pen hyperPen;
        public Brush hyperBrush;

        public float x = 1001;
        public float y;
        public float speed = 5;

        public float size = 5;
        public float scale;
        public float scale2;

        public int animationCountdown = 80;

        
        public float length;
        public float width;

        public Random animationRandom = new Random();

        public List<HyperSpaceAnimation> rectangleList = new List<HyperSpaceAnimation>();

        public PointF[] RectanglePoints = new PointF[4];

        //Constructor Method
        public HyperSpaceAnimation(Pen _hyperPen, Brush _hyperBrush, float _x, float _y, float _length, float _width, float _speed)
        {
            hyperPen = _hyperPen;
            x = _x;
            y = _y;
            length = _length;
            width = _width;
            speed = _speed;
            hyperBrush = _hyperBrush;

            SetPoints();
        }

        public HyperSpaceAnimation(float _x, float _y, float _size, float _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;

            int val1 = animationRandom.Next(0, 255);
            val1++;
            int val2 = animationRandom.Next(0, 255);
            val2++;
            int val3 = animationRandom.Next(0, 255);
            val3++;
            int val4 = animationRandom.Next(0, 255);
            val4++;
            int val5 = animationRandom.Next(0, 255);
            val5++;
            int val6 = animationRandom.Next(0, 255);
            val6++;
            int val7 = animationRandom.Next(0, 255);
            val7++;
            int val8 = animationRandom.Next(0, 255);
            val8++;

            Color.FromArgb(val1, val2, val3, val4);
            hyperPen = new Pen(Color.FromArgb(val1, val2, val3, val4));
            hyperBrush = new SolidBrush(Color.FromArgb(val5, val6, val7, val8));


            SetPoints();
        }

        private void SetPoints()
        {
            scale = length / 206;
            scale2 = width / 206;

            RectanglePoints[0] = new PointF(100 * scale + x * speed, 300 * scale2 + y * speed);
            RectanglePoints[1] = new PointF(100 * scale + x * speed, 300 * scale2 + y * speed);
            RectanglePoints[2] = new PointF(500 * scale + x * speed, 100 * scale2 + y * speed);
            RectanglePoints[3] = new PointF(400 * scale + x * speed, 100 * scale2 + y * speed);

            RectanglePoints[0] = new PointF(250 * scale + x * speed, 250 * scale2 + y * speed);
            RectanglePoints[1] = new PointF(250 * scale + x * speed, 250 * scale2 + y * speed);
            RectanglePoints[2] = new PointF(250 * scale + x * speed, 250 * scale2 + y * speed);
            RectanglePoints[3] = new PointF(112 * scale + x * speed, 120 * scale2 + y * speed);

            //RectanglePoints[0] = new PointF(212 * scale + x * speed, 212 * scale2 + y * speed);
            //RectanglePoints[1] = new PointF(111 * scale + x * speed, 120 * scale2 + y * speed);
            //RectanglePoints[2] = new PointF(110 * scale + x * speed, 100 * scale2 + y * speed);
            //RectanglePoints[3] = new PointF(110 * scale + x * speed, 120 * scale2 + y * speed);

        }
        public void Move()
        {
            x -= 6;

            //Increase Rectangle Length as the rectangle crosses the screen to make animation clean
            length += 10;
            animationCountdown--;

            //This is code for a 3D effect

            if (animationCountdown <= 0)
            {
                length -= 10;
            }

            SetPoints();
        }
    }
}
