using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.OldMembershipModels
{
	public partial class OldMembershipContext : DbContext
	{
		public OldMembershipContext(DbContextOptions<OldMembershipContext> options)
			: base(options) { }

		public virtual DbSet<Membership> AspNetUsers { get; set; }
		public virtual DbSet<UserRoles> AspNetUserRoles { get; set; }
		public virtual DbSet<Roles> AspNetRoles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}
