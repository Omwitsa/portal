using System;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public class FLTrips
	{
		public int ID { get; set; }
		public string PlateNo { get; set; }
		public string Destination { get; set; }
		public string LeadPassenger { get; set; }
		public string Driver { get; set; }
		public string Purpose { get; set; }
		public string DepLocation { get; set; }
		public DateTime? DDate { get; set; }
		public DateTime? DTime { get; set; }
		public int? DOdometer { get; set; }
		public DateTime? RetDate { get; set; }
		public DateTime? RetTime { get; set; }
		public int? RetOdometer { get; set; }
		public string BookingRef { get; set; }
		public string Notes { get; set; }
		public DateTime? RDate { get; set; }
		public string Personnel { get; set; }
	}
}
