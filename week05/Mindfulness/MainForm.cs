using System.Collections.Generic;
using System.Windows.Forms;

namespace MindfulnessApp
{
    public class MainForm : Form
    {
        private ListBox lstUsers;

        public MainForm(List<User> users)
        {
            this.Text = "Mindfulness Main Form";
            this.Width = 400;
            this.Height = 300;

            lstUsers = new ListBox() { Left = 20, Top = 20, Width = 340, Height = 200 };
            this.Controls.Add(lstUsers);

            foreach (var user in users)
            {
                lstUsers.Items.Add(user.ToString());
            }
        }
    }
}
