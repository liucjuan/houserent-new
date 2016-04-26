using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houserent.Models
{
    public class Collect
    {
        public string MemberId { get; set; }
        public string RentResourceId { get; set; }
    }
    public class FieldCollect
    {
        public string MemberId
        {
            get
            {
                return "MemberId";
            }
        }
        public string RentResourceId
        {
            get {
                return "RentResourceId";
            }
        }
    }
}