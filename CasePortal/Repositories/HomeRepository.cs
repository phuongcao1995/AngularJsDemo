using CasePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CasePortal.Repositories
{
    public class HomeRepository
    {
        CasePortalEntities db = new CasePortalEntities();
        public HomeRepository()
        {

        }

        public IEnumerable<Log> GetAllLog()
        {
            return db.Logs;
        }

        public IEnumerable<Log> GetLog(string keyword, DateTime? notificationDateStart, DateTime? notificationDateEnd,
            DateTime? incidentDateStart, DateTime? incidentDateEnd, int[] incidentTypeIds, int? districtId)
        {
            IQueryable<Log> query = null;
            query = db.Logs.Where(x => true);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            if (notificationDateStart != null && notificationDateEnd != null)
            {
                query = query.Where(x => x.NotificationDate >= notificationDateStart && x.NotificationDate <= notificationDateEnd);
            }
            else if (notificationDateStart != null)
            {
                query = query.Where(x => x.NotificationDate >= notificationDateStart);
            }
            else if (notificationDateEnd != null)
            {
                query = query.Where(x => x.NotificationDate <= notificationDateEnd);
            }
            if (incidentDateStart != null && incidentDateEnd != null)
            {
                query = query.Where(x => x.IncidentDate >= incidentDateStart && x.IncidentDate <= incidentDateEnd);
            }
            else if (incidentDateStart != null)
            {
                query = query.Where(x => x.IncidentDate >= incidentDateStart);
            }
            else if (notificationDateEnd != null)
            {
                query = query.Where(x => x.IncidentDate <= notificationDateEnd);
            }
            if (incidentTypeIds != null)
            {
                query = query.Where(x => incidentTypeIds.Contains(x.IncidentTyleId));
            }
            if (districtId != null)
            {
                query = query.Where(x => x.DistrictId == districtId);
            }
            return query;
        }
    }
}