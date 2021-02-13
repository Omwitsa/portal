using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.LibraryModels
{
	public class Borrowers
	{
		[Key]
		public int BorrowerNumber { get; set; }
		public string CardNumber { get; set; }
		public string Surname { get; set; }
		public string FirstName { get; set; }
		public string Title { get; set; }
		public string OtherNames { get; set; }
		public string Initials { get; set; }
		public string StreetNumber { get; set; }
		public string StreetType { get; set; }
		public string Address { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string Country { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Fax { get; set; }
		public string EmailPro { get; set; }
		public string PhonePro { get; set; }
		public string B_StreetNumber { get; set; }
		public string B_StreetType { get; set; }
		public string B_Address { get; set; }
		public string B_Address2 { get; set; }
		public string B_City { get; set; }
		public string B_State { get; set; }
		public string B_ZipCode { get; set; }
		public string B_Country { get; set; }
		public string B_Email { get; set; }
		public string B_Phone { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string BranchCode { get; set; }
		public string CategoryCode { get; set; }
		public DateTime? DateEnrolled { get; set; }
		public DateTime? DateExpiry { get; set; }
		public int? GonenoAddress { get; set; }
		public int? Lost { get; set; }
		public DateTime? Debarred { get; set; }
		public string DebarredComment { get; set; }
		public string ContactName { get; set; }
		public string ContactFirstName { get; set; }
		public string ContactTitle { get; set; }
		public int? GuarantorId { get; set; }
		public string BorrowerNotes { get; set; }
		public string Relationship { get; set; }
		public string Sex { get; set; }
		public string Password { get; set; }
		public int? Flags { get; set; }
		public string UserId { get; set; }
		public string OpacNote { get; set; }
		public string ContactNote { get; set; }
		public string Sort1 { get; set; }
		public string Sort2 { get; set; }
		public string AltContactFirstName { get; set; }
		public string AltContactSurname { get; set; }
		public string AltContactAddress1 { get; set; }
		public string AltContactAddress2 { get; set; }
		public string AltContactAddress3 { get; set; }
		public string AltContactState { get; set; }
		public string AltContactZipCode { get; set; }
		public string AltContactCountry { get; set; }
		public string AltContactPhone { get; set; }
		public string SmsAlertNumber { get; set; }
		public int Privacy { get; set; }
	}
}
