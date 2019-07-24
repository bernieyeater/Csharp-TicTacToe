using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_004
{
    public partial class Form1 : Form
    {
        //int SquareNo = 1; //For deciding what Square to put the "X" or "O"
        int UserTurn = 1;
        static public int TheWinner = 0;

        //Set the postions for the nine turns
        int[] Horz = new int[10]; //Holds the vertical position for drawing the matrix.
        int[] Vert = new int[10]; //Holds the horizonal postiion for drawing the matrix.
        static public int[] Player = new int[10]; //Keeps track of who is on the square

            public Form1()
        {
            InitializeComponent();
            this.Width = 500;
            this.Height = 450;
            label1.Text = " ";
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g;
            g = e.Graphics;
            Pen myPen = new Pen(Color.Black);
            myPen.Width = 5;
            g.DrawLine(myPen, 100, 100, 400, 100);
            g.DrawLine(myPen, 100, 200, 400, 200);
            g.DrawLine(myPen, 200, 25, 200, 300);
            g.DrawLine(myPen, 300, 25, 300, 300);

            for (int i = 1; i < 10; i++)
            {
                if (Horz[i] > 0)
                {
                    //Position the X or O
                    int x1 = Horz[i];
                    int y1 = Vert[i];
                    int x2 = Horz[i] + 50;
                    int y2 = Vert[i] + 50;
                    
                    if (Player[i] == 1)
                    {
                        //Draw an "X" at the right square
                        g.DrawLine(myPen, x1, y1, x2, y2);
                        g.DrawLine(myPen, x2, y1, x1, y2);
                    }
                    if (Player[i] == 2)
                    {
                        //Draw an "O" at the right square
                        Point point1 = new Point(x1, y1);
                        Point point2 = new Point(x2, y1);
                        Point point3 = new Point(x2, y2);
                        Point point4 = new Point(x1, y2);
                        Point point5 = new Point(x1, y1);
                        Point[] curvePoints = { point1, point2, point3, point4, point5 };
                        g.DrawCurve(myPen, curvePoints);
                    }
                }
            }
            //Win Logic for X
            if ((Player[1] == 1) && (Player[2] == 1) && (Player[3] == 1) && (TheWinner == 0)) { TheWinner = 1; }
            if ((Player[4] == 1) && (Player[5] == 1) && (Player[6] == 1) && (TheWinner == 0)) { TheWinner = 1; }
            if ((Player[7] == 1) && (Player[8] == 1) && (Player[9] == 1) && (TheWinner == 0)) { TheWinner = 1; }
            if ((Player[1] == 1) && (Player[4] == 1) && (Player[7] == 1) && (TheWinner == 0)) { TheWinner = 1; }
            if ((Player[2] == 1) && (Player[5] == 1) && (Player[8] == 1) && (TheWinner == 0)) { TheWinner = 1; }
            if ((Player[3] == 1) && (Player[6] == 1) && (Player[9] == 1) && (TheWinner == 0)) { TheWinner = 1; }
            if ((Player[1] == 1) && (Player[5] == 1) && (Player[9] == 1) && (TheWinner == 0)) { TheWinner = 1; }
            if ((Player[3] == 1) && (Player[5] == 1) && (Player[7] == 1) && (TheWinner == 0)) { TheWinner = 1; }
            //Win Logic for O
            if ((Player[1] == 2) && (Player[2] == 2) && (Player[3] == 2) && (TheWinner == 0)) { TheWinner = 2; }
            if ((Player[4] == 2) && (Player[5] == 2) && (Player[6] == 2) && (TheWinner == 0)) { TheWinner = 2; }
            if ((Player[7] == 2) && (Player[8] == 2) && (Player[9] == 2) && (TheWinner == 0)) { TheWinner = 2; }
            if ((Player[1] == 2) && (Player[4] == 2) && (Player[7] == 2) && (TheWinner == 0)) { TheWinner = 2; }
            if ((Player[2] == 2) && (Player[5] == 2) && (Player[8] == 2) && (TheWinner == 0)) { TheWinner = 2; }
            if ((Player[3] == 2) && (Player[6] == 2) && (Player[9] == 2) && (TheWinner == 0)) { TheWinner = 2; }
            if ((Player[1] == 2) && (Player[5] == 2) && (Player[9] == 2) && (TheWinner == 0)) { TheWinner = 2; }
            if ((Player[3] == 2) && (Player[5] == 2) && (Player[7] == 2) && (TheWinner == 0)) { TheWinner = 2; }

            if (TheWinner == 1) {label1.Text = "X Wins Game";}
            if (TheWinner == 2) {label1.Text = "O Wins Game";
            }
        }
        
        //These "buttons" are hidden by shorting the screen, but they are called from the panels.
        //After I got the buttons working, I substatuted a call from the panel.
        //By modifing the button code in Designer.cs

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            TakeTheSquare(1, 130, 30);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            TakeTheSquare(2, 230, 30);
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            TakeTheSquare(3, 330, 30);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            TakeTheSquare(4, 130, 130);
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            TakeTheSquare(5, 230, 130);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            TakeTheSquare(6, 330, 130);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            TakeTheSquare(7, 130, 230);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
            TakeTheSquare(8, 230, 230);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            TakeTheSquare(9, 330, 230);
            }

        private void TakeTheSquare(int square, int h, int v)
        {
            UserTurn = UserTurn + 1;
            if (Player[square] == 0)
            {
                if ((UserTurn % 2) != 0) { Player[square] = 1; } else { Player[square] = 2; }
            }
            Horz[square] = h;
            Vert[square] = v;
            this.Refresh();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            //New Game Button!
            Array.Clear(Horz, 0, 10);  //Reset the Horzonal drawing record.
            Array.Clear(Vert, 0, 10);  //Reset the Vertical drawing record
            Array.Clear(Player, 0, 10); //Reset who is on what square.
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = true;
            panel9.Visible = true;
            TheWinner = 0;
            label1.Text = " ";
            this.Refresh();
        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        { }
        private void panel2_Paint(object sender, PaintEventArgs e)
        { }
        private void panel1_Click(object sender, PaintEventArgs e)
        { }
        private void panel2_Click(object sender, PaintEventArgs e)
        { }
        private void panel1_Paint(object sender, PaintEventArgs e)
        { }
        private void Form1_Load(object sender, EventArgs e)
        {}

    }
}
