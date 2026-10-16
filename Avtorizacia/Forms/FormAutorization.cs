using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avtorizacia.ADO.NET;
using Avtorizacia.Forms;

namespace Avtorizacia
{
    public partial class FormAutorization : Form
    {
        public FormAutorization()
        {
            InitializeComponent();
        }

        public static Users Enter_User;

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            Enter_User = null;
            ModelEF DB = new ModelEF();
            Enter_User = DB.Users.FirstOrDefault(x => x.Login == TextBoxLogin.Text && x.Password == TextBoxPassword.Text);
            if (Enter_User != null)
            {
                switch(Enter_User.RoleID)
                {
                    case 1:
                        FormManager formManager = new FormManager();
                        formManager.ShowDialog();
                        break;
                    case 2:
                        FormSeller formSeller = new FormSeller();
                        formSeller.ShowDialog();
                        break;
                    case 3:
                        FormDirector formDirector = new FormDirector();
                        formDirector.ShowDialog();
                        break;
                    default: throw new Exception("Роль не найдена!");
                }
            }
        }
    }
}
