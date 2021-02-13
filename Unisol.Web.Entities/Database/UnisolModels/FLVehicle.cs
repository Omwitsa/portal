using System;
using System.ComponentModel.DataAnnotations;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public class FLVehicle
	{
		public int ID { get; set; }
		[Key]
		public string PlateNo { get; set; }
		public string VIN { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public string Version { get; set; }
		public string Colour { get; set; }
		public string VehicleType { get; set; }
		public string Category { get; set; }
		public string Location { get; set; }
		public string Transmission { get; set; }
		public int? VYear { get; set; }
		public int? Odometer { get; set; }
		public int? CCRating { get; set; }
		public int? Doors { get; set; }
		public string FuelType { get; set; }
		public string Status { get; set; }
		public string AssetNo { get; set; }
		public string EngineSerial { get; set; }
		public int? Sitting { get; set; }
		public int? standing { get; set; }
		public string FrontTire { get; set; }
		public string RearTire { get; set; }
		public decimal? VWeight { get; set; }
		public decimal? VWidth { get; set; }
		public decimal? VLength { get; set; }
		public decimal? VHeight { get; set; }
		public int? Axles { get; set; }
		public string Owership { get; set; }
		public DateTime? PDate { get; set; }
		public decimal? PPrice { get; set; }
		public string OrderNo { get; set; }
		public string InsType { get; set; }
		public string InsComp { get; set; }
		public string PolicyNo { get; set; }
		public DateTime? PolicyExpire { get; set; }
		public string InsText { get; set; }
		public int? WarrantDuration { get; set; }
		public int? WarrantMileage { get; set; }
		public string Specification { get; set; }
		public string Notes { get; set; }
		public DateTime? RDate { get; set; }
		public string Personnel { get; set; }
	}
}
