using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houserent.Models
{
    public class Image
    {
        public string RentResourseID { get; set; }

        public string ImageUrl { get; set; }
    }

    public class FieldImage
    {
        public string RentResourseID
        {
            get
            {
                return "RentResourseID";
            }        
        }

        public string ImageUrl
        {
            get
            {
                return "ImageUrl";
            }
        }
    }
}