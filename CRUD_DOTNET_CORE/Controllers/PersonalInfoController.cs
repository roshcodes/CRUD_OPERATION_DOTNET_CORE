using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoshProject.Data;
using RoshProject.Models;
using RoshProject.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RoshProject.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly RoshProjectDbContext db;

        // Dependency injection
        public PersonalInfoController(RoshProjectDbContext db)
        {
            this.db = db;
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        public void BindDropdown(PersonalInfoModel model)
        {
            var CountryData = db.Countries.Select(m => new { m.CountryId , m.CountryName}).OrderBy(m=>m.CountryName).ToList();
            model.CountryList.Add(new SelectListItem { Text = "- Select -",Value = "0" });
            foreach (var item in CountryData)
            {
                model.CountryList.Add(new SelectListItem
                {
                    Text = Convert.ToString(item.CountryName),
                    Value = item.CountryId.ToString()
                });
            }
        }
        public JsonResult GetState(int CountryId)
        {
            var model = new PersonalInfoModel();
            var StateData = db.States.Where(m => m.CountryId == CountryId).OrderBy(m => m.StateName).ToList();
            var StateList = new List<SelectListItem>();
            foreach (var item in StateData)
            {
                StateList.Add(new SelectListItem
                {
                    Text = item.StateName,
                    Value = item.StateId.ToString()
                });
            }
            return Json(StateList);
        }
        public JsonResult GetDistrict(int StateId)
        {
            var model = new PersonalInfoModel();
            var DistrictData = db.Districts.Where(m => m.StateId == StateId).OrderBy(m => m.DistrictName).ToList();
            var DistrictList = new List<SelectListItem>();
            foreach (var item in DistrictData)
            {
                DistrictList.Add(new SelectListItem
                {
                    Text = item.DistrictName,
                    Value = item.DistrictId.ToString()
                });
            }
            return Json(DistrictList);
        }
        public ActionResult List()
        {
            var model = new PersonalInfoModel();
            var info = db.personalInfos.Where(m=>!m.IsDeleted).ToList();
            if (info.Count > 0)
            {
                foreach (var item in info)
                {
                    var obj = new PersonalInfoModel();
                    obj.ID = item.ID;
                    obj.FirstName = item.FirstName + " " + item.LastName ?? "--";
                    obj.Email = item.Email != null ? item.Email: "--";
                    obj.Address = item.Address != null ? item.Address : "--";
                    obj.PinCode = item.PinCode != null ? item.PinCode : "--";
                    obj.MobileNo = item.MobileNo != null ? item.MobileNo : "--";
                    obj.IsSubscribed = item.IsSubscribed;
                    model.PersonalList.Add(obj);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new PersonalInfoModel();
            BindDropdown(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCreate(PersonalInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var Emodel = new PersonalInfo();
                Emodel.FirstName = model.FirstName;
                Emodel.LastName = model.LastName;
                Emodel.middleName = model.middleName;
                Emodel.Email = model.Email;
                Emodel.MobileNo = model.MobileNo;
                Emodel.PinCode = model.PinCode;
                Emodel.Address = model.Address;
                Emodel.Country = model.Country;
                Emodel.State = model.State;
                Emodel.District = model.District;
                Emodel.CountryId = model.CountryId;
                Emodel.StateId = model.StateId;
                Emodel.DistrictId = model.DistrictId;
                Emodel.IsSubscribed = model.IsSubscribed;
                db.personalInfos.Add(Emodel);
                db.SaveChanges();
                TempData["SuccessMsg"] = "Data Created Successfully.";
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Edit(Guid ID)
        {
            var Data = db.personalInfos.FirstOrDefault(m=>m.ID == ID);
            //var model = new UpdatePersonalInfoModel();
            if (Data != null)
            {
                //var Data = db.personalInfos.Find(ID);
                var model = new PersonalInfoModel();
                model.ID = Data.ID;
                model.FirstName = Data.FirstName;
                model.middleName = Data.middleName;
                model.LastName = Data.LastName;
                model.Email = Data.Email;
                model.MobileNo = Data.MobileNo;
                model.Address = Data.Address;
                model.Country = Data.Country;
                model.State = Data.State;
                model.District = Data.District;
                model.CountryId = Data.CountryId;
                model.StateId = Data.StateId;
                model.DistrictId = Data.DistrictId;
                ViewBag.StateId = new SelectList(db.States.Where(m => m.CountryId == model.CountryId).ToList(),"StateId","StateName",model.StateId);
                ViewBag.DistrictId = new SelectList(db.Districts.Where(m => m.StateId == model.StateId).ToList(),"DistrictId","DistrictName",model.DistrictId);
                model.PinCode = Data.PinCode;
                model.IsSubscribed = Data.IsSubscribed;
                BindDropdown(model);
                return View(model);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult SaveEdit(PersonalInfoModel model)
        {

            var Data = db.personalInfos.Find(model.ID);
            if(Data != null)
            {
                Data.FirstName = model.FirstName;
                Data.middleName = model.middleName;
                Data.LastName = model.LastName;
                Data.Email = model.Email;
                Data.MobileNo = model.MobileNo;
                Data.Address = model.Address;
                Data.Country = model.Country;
                Data.State = model.State;
                Data.District = model.District;
                Data.CountryId = model.CountryId;
                Data.StateId = model.StateId;
                Data.DistrictId = model.DistrictId;
                Data.PinCode = model.PinCode;
                Data.IsSubscribed = model.IsSubscribed;
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();

                TempData["SuccessMsg"] = "Data Updated Successfully.";
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(Guid ID)
        {
            var Data = db.personalInfos.Find(ID);
            if(Data != null)
            {
                Data.IsDeleted = true;
                //db.Remove(Data);
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
                TempData["ErrorMsg"] = "Data Deleted.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["ErrorMsg"] = "Data Not Deleted.";
            }
            return RedirectToAction("List");
        }


    }
}