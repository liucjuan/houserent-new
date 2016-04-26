using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houserent.Models
{
    public class MemberInfo
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public string PassWord { get; set; }
        public string Description { get; set; }
        public string Rank { get; set; }
        public string Type { get; set; }
        public string Image{get;set;}
    }

    public class FieldMemberInfo
    {
        public string Name
        {
            get
            {
                return "Name";
            }
        }
        public string Sex
        {
            get
            {
                return "Sex";
            }
        }
        public string PassWord
        {
            get {
                return "PassWord";
            }
        }
        public string Description
        {
            get {
                return "Description";
            }
        }
        public string Rank
        {
            get
            {
                return "Rank";
            }
        }
        public string Type
        {
            get
            {
                return "Type";
            }
        }
        public string Image
        {
            get
            {
                return "Image";
            }
        }
    }
}