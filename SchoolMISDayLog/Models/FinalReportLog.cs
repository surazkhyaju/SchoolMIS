//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolMISDayLog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FinalReportLog
    {
        public int Expr1 { get; set; }
        public int ComponentId { get; set; }
        public string Status { get; set; }
        public string ComponentName { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ControllerName { get; set; }
        public int DailyDeveloperTaskLogId { get; set; }
        public string Task { get; set; }
        public int ControllerId { get; set; }
        public int ServiceId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> TimeStart { get; set; }
        public Nullable<int> TimeEnd { get; set; }
        public string JSFileName { get; set; }
        public string ViewName { get; set; }
        public string Remark { get; set; }
        public Nullable<int> CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public Nullable<System.DateTime> CreatedByUSerDate { get; set; }
        public string ServiceName { get; set; }
        public int Expr2 { get; set; }
        public string UserName { get; set; }
        public string DeveloperName { get; set; }
        public int DeveloperId { get; set; }
    }
}