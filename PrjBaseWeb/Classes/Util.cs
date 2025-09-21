using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCalculadoraWeb.Classes
{
    public class Util
    {
        public static bool ValidarCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int digito1 = soma % 11;
            digito1 = digito1 < 2 ? 0 : 11 - digito1;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            int digito2 = soma % 11;
            digito2 = digito2 < 2 ? 0 : 11 - digito2;

            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }
    }
}