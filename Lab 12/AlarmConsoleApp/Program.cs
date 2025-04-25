// Program.cs
using System;
using Timer = System.Timers.Timer;   // ← pick System.Timers.Timer explicitly

namespace AlarmConsoleApp
{
    // 1) Publisher class
    class AlarmPublisher
    {
        // make the event nullable so the compiler is happy
        public event EventHandler? AlarmRaised;

        private readonly string _targetTime;
        private readonly Timer _timer;

        public AlarmPublisher(string targetTime)
        {
            _targetTime = targetTime;
            _timer = new Timer(1000);           // fire every 1000ms
            _timer.Elapsed += CheckTime;
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();

        private void CheckTime(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var now = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"[Debug] Current time: {now}");
            if (now == _targetTime)
            {
                _timer.Stop();
                // only invoke if someone subscribed
                AlarmRaised?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    // 2) Subscriber & entry point
    class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form4());
        }

        // note: sender is allowed to be null, so we use object?
        static void Ring_alarm(object? sender, EventArgs e)
        {
            Console.Beep();
            Console.WriteLine("⏰ Alarm! The specified time has been reached.");
        }
    }
}
