using AracCepte.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracCepte.DataAccess.Abstract
{
    public interface IUserRepository
    {
        User GetUserByEmailAndPassword(string email, string passwowrd);
    }
}
