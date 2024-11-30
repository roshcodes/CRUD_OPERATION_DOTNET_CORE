using System;
using Microsoft.EntityFrameworkCore;
using RoshProject.Models.Entities;

namespace RoshProject.Models.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }

    }
}
