using System;
using Microsoft.EntityFrameworkCore;
using RoshProject.Models.Entities;

namespace RoshProject.Models.Entities
{
	public class PersonalInfo
	{
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

    }
}

