using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafe_chess1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Queen";
            Form1.my_button1[Form1.postion].BackgroundImage = button1.BackgroundImage;
            chessGame.indxed[Form1.postion] = 1;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Rook";
            Form1.my_button1[Form1.postion].BackgroundImage = button2.BackgroundImage;
            chessGame.indxed[Form1.postion] = 1;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Bishop";
            Form1.my_button1[Form1.postion].BackgroundImage = button3.BackgroundImage;
            chessGame.indxed[Form1.postion] = 1;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Knight";
            Form1.my_button1[Form1.postion].BackgroundImage = button4.BackgroundImage;
            chessGame.indxed[Form1.postion] = 1;
            Close();
        }
    }
}
