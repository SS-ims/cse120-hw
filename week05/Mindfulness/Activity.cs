using System;
using System.IO;

namespace MindfulnessApp
{
    // Base class representing shared activity properties/behaviors
    public abstract class Activity
    {
        private string _name;
        private string _description;
        private int _durationSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string Name => _name;
        public string Description => _description;

        // Duration exposes only getter/setter for derived forms/logic
        public int DurationSeconds
        {
            get => _durationSeconds;
            set
            {
                _durationSeconds = Math.Max(1, value); // minimum 1 second
            }
        }

        // Log completed session to file
        protected void LogSession()
        {
            string file = "activity_log.txt";
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss},{_name},{_durationSeconds}";
            try
            {
                File.AppendAllText(file, line + Environment.NewLine);
            }
            catch
            {
                // ignore simple IO errors for classroom app
            }
        }

        // Call when activity completes
        public void CompleteAndLog()
        {
            LogSession();
        }
    }
}
