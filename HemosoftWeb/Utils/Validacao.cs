using System;

namespace HemosoftWeb.Utils
{
    internal class Validacao
    {
        public static bool CpfEhValido(string cpf)
        {
            if (cpf == null)
            {
                return false;
            }

            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }

            switch (cpf)
            {
                case "11111111111":
                    return false;

                case "22222222222":
                    return false;

                case "33333333333":
                    return false;

                case "44444444444":
                    return false;

                case "55555555555":
                    return false;

                case "66666666666":
                    return false;

                case "77777777777":
                    return false;

                case "88888888888":
                    return false;

                case "99999999999":
                    return false;

                case "00000000000":
                    return false;
            }

            #region Variaveis

            int peso = 10;
            int soma = 0;
            int resto;
            int digito1, digito2;

            #endregion Variaveis

            #region Digito 1

            for (int i = 0; i < 9; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * peso;
                peso--;
            }
            resto = soma % 11;
            if (resto < 2)
            {
                digito1 = 0;
            }
            else
            {
                digito1 = 11 - resto;
            }

            #endregion Digito 1

            #region Digito 2

            peso = 11;
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * peso;
                peso--;
            }
            resto = soma % 11;
            if (resto < 2)
            {
                digito2 = 0;
            }
            else
            {
                digito2 = 11 - resto;
            }

            #endregion Digito 2

            #region Comparacao

            if (digito1 == Convert.ToInt32(cpf[9].ToString())
                && digito2 == Convert.ToInt32(cpf[10].ToString()))
            {
                return true;
            }
            return false;

            #endregion Comparacao
        }

        public static bool CnpjEhValido(string cnpj)
        {
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                return false;
            }

            switch (cnpj)
            {
                case "11111111111111":
                    return false;

                case "22222222222222":
                    return false;

                case "33333333333333":
                    return false;

                case "44444444444444":
                    return false;

                case "55555555555555":
                    return false;

                case "66666666666666":
                    return false;

                case "77777777777777":
                    return false;

                case "88888888888888":
                    return false;

                case "99999999999999":
                    return false;

                case "00000000000000":
                    return false;
            }

            #region Variaveis

            int[] pesos1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesos2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            int resto;
            int digito1, digito2;

            #endregion Variaveis

            #region Digito 1

            for (int i = 0; i < 12; i++)
            {
                soma += Convert.ToInt32(cnpj[i].ToString()) * pesos1[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                digito1 = 0;
            }
            else
            {
                digito1 = 11 - resto;
            }

            #endregion Digito 1

            #region Digito 2

            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                soma += Convert.ToInt32(cnpj[i].ToString()) * pesos2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                digito2 = 0;
            }
            else
            {
                digito2 = 11 - resto;
            }

            #endregion Digito 2

            #region Comparacao

            if (digito1 == Convert.ToInt32(cnpj[12].ToString())
                && digito2 == Convert.ToInt32(cnpj[13].ToString()))
            {
                return true;
            }
            return false;

            #endregion Comparacao
        }
    }
}