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
        public const string Update = "Add";
        public const string Delete = "Delete";
        public const string MessageRequired = "{0} is required.";
        public static readonly int[] ShowNumbers = {10, 20, 50 ,100};
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
         Success=1,
         Error
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
}