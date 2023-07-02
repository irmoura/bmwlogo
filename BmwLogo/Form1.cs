using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BmwLogo
{
    public partial class Form1 : Form
    {

        private Graphics graphics = null;
        private int centralHorizontalLine;
        private int centralVerticalLine;
        Color blue = Color.FromArgb(0, 154, 218);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            centralHorizontalLine = (this.Width / 2);
            centralVerticalLine = (this.Height / 2);
            //
            graphics = this.CreateGraphics();
            //
            //DrawHorizontalLine(Color.Red, 0, this.Width, centralVerticalLine);//X
            //DrawVerticalLine(Color.Red, centralHorizontalLine, 0, this.Height);//Y
            //
            FillCircle(this.Width / 2, this.Height / 2, 560, Color.White);
            FillCircle(this.Width / 2, this.Height / 2, 545, Color.Black);
            FillCircle(this.Width / 2, this.Height / 2, 340, Color.White);
            FillPie(this.Width / 2, this.Height / 2, 320, blue, 0, 90);
            FillPie(this.Width / 2, this.Height / 2, 320, blue, -180, 90);
            //
            DrawLetter(centralHorizontalLine - 250, centralVerticalLine - 130, -54, "B");
            DrawLetter(centralHorizontalLine - 62, centralVerticalLine - 277, 0, "M");
            DrawLetter(centralHorizontalLine + 176, centralVerticalLine - 227, 52, "W");
        }

        private void DrawHorizontalLine(Color color, int x1, int x2, int y, int size = 1)
        {
            graphics.DrawLine(new Pen(new SolidBrush(color), size), x1, y, x2, y);
        }

        private void DrawVerticalLine(Color color, int x, int y1, int y2, int size = 1)
        {
            graphics.DrawLine(new Pen(new SolidBrush(color), size), x, y1, x, y2);
        }

        private void FillCircle(int x, int y, int size, Color color)
        {
            Rectangle rectangle = new Rectangle((x - (size / 2)), y - (size / 2), size, size);
            graphics.FillEllipse(new SolidBrush(color), rectangle);
        }

        private void FillPie(int x, int y, int size, Color color, float startAngle, float sweepAngle)
        {
            Rectangle rectangle = new Rectangle((x - (size / 2)), y - (size / 2), size, size);
            graphics.FillPie(new SolidBrush(color), rectangle, startAngle, sweepAngle);
        }

        private void DrawLetter(int x, int y, int angle, string letter)
        {
            Font font = new Font("Helvetica", 80, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.White);

            // Converte o ângulo de graus para radianos
            double angleRad = angle * Math.PI / 180;

            // Define a matriz de transformação para a rotação
            Matrix transform = new Matrix();
            transform.RotateAt((float)angle, new PointF(x, y));

            // Aplica a transformação à matriz de gráficos
            graphics.Transform = transform;

            // Desenha a letra na posição atual (após a transformação)
            graphics.DrawString(letter, font, brush, x, y);
        }
    }
}
