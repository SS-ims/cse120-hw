namespace MindfulnessApp
{
    partial class BreathingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NumericUpDown numericDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Label lblPhase;
        private System.Windows.Forms.Label lblPhaseCountdown;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer prepareTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblStatus = new System.Windows.Forms.Label();
            this.numericDuration = new System.Windows.Forms.NumericUpDown();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.lblPhase = new System.Windows.Forms.Label();
            this.lblPhaseCountdown = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.prepareTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Set duration and press Start.";
            // 
            // numericDuration
            // 
            this.numericDuration.Location = new System.Drawing.Point(115, 45);
            this.numericDuration.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            this.numericDuration.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numericDuration.Name = "numericDuration";
            this.numericDuration.Size = new System.Drawing.Size(80, 20);
            this.numericDuration.TabIndex = 1;
            this.numericDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(20, 47);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(89, 13);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Duration (seconds)";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(220, 40);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 28);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Location = new System.Drawing.Point(20, 90);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(64, 13);
            this.lblTimeLeft.TabIndex = 4;
            this.lblTimeLeft.Text = "Time left: - ";
            // 
            // lblPhase
            // 
            this.lblPhase.AutoSize = true;
            this.lblPhase.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhase.Location = new System.Drawing.Point(20, 120);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(80, 19);
            this.lblPhase.TabIndex = 5;
            this.lblPhase.Text = "Breathe in";
            // 
            // lblPhaseCountdown
            // 
            this.lblPhaseCountdown.AutoSize = true;
            this.lblPhaseCountdown.Location = new System.Drawing.Point(120, 124);
            this.lblPhaseCountdown.Name = "lblPhaseCountdown";
            this.lblPhaseCountdown.Size = new System.Drawing.Size(26, 13);
            this.lblPhaseCountdown.TabIndex = 6;
            this.lblPhaseCountdown.Text = "4 s";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(220, 120);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BreathingForm
            // 
            this.ClientSize = new System.Drawing.Size(330, 170);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPhaseCountdown);
            this.Controls.Add(this.lblPhase);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.numericDuration);
            this.Controls.Add(this.lblStatus);
            this.Name = "BreathingForm";
            this.Text = "Breathing Activity";
            ((System.ComponentModel.ISupportInitialize)(this.numericDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
