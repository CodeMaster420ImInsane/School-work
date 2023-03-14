using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GenerateStarsDraw
{
    public partial class Form1 : Form
    {
        public Random rng = new Random();
        SolidBrush[] colourOptions = new SolidBrush[] { new SolidBrush(Color.White), new SolidBrush(Color.WhiteSmoke), new SolidBrush(Color.FloralWhite), new SolidBrush(Color.AliceBlue), new SolidBrush(Color.LightYellow)};
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var assign = Convert.ToInt16(textBox1.Text);
            }
            catch
            {
                textBox1.Text = String.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics generateStar = Graphics.FromHwnd(this.Handle);
            for (int i=0; i<int.Parse(textBox1.Text); i++)
            {
                int size = rng.Next(1, 12);
                Point p = new Point();
                p.X = rng.Next(0, this.Width);
                p.Y = rng.Next(0, this.Height);
                int radius = size % 2 == 0 ? size / 2 : (size - 1) / 2;
                Rectangle star = new Rectangle(p.X, p.Y, size, size);
                int rand = rng.Next(0, 4);
                double glowRadiusPercentage = 0.35;
                int glowRadius = (int)(radius * glowRadiusPercentage);
                if (rand == 0)
                {
                    Color c = Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256), rng.Next(256));
                    Color glareColor = Color.FromArgb(100, c);
                    Color glowColor = Color.FromArgb(50, c);
                    SolidBrush glowBrush = new SolidBrush(glowColor);
                    Rectangle circleBounds = new Rectangle(star.X, star.Y, size, size);
                    Rectangle glowBounds = new Rectangle(star.X - glowRadius, star.Y - glowRadius, size + glowRadius * 2, size + glowRadius * 2);
                    GraphicsPath circlePath = new GraphicsPath();
                    circlePath.AddEllipse(star);
                    PathGradientBrush pgb = new PathGradientBrush(circlePath);
                    pgb.CenterPoint = new PointF(star.X + star.Width / 2, star.Y + star.Height / 2);
                    pgb.CenterColor = c;
                    Color[] surroundColors = new Color[7];
                    for (int j = 0; j < 7; j++)
                    {
                        int alpha = (int)((1 - (j / 6.0)) * 100);
                        surroundColors[j] = Color.FromArgb(alpha, glareColor);
                    }
                    surroundColors[6] = Color.Transparent;
                    pgb.SurroundColors = surroundColors;
                    generateStar.FillEllipse(new SolidBrush(c), star);
                    generateStar.FillEllipse(glowBrush, glowBounds);
                    generateStar.FillEllipse(glowBrush, circleBounds);
                }
                else
                {
                    SolidBrush brush = colourOptions[rng.Next(0, colourOptions.Length)];
                    Color glareColor = Color.FromArgb(100, brush.Color);
                    Rectangle circleBounds = new Rectangle(star.X, star.Y, size, size);
                    Rectangle glowBounds = new Rectangle(star.X - glowRadius, star.Y - glowRadius, size + glowRadius * 2, size + glowRadius * 2);
                    GraphicsPath circlePath = new GraphicsPath();
                    circlePath.AddEllipse(star);
                    PathGradientBrush pgb = new PathGradientBrush(circlePath);
                    pgb.CenterPoint = new PointF(star.X + star.Width / 2, star.Y + star.Height / 2);
                    pgb.CenterColor = brush.Color;
                    Color[] surroundColors = new Color[7];
                    for (int j = 0; j < 7; j++)
                    {
                        int alpha = (int)((1 - (j / 6.0)) * 100);
                        surroundColors[j] = Color.FromArgb(alpha, glareColor);
                    }
                    surroundColors[6] = Color.Transparent;
                    pgb.SurroundColors = surroundColors;
                    Color glowColor = Color.FromArgb(50, brush.Color);
                    SolidBrush glowBrush = new SolidBrush(glowColor);
                    generateStar.FillEllipse(new SolidBrush(brush.Color), star);
                    generateStar.FillEllipse(glowBrush, glowBounds);
                    generateStar.FillEllipse(glowBrush, circleBounds);

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            button1.Text = "Generate stars";
            button2.Text = "Clear stars";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics clearStars = Graphics.FromHwnd(this.Handle);
            clearStars.Clear(Color.Black);
        }
    }
}