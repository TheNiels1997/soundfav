using SoundCloud_Favorite_Player.SoundCloud.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundCloud_Favorite_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UserAccount account;

        private async void Init()
        {
            string uApath = string.Format(@"{0}\\ua", Environment.CurrentDirectory);
            if (!File.Exists(uApath))
            {

            }
            else
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
