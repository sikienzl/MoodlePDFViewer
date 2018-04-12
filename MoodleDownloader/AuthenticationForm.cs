using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodleDownloader
{
    public partial class AuthenticationForm : Form
    {
        public AuthenticationForm()
        {
            InitializeComponent();
            lblBenutzername.Text = "Benutzername:";
            lblPasswort.Text = "Passwort";
            bttnSubmit.Text = "send...";
            this.Text = "MoodleDownloader";
            groupBox1.Text = "Benutzername und Passwort eingeben:";
           
        }

        private Form1 form1;
        public void Load(Form1 form1)
        {
            this.form1 = form1;
        }


        private void bttnSubmit_Click(object sender, EventArgs e)
        {
            form1.authenticate(txtBoxBenutzername.Text, txtBoxPasswort.Text);
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {

        }

        private void AuthenticationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                
        }

    }
}
