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
    public partial class frmCadastro : Form
    {
        private List<User> _db;
        public frmCadastro(List<User> db)
        {
            InitializeComponent();
            _db = db;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var usuario = new User();
            usuario.Name = txtNome.Text;
            usuario.Email = txtEmail.Text;
            usuario.Password = txtSenha.Text;
            _db.Add(usuario);
        }

    }
}
