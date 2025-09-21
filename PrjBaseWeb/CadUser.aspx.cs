
using PrjCalculadoraWeb.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Assunto:  CADUSER-WEB-MANHA-PARTEI Nome do aluno
// Colar apenas a foto do seu projeto com pelo menos
// 2 usuários
// Email: halrangel@yahoo.com.br

namespace PrjCalculadoraWeb
{
    public partial class CadUser : System.Web.UI.Page
    {
        private static List<Usuario> usuarios;

        private String arquivoUser = "usuarios.dat";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (usuarios == null)
            {
                if (File.Exists(arquivoUser))
                {
                    usuarios = Serializa.DesserializaUsuario(arquivoUser);
                    txRelatorio.Text = Relatorio();
                    Usuario.AtualizaContador(usuarios);
                }
                else
                {
                    usuarios = new List<Usuario>();
                }
            }
            btExcluir.Enabled = (Session["usuario"] != null);
        }

        protected void btLimpar_Click(object sender, EventArgs e)
        {
            txBusca.Text =
            lbMensagem.Text =
            txCPF.Text =
                txLogin.Text =
                txNome.Text = String.Empty;

            rbAdm.Checked =  
            rbUser.Checked = false;

            txCPF.Enabled =
                txLogin.Enabled =
                txNome.Enabled =  
            rbUser.Enabled =
                rbAdm.Enabled = true;

            Session["usuario"] = null;

            btExcluir.Enabled = false;

            btOk.Text = "Insere";
        }

        protected void btOk_Click(object sender, EventArgs e)
        {

            if (txNome.Text.Trim().Equals(String.Empty))
            {
                lbMensagem.Text = "Digite o nome";
                return;
            }

            if (!rbAdm.Checked && !rbUser.Checked)
            {
                lbMensagem.Text = "Selecione o perfil";
                return;
            }

            if (Session["usuario"] != null)
            {
                usuarios[(int)Session["usuario"]].Atualiza(txNome.Text,
                    rbAdm.Checked ? 'A' : 'U');
                Serializa.SerializaUsuario(usuarios, arquivoUser);
                txRelatorio.Text = Relatorio();
                return;

            }

            if (!Util.ValidarCPF(txCPF.Text))
            {
                lbMensagem.Text = "CPF inválido";
                return;
            }

           

            if (txLogin.Text.Trim().Equals(String.Empty))
            {
                lbMensagem.Text = "Digite o login";
                return;
            }

            if (!rbAdm.Checked && !rbUser.Checked)
            {
                lbMensagem.Text = "Selecione o perfil";
                return;
            }

            Usuario u = new Usuario(txNome.Text,
                txCPF.Text,
                txLogin.Text,
                rbAdm.Checked ? 'A' : 'U');

            foreach(Usuario usuario in usuarios)
            {
                if (u.Cpf.Equals(usuario.Cpf))
                {
                    lbMensagem.Text = 
                        "Já existe um usuário com este CPF";
                    return;
                }
            }
            foreach (Usuario usuario in usuarios)
            {
                if (u.Login.Equals(usuario.Login))
                {
                    lbMensagem.Text =
                        "Já existe um usuário com este Login";
                    return;
                }
            }

            usuarios.Add(u);
            usuarios.Sort();

            txRelatorio.Text = Relatorio();

            btLimpar_Click(btLimpar, e);

            Serializa.SerializaUsuario(usuarios, arquivoUser);

        }

        private string Relatorio ()
        {
            StringBuilder rel = new StringBuilder();
            foreach(Usuario usario in usuarios)
            {
                rel.AppendLine(usario.ToString());
            }
            return rel.ToString();
        }



       

        private void Mostra(Usuario u)
        {
            txCPF.Text = u.Cpf;
            txLogin.Text = u.Login;
            txNome.Text = u.Nome;           

            rbAdm.Checked = u.Perfil == 'A';
            rbUser.Checked = u.Perfil == 'U';

        }

        protected void btBusca_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txBusca.Text, out int num))
            {
                lbMensagem.Text = "ID de usuário inválido";
                return;
            }

            Usuario busca = new Usuario(num.ToString("D4"));
            int pos = usuarios.BinarySearch(busca);

            if (pos < 0)
            {                 
                    lbMensagem.Text = "ID de usuário não existe";
                    return;                 
            }

            btOk.Text = "Altera";

            Session["usuario"] = pos;

            btExcluir.Enabled = true;

            Mostra(usuarios[pos]);
        }

        protected void btExcluir_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                return;
            }

            int pos = (int)Session["usuario"];

            usuarios.Remove(usuarios[pos]);
            usuarios.Sort();
            btLimpar_Click(sender, e);
            txRelatorio.Text = Relatorio();
            Serializa.SerializaUsuario(usuarios, arquivoUser);

        }
    }
}