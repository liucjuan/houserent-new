using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houserent.Models
{
    public class LeaveMessage
    {
        public string MemberID { get; set; }
        public string Content { get; set; }
        public string RentResourceID { get; set; }
        public string DateTime { get; set; }
    }

    public class FieldLeaveMessage
    {
        public string MemberID
        {
            get
            {
                return "MemberID";
            }
        }
        public string Content
        {
            get {
                return "Content";
            }
        }
        public string RentResourceID
        {
            get {
                return "RentResourceID";
            }
        }
        public string DateTime
        {
            get {
                return "DateTime";
            }
        }
    }
}