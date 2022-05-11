using SaleManger.DB;
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

namespace SaleManger.Screens.Users
{
    public partial class NewUser : Form
    {
        SalesMangerEntities db = new SalesMangerEntities();
        string imagepath;
        public NewUser()
        {
            InitializeComponent();
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name = txt_user.Text,
                Password = txt_pass.Text,
                Image = imagepath
            };
            db.Users.Add(user);
            db.SaveChanges();
            string newpath = Environment.CurrentDirectory + "\\Images\\Users\\" + user.Id + ".jpg";
            File.Copy(imagepath, newpath);
          
            MessageBox.Show("تم الحفظ ");
            this.Close();

        }

        private void pic_box_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imagepath = dlg.FileName;
                pic_box.ImageLocation = dlg.FileName;
            }
        }
    }
}
