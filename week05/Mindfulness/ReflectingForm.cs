using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MindfulnessApp
{
    public partial class ReflectingForm : Form
    {
        private ReflectingActivityLogic _logic;
        private int _remainingSeconds;
        private int _questionInterval = 5; // seconds per question
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times?",
            "What could you learn from this experience?",
            "What did you learn about yourself?",
            "How can you keep this experience in mind in the future?"
        };

        private Random _rand = new Random();

        public ReflectingForm()
        {
            InitializeComponent();
            numericDuration.Value = 30;
            lblPrompt.Text = "Set duration and press Start.";
            timerQuestion.Interval = 1000;
            timerQuestion.Tick += TimerQuestion_Tick;
        }

        private bool _isRunning = false;
        private int _questionTickCounter = 0;

        private void btnStart_Click(object sender, EventArgs e)
        {
            int duration = (int)numericDuration.Value;
            _logic = new ReflectingActivityLogic(duration);
            _remainingSeconds = duration;
            _isRunning = true;
            _questionTickCounter = 0;
            btnStart.Enabled = false;
            numericDuration.Enabled = false;

            // show a random prompt first
            lblPrompt.Text = _prompts[_rand.Next(_prompts.Count)];
            lblQuestion.Text = "";
            prepareTimer.Interval = 1000;
            prepareTimer.Tick += PrepareTimer_Tick;
            prepareTicks = 3;
            prepareTimer.Start();
        }

        private int prepareTicks = 0;
        private void PrepareTimer_Tick(object sender, EventArgs e)
        {
            prepareTicks--;
            lblStatus.Text = $"Starting in {prepareTicks}...";
            if (prepareTicks <= 0)
            {
                prepareTimer.Stop();
                prepareTimer.Tick -= PrepareTimer_Tick;
                lblStatus.Text = "Reflect on the following question:";
                ShowRandomQuestion();
                timerQuestion.Start();
            }
        }

        private void TimerQuestion_Tick(object sender, EventArgs e)
        {
            if (!_isRunning) return;
            _questionTickCounter++;
            _remainingSeconds--;
            lblTimeLeft.Text = $"Time left: {_remainingSeconds}s";

            if (_questionTickCounter >= _questionInterval)
            {
                _questionTickCounter = 0;
                ShowRandomQuestion();
            }

            if (_remainingSeconds <= 0)
            {
                timerQuestion.Stop();
                _isRunning = false;
                CompleteActivity();
            }
        }

        private void ShowRandomQuestion()
        {
            var q = _questions[_rand.Next(_questions.Count)];
            lblQuestion.Text = q;
        }

        private void CompleteActivity()
        {
            lblStatus.Text = "Well done! Activity complete.";
            _logic.CompleteAndLog();
            btnStart.Enabled = true;
            numericDuration.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class ReflectingActivityLogic : Activity
    {
        public ReflectingActivityLogic(int durationSeconds)
            : base("Reflecting", "Guided reflection to recall moments of strength.")
        {
            DurationSeconds = durationSeconds;
        }
    }
}
