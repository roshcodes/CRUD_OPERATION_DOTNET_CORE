using System;
using RoshProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace RoshProject.Data
{
	public class RoshProjectDbContext: DbContext
	{
        public RoshProjectDbContext()
        {
        }

        public RoshProjectDbContext(DbContextOptions<RoshProjectDbContext> options): base(options)
		{
		}
		public DbSet<PersonalInfo> personalInfos { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<State> States { get; set; }
		public DbSet<District> Districts { get; set; }
	}
}

