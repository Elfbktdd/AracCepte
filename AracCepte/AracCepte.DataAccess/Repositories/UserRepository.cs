using AracCepte.DataAccess.Abstract;
using AracCepte.DataAccess.Context;
using AracCepte.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracCepte.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AracCepteContext _context;

        public UserRepository(AracCepteContext context)
        {
            _context = context;
        }

      
        public User GetUserByEmailAndPassword(string email, string passwowrd)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == passwowrd);
        }
    }
}
