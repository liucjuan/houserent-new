using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houserent.Models
{
    public class Label
    {
        public string RentResourseID { get; set; }

        public string TagName { get; set; }
    }

    public class FieldLabel
    {
        public string RentResourseID
        {
            get
            {
                return "RentResourseID";
            }
        }
        public string TagName
        {
            get
            {
                return "TagName";
            }
        }
    }
}