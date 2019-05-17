using CasePortal.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasePortal.Repositories
{
    public class IncidentTypeRepository
    {
        CasePortalEntities db = new CasePortalEntities();
        public IncidentTypeRepository()
        {

        }

        public IEnumerable<IncidentType> GetAllIncidentTyle()
        {
            return db.IncidentTypes.OrderBy(x => x.Name);
        }
    }
}