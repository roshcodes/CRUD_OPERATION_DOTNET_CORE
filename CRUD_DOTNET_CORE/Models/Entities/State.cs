using System;
using Microsoft.EntityFrameworkCore;
using RoshProject.Models.Entities;

namespace RoshProject.Models.Entities
{
    public class State
    {
        public int StateId { get; set; }
        public string? StateName { get; set; }
        public int CountryId { get; set; }

    }
}
