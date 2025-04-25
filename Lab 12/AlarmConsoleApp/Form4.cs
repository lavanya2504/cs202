using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlarmConsoleApp
{
    public partial class Form4 : Form
    {
        private string _targetTime;
        private readonly Color[] _colors =
            { Color.LightCoral, Color.LightGreen, Color.LightBlue, Color.LightGoldenrodYellow };
        private int _colorIndex = 0;

        // Declare the alarm event
        public event EventHandler AlarmReached;

        public Form4()
        {
            InitializeComponent();

            // Wire up our custom event to the handler
            AlarmReached += OnAlarmReached;

            // Configure the WinForms timer
            timer1.Interval = 1000;           // 1 second
            timer1.Tick += Timer1_Tick;

            // Button click to start
            button1.Click += button1_Click;

            // Handle form load and resize
            this.Load += Form4_Load;
            this.Resize += Form4_Resize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _targetTime = textBox1.Text.Trim();

            if (!IsValidTime(_targetTime))
            {
                MessageBox.Show("⛔ Please enter time in correct format: HH:mm:ss (e.g., 14:30:00)",
                                "Invalid Time Format",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            timer1.Start();
            button1.Enabled = false;
            textBox1.Enabled = false;
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            // 1) Change background color
            this.BackColor = _colors[_colorIndex % _colors.Length];
            _colorIndex++;

            // 2) Check for alarm time
            string now = DateTime.Now.ToString("HH:mm:ss");
            if (now == _targetTime)
            {
                timer1.Stop();
                AlarmReached?.Invoke(this, EventArgs.Empty);
            }
        }

        // Subscriber method: show a MessageBox
        private void OnAlarmReached(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();
            MessageBox.Show($"⏰ It's now {_targetTime}!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button1.Enabled = true;
            textBox1.Enabled = true;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }
        private bool IsValidTime(string input)
        {
            return TimeSpan.TryParse(input, out _);
        }

        private void CenterControls()
        {
            int spacing1 = 10; // space between label and textbox
            int spacing2 = 10; // space between textbox and button
            int totalWidth = label1.Width + spacing1 + textBox1.Width + spacing2 + button1.Width;

            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int yPos = 32;

            label1.Location = new Point(startX, yPos);
            textBox1.Location = new Point(label1.Right + spacing1, yPos);
            button1.Location = new Point(textBox1.Right + spacing2, yPos);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
