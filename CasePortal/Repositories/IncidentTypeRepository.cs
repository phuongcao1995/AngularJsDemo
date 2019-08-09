using CasePortal.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasePortal.Repositories
{
    public class IncidentTypeRepository
    {
        private readonly CasePortalEntities _db = new CasePortalEntities();

        public IEnumerable<IncidentType> GetAllIncidentTyle()
        {
            return _db.IncidentTypes.OrderBy(x => x.Name);
        }
    }
}