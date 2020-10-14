using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateForm f = new CreateForm();
            f.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlayForm f = new PlayForm();
            f.Show();
        }
    }
}
