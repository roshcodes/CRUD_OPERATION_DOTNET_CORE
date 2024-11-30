using System;
using RoshProject.Models;
using RoshProject.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RoshProject.Models
{
	public class PersonalInfoModel
	{
        public PersonalInfoModel()
        {
            this.PersonalList = new List<PersonalInfoModel>();
            this.CountryList = new List<SelectListItem>();
            this.StateList = new List<SelectListItem>();
            this.DistrictList = new List<SelectListItem>();
        }

        public Guid ID { get; set; }
        public string? FirstName { get; set; }
        public string? middleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Address { get; set; }
        public string? PinCode { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? District { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsDeleted { get; set; }

        public List<PersonalInfoModel> PersonalList = new List<PersonalInfoModel>();
        public List<SelectListItem> CountryList = new List<SelectListItem>();
        public List<SelectListItem> StateList = new List<SelectListItem>();
        public List<SelectListItem> DistrictList = new List<SelectListItem>();
    }
}

