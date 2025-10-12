namespace MindfulnessApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBreathing;
        private System.Windows.Forms.Button btnReflecting;
        private System.Windows.Forms.Button btnListing;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnBreathing = new System.Windows.Forms.Button();
            this.btnReflecting = new System.Windows.Forms.Button();
            this.btnListing = new System.Windows.Forms.Button();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.colTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBreathing
            // 
            this.btnBreathing.Location = new System.Drawing.Point(30, 60);
            this.btnBreathing.Name = "btnBreathing";
            this.btnBreathing.Size = new System.Drawing.Size(120, 40);
            this.btnBreathing.TabIndex = 0;
            this.btnBreathing.Text = "Breathing";
            this.btnBreathing.UseVisualStyleBackColor = true;
            this.btnBreathing.Click += new System.EventHandler(this.btnBreathing_Click);
            // 
            // btnReflecting
            // 
            this.btnReflecting.Location = new System.Drawing.Point(160, 60);
            this.btnReflecting.Name = "btnReflecting";
            this.btnReflecting.Size = new System.Drawing.Size(120, 40);
            this.btnReflecting.TabIndex = 1;
            this.btnReflecting.Text = "Reflecting";
            this.btnReflecting.UseVisualStyleBackColor = true;
            this.btnReflecting.Click += new System.EventHandler(this.btnReflecting_Click);
            // 
            // btnListing
            // 
            this.btnListing.Location = new System.Drawing.Point(290, 60);
            this.btnListing.Name = "btnListing";
            this.btnListing.Size = new System.Drawing.Size(120, 40);
            this.btnListing.TabIndex = 2;
            this.btnListing.Text = "Listing";
            this.btnListing.UseVisualStyleBackColor = true;
            this.btnListing.Click += new System.EventHandler(this.btnListing_Click);
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTimestamp,
            this.colActivity,
            this.colDuration});
            this.dgvLog.Location = new System.Drawing.Point(30, 120);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.Size = new System.Drawing.Size(540, 260);
            this.dgvLog.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(450, 60);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh Log";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(26, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(207, 21);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Mindfulness Activities Menu";
            // 
            // colTimestamp
            // 
            this.colTimestamp.HeaderText = "Timestamp";
            this.colTimestamp.Name = "colTimestamp";
            this.colTimestamp.ReadOnly = true;
            this.colTimestamp.Width = 200;
            // 
            // colActivity
            // 
            this.colActivity.HeaderText = "Activity";
            this.colActivity.Name = "colActivity";
            this.colActivity.ReadOnly = true;
            this.colActivity.Width = 180;
            // 
            // colDuration
            // 
            this.colDuration.HeaderText = "Duration (s)";
            this.colDuration.Name = "colDuration";
            this.colDuration.ReadOnly = true;
            this.colDuration.Width = 120;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.btnListing);
            this.Controls.Add(this.btnReflecting);
            this.Controls.Add(this.btnBreathing);
            this.Name = "MainForm";
            this.Text = "Mindfulness App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
