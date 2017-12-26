using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundCloud_Favorite_Player.SoundCloud.Dialogs
{
    public partial class LoginDialog : Form
    {
        public bool CancelButtonVisible
        {
            get { return button2.Visible; }
            set
            {
                button2.Visible = value;
            }
        }
        public string Username
        {
            get { return textBox1.Text; }
        }
        public byte[] Password
        {
            get { return Encoding.UTF32.GetBytes(textBox2.Text); }
        }

        public LoginDialog()
        {
            InitializeComponent();
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
