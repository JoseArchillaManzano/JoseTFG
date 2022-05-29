using System;
using System.Text.RegularExpressions;

namespace JoseTFG.Models
{
    public static class Helper
    {
        public static bool strongPassword(String contraseñaSinVerificar)
        {
            //letras de la A a la Z, mayusculas y minusculas
            Regex letrasMayus = new Regex(@"[A-Z]");
            Regex letrasMin = new Regex(@"[a-z]");
            //digitos del 0 al 9
            Regex numeros = new Regex(@"[0-9]");
            //cualquier caracter del conjunto
            Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");

            if (contraseñaSinVerificar.Length < 8) return false;

            //si no contiene las letras, regresa false
            if (!letrasMayus.IsMatch(contraseñaSinVerificar)) return false;

            if (!letrasMin.IsMatch(contraseñaSinVerificar)) return false;

            //si no contiene los numeros, regresa false
            if (!numeros.IsMatch(contraseñaSinVerificar)) return false;


            //si no contiene los caracteres especiales, regresa false
            if (!caracEsp.IsMatch(contraseñaSinVerificar)) return false;

            //si cumple con todo, regresa true
            return true;
        }
        public static bool validEmail(String email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}