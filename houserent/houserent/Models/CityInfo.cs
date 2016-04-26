using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houserent.Models
{
    public class CityInfo
    {
        public string PrivinceId { get; set; }

        public string ProvinceName { get; set; }

        public string CityId { get; set; }

        public string CityName { get; set; }
    }

    public class FieldCityInfo
    {
        public string PrivinceId
        {
            get {
                return "PrivinceId";
            }
        }

        public string ProvinceName
        {
            get
            {
                return "ProvinceName";
            }
        }

        public string CityId
        {
            get {
                return "CityId";
            }
        }

        public string CityName
        {
            get {
                return "CityName";
            }
        }
    
    }
}