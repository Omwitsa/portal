using System;
using System.ComponentModel.DataAnnotations;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public class FLBooking
	{
		[Key]
		public string Ref { get; set; }
		public string EmpNo { get; set; }
		public DateTime? DDate { get; set; }
		public DateTime? DTime { get; set; }
		public DateTime? RetDate { get; set; }
		public DateTime? RetTime { get; set; }
		public string Purpose { get; set; }
		public string VehicleType { get; set; }
		public int? Passengers { get; set; }
		public string Location { get; set; }
		public string Destination { get; set; }
		public DateTime? RDate { get; set; } = DateTime.UtcNow;
		public DateTime? RTime { get; set; } = DateTime.UtcNow;
		public string Personnel { get; set; }
		public string Status { get; set; }
	}
}
