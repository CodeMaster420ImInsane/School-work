using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Diagnostics;
using System.Security.Cryptography;

namespace GenerateStarsDraw
{
    public partial class Form1 : Form
    {
        SoundPlayer barIncrease = new SoundPlayer("ShepardF.wav");
        SoundPlayer stoopid = new SoundPlayer("ustoopid.wav");
        public Random rng = new Random();
        SolidBrush[] colourOptions = new SolidBrush[] { new SolidBrush(Color.White), new SolidBrush(Color.WhiteSmoke), new SolidBrush(Color.FloralWhite), new SolidBrush(Color.AliceBlue), new SolidBrush(Color.LightYellow)};
        public bool continueGeneratingCircles = true;
        public Task circleGenerationTask;
        public Form1()
        {
            InitializeComponent();
            label1.Hide();
            this.TopMost = true;
            progressBar1.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var assign = Convert.ToInt16(textBox1.Text);
                progressBar1.Maximum = int.Parse(textBox1.Text);
            }
            catch
            {
                textBox1.Text = String.Empty;
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                 barIncrease.Stop();
            progressBar1.Invoke(new Action(() =>
            {
                progressBar1.Value = 0;
            }));
                progressBar1.Invoke(new Action(() =>
                {
                    progressBar1.Show();
                }));
                continueGeneratingCircles = true;
                Graphics generateStar = Graphics.FromHwnd(this.Handle);
                Task soundTask = Task.Run(() =>
                {
                    barIncrease.Play();
                });
                circleGenerationTask = Task.Run(() =>
                {
                
                    int i = 0;
                    while (i < int.Parse(textBox1.Text) && continueGeneratingCircles)
                    {
                        int size = rng.Next(1, 9);
                        Point p = new Point();
                        p.X = rng.Next(0, this.Width);
                        p.Y = rng.Next(0, this.Height);
                        int radius = size % 2 == 0 ? size / 2 : (size - 1) / 2;
                        Rectangle star = new Rectangle(p.X, p.Y, size, size);
                        int rand = rng.Next(0, 6);
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
                        i++;
                        progressBar1.Invoke(new Action(() =>
                        {
                            progressBar1.Value = i;
                        }));
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }
                    // end of star generation
                    progressBar1.Invoke(new Action(() =>
                    {
                        progressBar1.Hide();
                    }));
                    barIncrease.Stop();
                });
            await soundTask;
        }  
        }

        protected override async void OnFormClosing(FormClosingEventArgs e)
        {
            barIncrease.Stop();
            continueGeneratingCircles = false;
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    string videoUrl = "https://www.youtube.com/shorts/qqZosHdUUz0";
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = videoUrl,
                        UseShellExecute = true
                    });
                    int nsk = rng.Next(10, 20);
                    bool continueLoop = true;
                    int i = 0;
                    while (i < nsk && continueLoop)
                    {
                        if (nsk - i == 1)
                        {
                            switch (MessageBox.Show(this, "Are you *not* sure? ;)", "Never!", MessageBoxButtons.YesNo))
                            {
                                case DialogResult.Yes:
                                    Task sound2 = Task.Run(() =>
                                    {
                                        stoopid.Play();
                                    });
                                    if (i == 0) 
                                    {
                                        continueGeneratingCircles = false;
                                    }
                                    else
                                    {
                                        continueGeneratingCircles = true;
                                        e.Cancel = true;
                                    }
                                    break;
                                default:
                                    continueLoop = false;
                                    continueGeneratingCircles = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (MessageBox.Show(this, "Are you sure?", $"Please don't close ({nsk - i})", MessageBoxButtons.YesNo))
                            {
                                case DialogResult.No:
                                    continueLoop = false;
                                    continueGeneratingCircles = true;
                                    e.Cancel = true;
                                    break;
                                default:
                                    continueGeneratingCircles = false;
                                    break;
                            }
                        }
                        i++;
                    }
                    if (Task.CurrentId != null && !circleGenerationTask.IsCompleted)
                    {
                        Task.WaitAll(circleGenerationTask);
                    }
                        break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            button1.Text = "Generate stars";
            button2.Text = "Clear stars";
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead("ShepardF.wav"))
                {
                    Console.WriteLine("first hash:  " + md5.ComputeHash(stream));
                }
            }
        }

         private void button2_Click(object sender, EventArgs e)
        {
            barIncrease.Stop();
            continueGeneratingCircles = false;
            Graphics clearStars = Graphics.FromHwnd(this.Handle);
            clearStars.Clear(Color.Black);
            progressBar1.Invoke(new Action(() =>
            {
                progressBar1.Value = 0;
            }));
        }
    }
}