using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MindfulnessApp
{
    public class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtEmail;
        private Button btnSave;
        private Button btnOpenMain;
        private ListBox lstUsers;
        private List<User> users = new List<User>();
        private string filePath = "users.txt"; // <== Added: Save/Load path

        public LoginForm()
        {
            this.Text = "Mindfulness Login";
            this.Width = 400;
            this.Height = 420;

            Label lblUsername = new Label() { Text = "Username:", Left = 20, Top = 20, Width = 100 };
            txtUsername = new TextBox() { Left = 120, Top = 20, Width = 200 };

            Label lblEmail = new Label() { Text = "Email:", Left = 20, Top = 60, Width = 100 };
            txtEmail = new TextBox() { Left = 120, Top = 60, Width = 200 };

            btnSave = new Button() { Text = "Save User", Left = 120, Top = 100, Width = 100 };
            btnSave.Click += BtnSave_Click;

            btnOpenMain = new Button() { Text = "Open Main Form", Left = 230, Top = 100, Width = 120 };
            btnOpenMain.Click += BtnOpenMain_Click;

            lstUsers = new ListBox() { Left = 20, Top = 150, Width = 330, Height = 200 };

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnOpenMain);
            this.Controls.Add(lstUsers);

            // 🆕 Load users from file on start
            LoadUsersFromFile();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in both fields.");
                return;
            }

            var user = new User(username, email);

            // Avoid duplicates by username
            if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("User with that name already exists!");
                return;
            }

            users.Add(user);
            lstUsers.Items.Add(user.ToString());

            // 🆕 Save to file immediately
            SaveUsersToFile();

            txtUsername.Clear();
            txtEmail.Clear();
        }

        private void BtnOpenMain_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(users);
            mainForm.Show();
        }

        // 🆕 Save all users to text file
        private void SaveUsersToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var user in users)
                {
                    writer.WriteLine(user.ToFileFormat());
                }
            }
        }

        // 🆕 Load users from text file
        private void LoadUsersFromFile()
        {
            if (!File.Exists(filePath))
                return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var user = User.FromFileFormat(line);
                if (user != null)
                {
                    users.Add(user);
                    lstUsers.Items.Add(user.ToString());
                }
            }
        }
    }
}
