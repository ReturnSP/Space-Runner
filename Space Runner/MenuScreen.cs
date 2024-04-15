using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Runner
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            Cursor.Current = Cursors.Cross;
            InitializeComponent();
            Cursor.Current = Cursors.Cross;
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
