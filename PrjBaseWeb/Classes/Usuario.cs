using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    [Serializable]
    public class Usuario : IComparable<Usuario>  
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }

        public string Cpf { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }

        public char Perfil { get; private set; }

        public static int contador = 0;

        public void AtualizaSenha(String senha)
        {
            Senha = senha;
        }

        public static void AtualizaContador(List<Usuario> lista)
        {
            if (lista.Count == 0) // Garante que não vai dar erro
            {
                contador = 0;
                return;
            }

            Usuario u = lista[lista.Count - 1];
            int.TryParse(u.Id, out contador);
        }

        public void Atualiza(String nome, char perfil)
        {
            Nome = nome;
            Perfil = perfil;
        }

        public Usuario(string id)
        {
            Id = id;
        }

        public Usuario(string nome,
            string cpf,
            string login,         
            char perfil)
        {
            Nome = nome;
            Cpf = cpf;
            Login = login;
            Senha = cpf;
            Perfil = perfil;
            Id = (++contador).ToString("D4");

            

        }

        public override string ToString()
        {
            return String.Concat(Id , ", " ,
                Nome , ", " , Cpf , ", " ,
                Login , ", " ,
              Perfil , ", "  ,
              (Senha.Equals(Cpf) ? "Não trocada" : "Trocada"));
        }

        int IComparable<Usuario>.CompareTo(Usuario user)
        {
            return Id.CompareTo(user.Id);
        }


    }
}