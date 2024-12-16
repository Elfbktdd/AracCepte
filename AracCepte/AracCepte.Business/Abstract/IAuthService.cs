using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracCepte.Business.AuthService
{
    public interface IAuthService
    {
        string Authenticate(string email, string Password);
    }
}
