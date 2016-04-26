using houserent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace houserent.Controllers
{
    public class PublishProductController : Controller
    {
        //
        // GET: /PublishProduct/
        /// <summary>
        /// 产品信息发布
        /// </summary>
        /// <param name="renResource"></param>
        /// <returns></returns>
        public ActionResult Index(RentResource renResource)
        {
            
            return View();
        }

        public JsonResult Publish(string renResourceJson)
        {
            Dictionary<string, string> fieldsAndValue = new Dictionary<string, string>();
            //fieldsAndValue.Add(renResource.RentType,renResource.RentType);
            //fieldsAndValue.Add(renResource.NameOfVillage,renResource.NameOfVillage);
            //fieldsAndValue.Add(renResource.AreaName,renResource.AreaName);
            //fieldsAndValue.Add(renResource.StreetName,renResource.StreetName);
            //fieldsAndValue.Add(renResource.FullAddress,renResource.FullAddress);
            //fieldsAndValue.Add(renResource.Room.ToString(),renResource.Room.ToString());
            //fieldsAndValue.Add(renResource.Hall.ToString(),renResource.Hall.ToString());
            //fieldsAndValue.Add(renResource.RestRoom.ToString(),renResource.RestRoom.ToString());
            //fieldsAndValue.Add(renResource.Acreage.ToString(),renResource.Acreage.ToString());
            //fieldsAndValue.Add(renResource.Floor.ToString(),renResource.Floor.ToString());
            //fieldsAndValue.Add(renResource.Floors.ToString(),renResource.Floors.ToString());
            //fieldsAndValue.Add(renResource.Direction.ToString(),renResource.Direction.ToString());
            //fieldsAndValue.Add(renResource.FitMent,renResource.FitMent);
            //fieldsAndValue.Add(renResource.HouseType,renResource.HouseType);
            return Json(new { Flag=true});
        }

    }
}
