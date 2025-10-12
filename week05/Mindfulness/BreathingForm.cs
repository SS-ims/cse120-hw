using System;
using System.Windows.Forms;

namespace MindfulnessApp
{
    // A form implementing breathing activity UI and logic
    public partial class BreathingForm : Form
    {
        private BreathingActivityLogic _logic;
        private int _remainingSeconds;
        private bool _isBreathingIn = true;
        private int _phaseSeconds = 4; // seconds per in/out phase
        private int _phaseRemaining;

        public BreathingForm()
        {
            InitializeComponent();
            numericDuration.Value = 30;
            lblStatus.Text = "Set duration and press Start.";
            timerTick.Interval = 1000;
            timerTick.Tick += TimerTick_Tick;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int duration = (int)numericDuration.Value;
            _logic = new BreathingActivityLogic(duration);
            _remainingSeconds = duration;
            _phaseRemaining = _phaseSeconds;
            _isBreathingIn = true;
            btnStart.Enabled = false;
            numericDuration.Enabled = false;
            lblStatus.Text = "Get ready...";
            // small prepare pause using a short timer
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
                lblStatus.Text = "Breathe in...";
                UpdatePhaseLabel();
                timerTick.Start();
            }
        }

        private void TimerTick_Tick(object sender, EventArgs e)
        {
            if (_remainingSeconds <= 0)
            {
                timerTick.Stop();
                CompleteActivity();
                return;
            }

            _phaseRemaining--;
            _remainingSeconds--;

            lblTimeLeft.Text = $"Time left: {_remainingSeconds}s";
            lblPhase.Text = _isBreathingIn ? "Breathe in..." : "Breathe out...";
            lblPhaseCountdown.Text = $"{_phaseRemaining}s";

            if (_phaseRemaining <= 0)
            {
                // switch phase
                _isBreathingIn = !_isBreathingIn;
                _phaseRemaining = _phaseSeconds;
            }
        }

        private void UpdatePhaseLabel()
        {
            lblPhase.Text = _isBreathingIn ? "Breathe in..." : "Breathe out...";
            lblPhaseCountdown.Text = $"{_phaseRemaining}s";
        }

        private void CompleteActivity()
        {
            lblStatus.Text = "Well done! Activity complete.";
            // log via logic class which inherits Activity
            _logic.CompleteAndLog();
            btnStart.Enabled = true;
            numericDuration.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Logic class inheriting Activity (separates logic from form)
    public class BreathingActivityLogic : Activity
    {
        public BreathingActivityLogic(int durationSeconds)
            : base("Breathing", "This activity guides breathing in and out slowly.")
        {
            DurationSeconds = durationSeconds;
        }
    }
}
