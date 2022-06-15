using System;
using System.Text.RegularExpressions;

namespace JoseTFG.Models
{
    public static class Helper
    {
        public static bool strongPassword(String passwordUnchecked)
        {
            Regex letrasMayus = new Regex(@"[A-Z]");
            Regex letrasMin = new Regex(@"[a-z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");

            if (passwordUnchecked.Length < 8) return false;

            if (!letrasMayus.IsMatch(passwordUnchecked)) return false;

            if (!letrasMin.IsMatch(passwordUnchecked)) return false;

            if (!numeros.IsMatch(passwordUnchecked)) return false;

            if (!caracEsp.IsMatch(passwordUnchecked)) return false;

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