using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "admin")
            {
                MessageBox.Show("USERNAME ATAU PASSWORD SALAH");
            }
            if(textBox2.Text != "12")
            {
                MessageBox.Show("USERNAME ATAU PASSWORD SALAH");
                return;
            }

            new Form1().Show();
            this.Hide();

        }
    }
}
