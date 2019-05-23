using CasePortal.Common;
using CasePortal.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasePortal.Repositories
{
    public class UserRepository
    {
        CasePortalEntities db = new CasePortalEntities();
        public UserRepository()
        {

        }

        public IEnumerable<User> GetAllUser()
        {
            return db.Users.Where(x => x.Status != (byte)Status.Deleted).OrderByDescending(x => x.Id);
        }
    }
}