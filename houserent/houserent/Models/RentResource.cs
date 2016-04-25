using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houserent.Models
{
    public class RentResource
    {
        public int ID { get; set; }
        public string RentType { get; set; }
        public string NameOfVillage { get; set; }
        public string AreaName { get; set; }
        public string StreetName { get; set; }
        public string FullAddress { get; set; }
        public Nullable<int> Room { get; set; }
        public Nullable<int> Hall { get; set; }
        public Nullable<int> RestRoom { get; set; }
        public Nullable<int> Acreage { get; set; }
        public Nullable<int> Floor { get; set; }
        public Nullable<int> Floors { get; set; }
        public string Direction { get; set; }
        public string FitMent { get; set; }
        public string HouseType { get; set; }
        public Nullable<double> MoneyOfRent { get; set; }
        public string MoneyRentOfType { get; set; }
        public Nullable<int> Bed { get; set; }
        public Nullable<int> furniture { get; set; }
        public Nullable<int> Gas { get; set; }
        public Nullable<int> CentralHeating { get; set; }
        public Nullable<int> BroadBand { get; set; }
        public Nullable<int> Air_condition { get; set; }
        public Nullable<int> IceBox { get; set; }
        public string TV { get; set; }
        public Nullable<int> WaterHeater { get; set; }
        public string Title { get; set; }
        public string LinkMan { get; set; }
        public string Mobile { get; set; }
        public Nullable<System.DateTime> RentStartTime { get; set; }
        public string MembersType { get; set; }
        public string Description { get; set; }
        public Nullable<int> MemberID { get; set; }
    }
}