using System.Diagnostics.Metrics;

namespace Password_gen
{
    public partial class Form1 : Form
    {
        Random rng = new Random();
        String[] sertfg = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " ", "!", "?", "#", "$", "%", "&", "'", "(", ")", "*", "+", "-", ".", "/", ":", ";", "<", ">", "=", "@", "[", "]", "^", "{", "}", "|", "~" };
        public Form1()
        {
            InitializeComponent();
            this.BringToFront();
            this.Focus();
            this.KeyPreview = true;
            button1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Click";
            label1.Text = "Password =: ";
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.BackColor = Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256));
            var s = "";
            int length = rng.Next(8, 25);
            for (int i=0; i<length; i++)
            {
                s += sertfg[rng.Next(0, 90)];
            }
            int x = rng.Next(0, 816);
            int y = rng.Next(0, 489);
            button1.Location = new Point(x, y);

            label1.Text = s;
            label2.Text += $"\n{s}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}