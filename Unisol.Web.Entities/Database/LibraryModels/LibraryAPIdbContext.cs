using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.LibraryModels
{
	public partial class LibraryAPIdbContext: DbContext
	{
		public LibraryAPIdbContext(DbContextOptions<LibraryAPIdbContext> options)
		   : base(options) { }

		public virtual DbSet<Issue> Issues { get; set; }
		public virtual DbSet<Borrowers> Borrowers { get; set; }
		public virtual DbSet<AccountLines> AccountLines { get; set; }
		public virtual DbSet<Items> Items { get; set; }
		public virtual DbSet<Biblio> Biblio { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Issue>(entity =>
			{
				entity.Property(i => i.IssueId)
					.HasColumnName("issue_id")
					.HasDefaultValue(0)
					.IsRequired();

				entity.Property(i => i.AutoRenew)
					.HasColumnName("auto_renew")
					.HasDefaultValue(0);

				entity.Property(i => i.DueDate)
					.HasColumnName("date_due")
					.HasColumnType("datetime");

				entity.Property(i => i.OnSiteCheckout)
					.HasColumnName("onsite_checkout")
					.HasDefaultValue(0)
					.IsRequired();
			});

			modelBuilder.Entity<AccountLines>(entity =>
			{
				entity.Property(a => a.AccountlinesId)
					.HasColumnName("accountlines_id")
					.HasDefaultValue(0)
					.IsRequired();

				entity.Property(a => a.NotifyId)
					.HasColumnName("notify_id")
					.HasDefaultValue(0)
					.IsRequired();

				entity.Property(a => a.NotifyLevel)
					.HasColumnName("notify_level")
					.HasDefaultValue(0)
					.IsRequired(); 

				entity.Property(a => a.ManagerId)
					.HasColumnName("manager_id")
					.HasDefaultValue(0)
					.IsRequired();
			});

			modelBuilder.Entity<Items>(entity =>
			{
				entity.Property(i => i.CodedLocationQualifier)
					.HasColumnName("coded_location_qualifier");

				entity.Property(i => i.ItemNotesNonPublic)
					.HasColumnName("itemnotes_nonpublic");

				entity.Property(i => i.PermanentLocation)
					.HasColumnName("permanent_location");  

				entity.Property(i => i.CnSource)
					.HasColumnName("cn_source");  

				entity.Property(i => i.CnSort)
					.HasColumnName("cn_sort");

				entity.Property(i => i.MoreSubfieldsXml)
					.HasColumnName("more_subfields_xml");
			});
		}
	}
}
