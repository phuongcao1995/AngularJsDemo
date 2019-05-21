using CasePortal.Models;
using System.Linq;

namespace CasePortal.Repositories
{
    public class AccountRepository
    {
        CasePortalEntities db = new CasePortalEntities();
        public AccountRepository()
        {

        }

        public User Login(User user)
        {
            return db.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
        }
    }
}