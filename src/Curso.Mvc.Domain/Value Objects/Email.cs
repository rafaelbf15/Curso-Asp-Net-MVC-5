using System.Text.RegularExpressions;


namespace Curso.Mvc.Domain.Value_Objects
{
    public class Email
    {
        public static bool Validar(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}
