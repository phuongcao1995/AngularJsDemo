using CasePortal.Models;
using System.Collections.Generic;

namespace CasePortal.Repositories
{
    public class DistrictRepository
    {
        CasePortalEntities db = new CasePortalEntities();
        public DistrictRepository()
        {

        }

        public IEnumerable<District> GetAllDistrict()
        {
            return db.Districts;
        }
    }
}