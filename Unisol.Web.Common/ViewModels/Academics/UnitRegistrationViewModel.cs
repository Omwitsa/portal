using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Academics
{
    public class UnitRegistrationViewModel
    {
        public string UserCode { get; set; }
        public List<UnitCode> unitCodes { get; set; }
    }

	public enum DoneStatus
	{
		Pending = 1,
		Approved = 2,
		DonePreviously = 3,
		NotRegistered = 4
	}
}
