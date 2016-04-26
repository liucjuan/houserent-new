using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houserent.Models
{
    public class AreaInfo
    {
        public string AreaId { get; set; }

        public string AreaName { get; set; }

        public string CityId { get; set; }
    }

    public class FieldAreaInfo
    {
        public string AreaId
        {
            get {
                return "AreaId";
            }
        }

        public string AreaName
        {
            get {
                return "AreaName";
            }
        }

        public string CityId
        {
            get {
                return "CityId";
            }
        }
    
    }
}