using SaleManger.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleManger
{
    public partial class Form1 : Form
    {
        SalesMangerEntities db = new SalesMangerEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = db.Users.Where(x => x.Name == txt_user.Text && x.Password == txt_pass.Text).ToList();
            if(result.Count() > 0)
            {
                this.Close();
                Thread th = new Thread(openmain);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Invalid Name Or Password");
            }
        }
        public void openmain()
        {
            Application.Run(new MainForm());
        }
    }
}
