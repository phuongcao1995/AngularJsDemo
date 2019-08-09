using CasePortal.Common;
using CasePortal.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasePortal.Repositories
{
    public class UserRepository
    {
        readonly CasePortalEntities _db = new CasePortalEntities();

        public IEnumerable<User> GetAllUser()
        {
            return _db.Users.Where(x => x.Status != (byte)Status.Deleted).OrderByDescending(x => x.Id);
        }
    }
}