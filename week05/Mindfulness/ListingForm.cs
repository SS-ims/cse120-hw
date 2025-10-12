using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MindfulnessApp
{
    public partial class ListingForm : Form
    {
        private ListingActivityLogic _logic;
        private int _remainingSeconds;
        private Timer runTimer = new Timer();
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private Random _rand = new Random();

        public ListingForm()
        {
            InitializeComponent();
            numericDuration.Value = 30;
            lblPrompt.Text = "Set duration and press Start.";
            runTimer.Interval = 1000;
            runTimer.Tick += RunTimer_Tick;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int duration = (int)numericDuration.Value;
            _logic = new ListingActivityLogic(duration);
            _remainingSeconds = duration;
            btnStart.Enabled = false;
            numericDuration.Enabled = false;
            listBoxItems.Items.Clear();

            // show prompt
            lblPrompt.Text = _prompts[_rand.Next(_prompts.Count)];
            lblStatus.Text = "Prepare...";
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
                lblStatus.Text = "Start listing items (press Enter to add):";
                txtItem.Enabled = true;
                txtItem.Focus();
                runTimer.Start();
            }
        }

        private void RunTimer_Tick(object sender, EventArgs e)
        {
            _remainingSeconds--;
            lblTimeLeft.Text = $"Time left: {_remainingSeconds}s";
            if (_remainingSeconds <= 0)
            {
                runTimer.Stop();
                txtItem.Enabled = false;
                CompleteActivity();
            }
        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtItem.Enabled)
            {
                var text = txtItem.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    listBoxItems.Items.Add(text);
                    txtItem.Clear();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CompleteActivity()
        {
            lblStatus.Text = $"Time up! You listed {listBoxItems.Items.Count} items.";
            _logic.CompleteAndLog();
            // also append items count to log (optional)
            try
            {
                System.IO.File.AppendAllText("activity_log.txt", $"ItemsListed,{listBoxItems.Items.Count}\n");
            }
            catch { }
            btnStart.Enabled = true;
            numericDuration.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class ListingActivityLogic : Activity
    {
        public ListingActivityLogic(int durationSeconds)
            : base("Listing", "List many positive things in your life.")
        {
            DurationSeconds = durationSeconds;
        }
    }
}
