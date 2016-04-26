using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houserent.Models
{
    public class StressInfo
    {
        public string AreaId { get; set; }

        public string StressName { get; set; }
    }

    public class FieldStressInfo
    {
        public string AreaId
        {
            get
            {
                return "AreaId";
            }
        }

        public string StressName
        {
            get
            {
                return "StressName";
            }
        }
    }
}