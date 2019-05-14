using CasePortal.Models;
using System.Collections.Generic;

namespace CasePortal.Repositories
{
    public class IncidentTypeRepository
    {
        CasePortalEntities db = new CasePortalEntities();
        public IncidentTypeRepository()
        {

        }

        public IEnumerable<IncidentTyle> GetAllIncidentTyle()
        {
            return db.IncidentTyles;
        }
    }
}