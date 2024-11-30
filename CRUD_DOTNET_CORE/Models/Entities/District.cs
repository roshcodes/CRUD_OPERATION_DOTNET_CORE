using System;
using Microsoft.EntityFrameworkCore;
using RoshProject.Models.Entities;

namespace RoshProject.Models.Entities
{
    public class District
    {
        public int DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public int StateId { get; set; }

    }
}
