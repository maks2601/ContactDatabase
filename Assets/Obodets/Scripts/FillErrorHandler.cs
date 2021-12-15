using System.Linq;
using TMPro;

namespace Obodets.Scripts
{
    public static class FillErrorHandler
    {
        public static bool NameErrorChecking(string text, TMP_Text errorTextHolder)
        {
            if (text.Length < 3)
            {
                errorTextHolder.text = "At least 3 characters";
                return true;
            }

            if (text.Contains(" "))
            {
                errorTextHolder.text = "Must not contain spaces";
                return true;
            }

            return false;
        }
    
        public static bool PhoneErrorChecking(string text, TMP_Text errorTextHolder)
        {
            if (!text.StartsWith("+"))
            {
                errorTextHolder.text = "Must start with '+'";
                return true;
            }
            text = text.Replace("+", "");
            if (!text.All(char.IsDigit))
            {
                errorTextHolder.text = "Must contain only digits";
                return true;
            }
            if (text.Length < 10)
            {
                errorTextHolder.text = "At least 10 digits";
                return true;
            }

            return false;
        }
    }
}
