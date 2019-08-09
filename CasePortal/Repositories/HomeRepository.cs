using CasePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CasePortal.Repositories
{
    public class HomeRepository
    {
        private readonly CasePortalEntities _db = new CasePortalEntities();

        public IEnumerable<Log> GetAllLog()
        {
            return _db.Logs.OrderByDescending(x => x.Id);
        }

        public IEnumerable<Log> GetLog(string keyword, DateTime? notificationDateStart, DateTime? notificationDateEnd,
            DateTime? incidentDateStart, DateTime? incidentDateEnd, int[] incidentTypeIds, int? districtId)
        {
            IQueryable<Log> query = _db.Logs.Where(x => true).OrderByDescending(x => x.Id);
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
                query = query.Where(x => incidentTypeIds.Contains(x.IncidentTypeId));
            }
            if (districtId != null)
            {
                query = query.Where(x => x.DistrictId == districtId);
            }
            return query;
        }

        public Log GetLogById(int id)
        {
            return _db.Logs.Find(id);
        }

        public IEnumerable<Medium> GetMediasByLogId(int id)
        {
            return _db.Media.Where(x => x.LogId == id).OrderByDescending(x => x.Id);
        }

        public IEnumerable<Document> GetDocumentsByLogId(int id)
        {
            return _db.Documents.Where(x => x.LogId == id).OrderByDescending(x => x.Id);
        }

        public bool AddLog(Log log)
        {
            try
            {
                log.CreateAt = DateTime.Now;
                _db.Logs.Add(log);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateLog(Log log)
        {
            try
            {
                _db.Entry(log).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteLog(Log log)
        {
            try
            {
                _db.Entry(log).State = System.Data.Entity.EntityState.Deleted;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}