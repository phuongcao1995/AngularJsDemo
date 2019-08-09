using CasePortal.Models;
using System.Linq;

namespace CasePortal.Common
{
    public static class Constants
    {
        public const string ToggleSearchForm = "Toggle Search Form";
        public const string Search = "Search";
        public const string Start = "Start";
        public const string End = "End";
        public const string Reset = "Reset";
        public const string All = "All";
        public const string Show = "Show";
        public const string Entries = "entries";
        public const string Posted = "Posted";
        public const string Close = "Close";
        public const string Media = "Media";
        public const string Document = "Document";
        public const string AddNewLog = "Add New Log";
        public const string Add = "Add";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string MessageRequired = "{0} is required.";
        public static readonly int[] ShowNumbers = { 10, 20, 50, 100 };
        public const string MessageNoData = "No data to show";
        public const string MessageSuccess = "{0} was {1} successfully";
        public const string MessageDelete = "Are you sure to delete {0}";
        public const string MessageError = "There was an error";
        public const string AddNew = "Add New";
        public const string UpdateLog = "UpdateLog";
        public const string DeleteLog = "Delete Log";


    }
    public enum StatusCodes
    {
        Success = 1,
        Error
    }

    public enum Status
    {
        Deleted = 0,
        Active,

    }
    public static class ActionUser
    {
        public const string Add = "added";
        public const string Update = "updated";
        public const string Delete = "deleted";
    }

    public static class ObjectSystem
    {
        public const string Log = "Log";
    }

    public static class UserRoles
    {
        public static bool Check(string permissions, User user)
        {
            var arrPermission = permissions.Split(',');
            var roles = user.Roles.Select(x => x.Name).ToArray();
            var query = from permission in arrPermission
                        join role in roles on permission equals role
                        select new { role };
            if (query.Any()) return true;
            return false;
        }

    }

    public static class Permission
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string Editor = "Editor";
        public const string User = "User";
        public const string SuperAdmin_Admin = "SuperAdmin,Admin";
        public const string SuperAdmin_Editor = "SuperAdmin,Editor";
        public const string Admin_Editor = "Admin,Editor";
        public const string SuperAdmin_Admin_Editor = "SuperAdmin,Admin,Editor";
        public const string Admin_User = "Admin,User";
        public const string Editor_User = "Editor,User";
        public const string Admin_Editor_User = "Admin,Editor,User";
    }
}