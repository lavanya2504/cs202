// Program.cs
using System;
using AlarmConsoleApp;
using Timer = System.Timers.Timer; // ← pick System.Timers.Timer explicitly

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
            _timer = new Timer(1000);         // fire every 1000ms
            _timer.Elapsed += CheckTime;
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();

        private void CheckTime(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var now = DateTime.Now.ToString("HH:mm:ss");
            //Console.WriteLine($"[Debug] Current time: {now}");

            if (now == _targetTime)
            {
                _timer.Stop();

                // only invoke if someone subscribed
                AlarmRaised?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}


// 2) Subscriber & entry point
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter alarm time in HH:MM:SS format:");
        string? input = Console.ReadLine();

        // Validate we actually got something
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("No valid time entered. Exiting.");
            return;
        }

        string userTime = input.Trim();

        // Validate time format
        if (!DateTime.TryParseExact(userTime, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out _))
        {
            Console.WriteLine("Invalid time format. Please use HH:MM:SS (e.g., 14:30:00). Exiting.");
            return;
        }

        var publisher = new AlarmPublisher(userTime);

        // Subscribe with a matching signature
        publisher.AlarmRaised += Ring_alarm;

        Console.WriteLine($"Alarm set for {userTime}. Waiting...");
        publisher.Start();

        // Keep the app alive until the user hits Enter
        Console.ReadLine();
    }


    // note: sender is allowed to be null, so we use object?
    static void Ring_alarm(object? sender, EventArgs e)
    {
        Console.Beep();
        Console.WriteLine("⏰ Alarm! The specified time has been reached.");
    }
}
