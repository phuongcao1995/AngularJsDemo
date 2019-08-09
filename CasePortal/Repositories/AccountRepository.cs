using CasePortal.Models;
using System.Linq;

namespace CasePortal.Repositories
{
    public class AccountRepository
    {
        private readonly CasePortalEntities _db = new CasePortalEntities();
        //public AccountRepository()
        //{

        //}

        public User Login(User user)
        {
            return _db.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
        }
    }
}