using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Space_Runner
{
    public partial class GameScreen : UserControl
    {
        /// <summary>
        /// INSTRUCTIONS
        /// Controls:
        /// k - Accelerate
        /// s - shoot blast
        /// 
        /// Goal - Avoid asteroids to survive and get as much score as possible
        /// The Red bar is the health bar 
        /// 
        /// </summary>
        
        ///TO DO LIST:
        ///5. Fix the asteroid spawning so that the asteroids per round = the round count
        ///6. MAKE SURE TO CHECK REQUIREMENTS BEFORE RESUMBMITTING
        #region Global Variables
        public static int score = 0;

        SoundPlayer blasterSound = new SoundPlayer(Properties.Resources.blasterSound); //Set sound player

        #region New Round Varibles
        bool newRound = false; //Check if it is time to start the next round
        int roundCount = 0;
        int prevRound = 0;
        #endregion

        #region Cursor Variables
        Point cursorPosition;

        float cursorPositionY;
        float cursorPositionX;

        #endregion

        #region RotationCode
        double rotationAngle;
        int dx;
        int dy;
        #endregion

        #region Asteroid Variables
        Asteroids asteroid;
        List<Asteroids> asteroidList = new List<Asteroids>();
        public List<Image> asteroidImgList = new List<Image>();
        Random asteroidRand = new Random();
        int asteroidsOnScreen = 0;
        #endregion

        #region Form Variables
        public static int width, height;

        #endregion

        #region HyperSpaceAnimationVariables
        List<HyperSpaceAnimation> rectangleList = new List<HyperSpaceAnimation>();
        Random animationRandom = new Random();
        public static int animationCountDown = 90;
        #endregion

        #region StarShip Variables
        Starship starship;

        public List<Image> starShipImageList = new List<Image>();
        public List<Image> starShipExplosionImageList = new List<Image>();

        //Blaster Variables
        List<blaster> blasterList = new List<blaster>();
        int blasterCooldown = 10;
        int accelerationCooldown = 250;

        #endregion

        #region Game Controls Variables
        public bool leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;
        public bool kKeyDown, sKeyDown;

        #endregion

        #region Pens and Brushes
        Pen yellowPen = new Pen(Color.Yellow, 3);
        Pen redPen = new Pen(Color.Red); //Health
        Pen bluePen = new Pen(Color.Blue); //Fuel
        Pen purplePen = new Pen(Color.Purple); //Ammo

        Brush redBrush = new SolidBrush(Color.Red); //Health
        Brush blueBrush = new SolidBrush(Color.Blue); //Health
        Brush purpleBrush = new SolidBrush(Color.Purple); //Ammo

        //Background Colours
        Brush blackBrush = new SolidBrush(Color.Black);
        Pen blackPen = new Pen(Color.Black);

        Brush backBrush = new SolidBrush(Color.Black);
        Pen backPen = new Pen(Color.Black);

        #endregion

        #region Stats Variables
        Rectangle healthBar;
        Rectangle fuelBar;
        Rectangle ammoBar;

        int healthBarWidth = 125;
        int fuelBarWidth = 125;
        int ammoBarWidth = 125;
        #endregion

        #endregion

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            gameTimer.Enabled = true;
            this.MouseMove += GameScreen_MouseMove; // Subscribe to the MouseMove event

            width = this.Width;
            height = this.Height;

            #region Starship initialization
            starship = new Starship(100, 100);

            //Add base star ship images
            starShipImageList.Add(Properties.Resources.baseStarShip1);
            starShipImageList.Add(Properties.Resources.StarShipMovImage);
            starShipImageList.Add(Properties.Resources.StarShipDamage);

            asteroidImgList.Add(Properties.Resources.asteroid);

            //Add explosion of star ship
            starShipExplosionImageList.Add(Properties.Resources.sExplosion);
            starShipExplosionImageList.Add(Properties.Resources.sExplosion2);
            starShipExplosionImageList.Add(Properties.Resources.sExplosion3);
            starShipExplosionImageList.Add(Properties.Resources.sExplosion4);
            starShipExplosionImageList.Add(Properties.Resources.sExplosion5);
            starShipExplosionImageList.Add(Properties.Resources.sExplosion6);
            starShipExplosionImageList.Add(Properties.Resources.sExplosion7);
            #endregion

            #region intialize game variables
            score = 0;

            #endregion

            #region Set Stat Bars
            ammoBar = new Rectangle(width - 170, height - 30, healthBarWidth, 25);
            fuelBar = new Rectangle(width - 390, height - 30, fuelBarWidth, 25);
            healthBar = new Rectangle(width - 600, height - 30, ammoBarWidth, 25);

            healthBarWidth = 125;
            fuelBarWidth = 125;
            ammoBarWidth = 125;
            #endregion
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region Update Game Variables
            score++;
            blasterCooldown--; //Reset Blaster cooldown
            accelerationCooldown--; //Reset acceleration cooldown

            scoreLabel.Text = score.ToString();
            #endregion

            #region Cursor Position
            Point cursorPosition = Cursor.Position;

            //Subtracting values from coordinates to get centered cursor coords
            cursorPositionX = Cursor.Position.X - 315;
            cursorPositionY = Cursor.Position.Y - 170;

            Cursor.Hide();

            #endregion

            if (roundCount != prevRound)
            {
                prevRound = roundCount;
                GenerateAsteroids();
                asteroidsOnScreen++;
            }

            #region Round Control
            //Setting up new round
            if (asteroidsOnScreen == 0)
            {
                roundCount += 1;
            }
            #endregion

            for (int i =0; i < asteroidList.Count; i++)
            {
                asteroidList[i].Move();
                if (asteroidList[i].x < -30)
                {
                    asteroidList.Remove(asteroidList[i]);
                    asteroidsOnScreen--;
                    i--;
                }
            }
            
            if (asteroidsOnScreen == 0)
            {
                for (int i = 0; i < roundCount*2; i++)
                {
                    GenerateAsteroids();
                    asteroidsOnScreen++;
                }
            }
            for (int i = 0; i < blasterList.Count; i++)
            {
                for (int j = 0; j < asteroidList.Count; j++)
                {
                    if (i < blasterList.Count) //If there is something to search for then find it (to make sure it isn't searching null)
                    {
                        if (blasterList[i].Collision(asteroidList[j]))
                        {
                            asteroidList.Remove(asteroidList[j]);
                            asteroidsOnScreen--;
                            blasterList.Remove(blasterList[i]);
                        }
                    }
                }
            }

            foreach (Asteroids ast in asteroidList)
            {
                if (starship.Collision(ast))
                {
                    StatBarOperations("Subtract Health", 30);
                    asteroidList.Remove(ast);
                    asteroidsOnScreen--;
                    break;
                }

            }

            #region Check for Loss
            if (healthBar.Width < 0)
            {
                gameTimer.Enabled = false;
                Form1.ChangeScreen(this, new GameOverScreen());
            }
            #endregion

            #region Starship Control
            if (downArrowDown)
            {
                starship.Move(2);
            }
            if (upArrowDown)
            {
                starship.Move(1);
            }
            if (rightArrowDown)
            {
                starship.Move(4);
            }
            if (leftArrowDown)
            {
                starship.Move(3);
            }
            if (accelerationCooldown < 0)
            {
                if (kKeyDown) // This control is for accelertation and it will speed the starship up temporarily
                {
                    starship.Xspeed += (int)1;
                    starship.Yspeed += (int)1;
                    StatBarOperations("Subtract Fuel", 20);
                    fuelBar.Width = fuelBarWidth;

                    if (starship.Yspeed == 9)
                    {
                        starship.Yspeed = 9;
                    }
                    if (starship.Xspeed == 9)
                    {
                        starship.Xspeed = 9;
                    }
                }
            }
            if (kKeyDown == false) //Slow down to constant speed if you aren't actively accelerating
            {
                if (starship.Xspeed > 9 || starship.Yspeed > 9)
                {
                    starship.Yspeed--;
                    starship.Xspeed--;
                }
            }
            
            if (blasterCooldown < 0 && ammoBarWidth > 0)
            {
                if (sKeyDown == true)
                {
                    blaster blaster = new blaster(starship.x, starship.y);
                    blasterList.Add(blaster);
                    blasterSound.Play();
                    StatBarOperations("Subtract Ammo", 20);
                    blasterCooldown = 10;
                }
            }
            #endregion

            #region Drag
            //Drags the player down if they aren't actively going upwards
            if (upArrowDown == false)
            {
                starship.dragDownEffect();

            }
            #endregion

            #region Blaster Code
            foreach (blaster b in blasterList)
            {
                b.Move();
            }
            #endregion

            #region HyperSpaceAnimation
            foreach (HyperSpaceAnimation r in rectangleList)
            {
                r.Move();
                if (r.x < 800 || r.x < -10)
                {
                    r.rectangleList.Remove(r);
                }
                if (r.y < 800 || r.y < 0)
                {
                    r.rectangleList.Remove(r);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                GenerateHyperspace();
            }
            #endregion

            Refresh();
        }
        private void GenerateHyperspace()
        {
            #region Hyperspace Animation
            float x = 1001;
            float y = animationRandom.Next(-100, height);
            float speed = animationRandom.Next(1, 10);

            Pen hyperPen = new Pen(Color.FromArgb(255, 255, 255, 255));
            Brush hyperBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

            HyperSpaceAnimation newRect = new HyperSpaceAnimation(x, y, 100, speed);
            rectangleList.Add(newRect);
            #endregion
        }

        private void GenerateAsteroids()
        {
            #region Create Asteroids
            int x = width + 20;
            int y = asteroidRand.Next(0, height);
            int size = asteroidRand.Next(8, 60);
            int speed = asteroidRand.Next(4, 10);

            Asteroids asteroid = new Asteroids(x, y, size, speed);
            asteroidList.Add(asteroid);
            #endregion
        }
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            #region Key Press Tracking
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.K:
                    kKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
            }
            #endregion
        }

        private void GameScreen_MouseMove(object sender, MouseEventArgs e)
        {
            #region Rotation Code
            //// Calculate the angle between the center of the rectangle and the cursor position

            //double yVal = (e.Y - starship.y + starship.sHeight / 2);
            //double xVal = (e.X - starship.x + starship.sWidth / 2);

            //dx = e.Y - starship.y;
            //dy = e.X - starship.x;

            //rotationAngle = (double)Math.Atan2(yVal, xVal) * (180 / Math.PI);

            // Redraw the form (same as a refresh but looks cooler)
            this.Invalidate();
            #endregion
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            #region Key Press Tracking
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.K:
                    kKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
            }
            #endregion
        }

        private void StatBarOperations(string Command, int amount)
        {
            #region Subtract stats from Stat Bars
            if (Command == "Subtract Health")
            {
                if (amount > 0)
                {
                    healthBarWidth -= amount;
                    healthBar.Width = healthBarWidth;
                }
            }

            if (Command == "Subract Fuel")
            {
                if (amount > 0)
                {
                    fuelBarWidth -= amount;
                    fuelBar.Width = fuelBarWidth;
                }
            }

            if (Command == "Subtract Ammo")
            {
                if (amount > 0)
                {
                    ammoBarWidth -= amount;
                    ammoBar.Width = ammoBarWidth;
                }
            }
            #endregion
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            #region HyperSpaceAnimation
            foreach (HyperSpaceAnimation r in rectangleList)
            {
                e.Graphics.DrawPolygon(r.hyperPen, r.RectanglePoints);
                e.Graphics.FillPolygon(r.hyperBrush, r.RectanglePoints);
            }
            #endregion

            #region Asteroids
            foreach (Asteroids asteroid in asteroidList)
            {
                //e.Graphics.FillEllipse(redBrush, asteroid.x, asteroid.y, asteroid.size, asteroid.size);
                e.Graphics.DrawImage(asteroidImgList[0], asteroid.x, asteroid.y, asteroid.size, asteroid.size);
            }
            #endregion

            #region Cursor Paint
            e.Graphics.DrawEllipse(bluePen, cursorPositionX, cursorPositionY, 15, 15);
            #endregion

            #region Stat Bar Painting
            //Draw Health, Fuel, Ammo Bar
            e.Graphics.DrawRectangle(yellowPen, width - 170, height - 30, 125, 25);
            e.Graphics.DrawRectangle(yellowPen, width - 390, height - 30, 125, 25);
            e.Graphics.DrawRectangle(yellowPen, width - 600, height - 30, 125, 25);

            //Health
            e.Graphics.DrawRectangle(redPen, healthBar);
            e.Graphics.FillRectangle(redBrush, healthBar);
            //Fuel
            e.Graphics.DrawRectangle(bluePen, fuelBar);
            e.Graphics.FillRectangle(blueBrush, fuelBar);
            //Ammo
            e.Graphics.DrawRectangle(purplePen, ammoBar);
            e.Graphics.FillRectangle(purpleBrush, ammoBar);
            #endregion

            #region Blaster Painting
            foreach (blaster blaster in blasterList)
            {
                e.Graphics.FillRectangle(redBrush, blaster.x, blaster.y, blaster.width, blaster.height);
            }
            #endregion

            #region Starship Painting
            // Translate and rotate the graphics object
            e.Graphics.TranslateTransform(starship.x, starship.y);

            e.Graphics.RotateTransform((float)rotationAngle);
            // Draw the rotated rectangle

            //e.Graphics.FillRectangle(blackBrush, 0 - starship.sWidth / 2, 0 - starship.sHeight / 2, starship.sWidth, starship.sHeight);
            if (starship.movingForward == false)
            {
                e.Graphics.DrawImage(starShipImageList[0], 0 - starship.sWidth / 2, 0 - starship.sHeight / 2, starship.sWidth, starship.sHeight);
            }
            else
            {
                e.Graphics.DrawImage(starShipImageList[1], 0 - starship.sWidth / 2, 0 - starship.sHeight / 2, starship.sWidth, starship.sHeight);
            }

            // Reset transformations
            e.Graphics.ResetTransform();
            #endregion
        }
    }
}