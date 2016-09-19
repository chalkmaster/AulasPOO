using MeuPrimeiroCRUD.DomainObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuPrimeiroCRUD
{
    public partial class Form1 : Form
    {

        private List<User> _db;

        public Form1()
        {
            InitializeComponent();
            _db = new List<User>();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var formCadastro = new frmCadastro(_db);
            formCadastro.Show();
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_db[0].Name + "\n" + _db[0].Email);
        }
    }
}
