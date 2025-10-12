namespace MindfulnessApp
{
    partial class ReflectingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.NumericUpDown numericDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timerQuestion;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Label lblStatus;
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
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.numericDuration = new System.Windows.Forms.NumericUpDown();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timerQuestion = new System.Windows.Forms.Timer(this.components);
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.prepareTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(20, 15);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(150, 13);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "Set duration and press Start.";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQuestion.Location = new System.Drawing.Point(20, 80);
            this.lblQuestion.MaximumSize = new System.Drawing.Size(360, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(0, 19);
            this.lblQuestion.TabIndex = 1;
            // 
            // numericDuration
            // 
            this.numericDuration.Location = new System.Drawing.Point(120, 40);
            this.numericDuration.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            this.numericDuration.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numericDuration.Name = "numericDuration";
            this.numericDuration.Size = new System.Drawing.Size(80, 20);
            this.numericDuration.TabIndex = 2;
            this.numericDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(20, 42);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(89, 13);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "Duration (seconds)";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(220, 36);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 28);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Location = new System.Drawing.Point(20, 120);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(64, 13);
            this.lblTimeLeft.TabIndex = 5;
            this.lblTimeLeft.Text = "Time left: - ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 150);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status messages appear.";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(220, 140);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReflectingForm
            // 
            this.ClientSize = new System.Drawing.Size(420, 200);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.numericDuration);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblPrompt);
            this.Name = "ReflectingForm";
            this.Text = "Reflecting Activity";
            ((System.ComponentModel.ISupportInitialize)(this.numericDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
