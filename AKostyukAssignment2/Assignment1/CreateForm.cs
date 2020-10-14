/* Assignment 2
 * 
 * Created by Anzhelika Kostyuk 
 * 
 * Date: Oct 2019
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class CreateForm : Form
    {
        //Declare variables
        
        public const int LEFT = 150;
        const int TOP = 150;
        const int WIDTH = 40;
        const int HEIGHT = 40;
        const int VGAP = 1;
        const int SGAP = 1;
        int row;
        int column;

        enum ImageType
        {
            ZERO,
            NONE,
            HERO,
            WALL,
            BOX,
            DESTINATION
        }
        ImageType imageType = ImageType.ZERO;
        PictureBox[,] pb;

        public CreateForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int rows;
            int columns;
            if (int.TryParse(txtRows.Text, out rows) && int.TryParse(txtColumns.Text, out columns))
            {
                row = rows;
                column = columns;
                pb = new PictureBox[rows, columns];
                int y = TOP;

                //Generate the grid
                for (int i = 0; i < rows; i++)
                {
                    int x = LEFT;
                    for (int z = 0; z < columns; z++)
                    {
                        //Create PictureBox
                        PictureBox p = new PictureBox();
                        p.Tag = 0;
                        p.Left = x;
                        p.Top = y;
                        p.Width = WIDTH;
                        p.Height = HEIGHT;
                        p.BorderStyle = BorderStyle.Fixed3D;
                        p.Click += PictureBoxClick;
                        p.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.Controls.Add(p);
                        pb[i, z] = p;

                        x += WIDTH + SGAP;
                    }
                    y += HEIGHT + VGAP;
                }

            }
            else
            {
                MessageBox.Show("Input must be numeric");
            }
        }

        private void PictureBoxClick(object sender, EventArgs e)
        {
            //Assign Image to the button
            PictureBox p = (PictureBox)sender;
            switch(imageType)
            {
                case ImageType.NONE:
                    p.Image = Assignment1.Properties.Resources.none;
                    p.Tag = 1;
                    break;
                case ImageType.HERO:
                    p.Image = Assignment1.Properties.Resources.hero;
                    p.Tag = 2;
                    break;
                case ImageType.WALL:
                    p.Image = Assignment1.Properties.Resources.block;
                    p.Tag = 3;
                    break;
                case ImageType.BOX:
                    p.Image = Assignment1.Properties.Resources.box;
                    p.Tag = 4;
                    break;
                case ImageType.DESTINATION:
                    p.Image = Assignment1.Properties.Resources.yblock;
                    p.Tag = 5;
                    break;
                default:
                    break;
            }
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            imageType = ImageType.NONE;
        }

        private void btnHero_Click(object sender, EventArgs e)
        {
            imageType = ImageType.HERO;
        }

        private void btnWall_Click(object sender, EventArgs e)
        {
            imageType = ImageType.WALL;
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            imageType = ImageType.BOX;
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            imageType = ImageType.DESTINATION;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exit and Close CreateForm
            this.Close();
            MainMenu f = new MainMenu();
            f.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Use StreamWriter to write in txt file and show the message
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.ShowDialog();
            StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile());

            sw.WriteLine(row);
            sw.WriteLine(column);
            using (sw)
            {               
                foreach (var item in pb)
                {
                    sw.WriteLine(item.Tag);
                }
            }
           
            MessageBox.Show("Level saved");
        }
    }
}
