using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Common.Utilities
{
    public class Utils
    {
        UnisolAPIdbContext db;
        public Utils(UnisolAPIdbContext context)
        {
            db = context;
        }
        public ReturnData<string> SaveToWorkFlowCenter(ProcOnlineReq procOnlineReq, HrpEmployee userDetails, string docId, string notes = null)
        {
            var wkDocCenter = new WfdocCentre
            {
                Type = procOnlineReq.DocType.ToUpper(),
                DocNo = procOnlineReq.ReqRef,
                Description = string.IsNullOrEmpty(notes) ? "N/A" : notes,
                UserRef = userDetails.EmpNo,
                Names = userDetails.Names,
                Department = userDetails.Department,
                Rdate = DateTime.UtcNow,
                Rtime = DateTime.UtcNow.ToLocalTime(),
                Personnel = userDetails.EmpNo,
                FinalStatus = "Pending"
            };

            db.WfdocCentre.Add(wkDocCenter);
            db.SaveChanges();

            var documentCenterId = db.WfdocCentre.FirstOrDefault(d => d.DocNo == procOnlineReq.ReqRef)?.Id;

            var WFRoutingDetails = db.WfroutingDetails.Where(d => d.Ref == docId).ToList();

            var departmentHeadTitle = "HEAD OF DEPARTMENT";
            var supervisorTitle = "SUPERVISOR";
            var deanTitle = "Dean";

            foreach (var detail in WFRoutingDetails)
            {
                var approver = db.Wfapprovers.FirstOrDefault(a => a.Title == detail.Approver);
                var approverId = approver?.Id.ToString();
                var approversCodes = db.WfapproversDetails.Join(db.Users,
                    approverDetail => approverDetail.UserCode,
                    users => users.UserCode,
                    (approverDetail, users) => new
                    {
                        approverDetail.Ref,
                        approverDetail.UserCode,
                        users.Department
                    }).Where(u => u.Ref == approverId).Select(u => u.UserCode).Distinct().ToList();

                if (detail.Approver.ToLower().Contains(departmentHeadTitle.ToLower()))
                {
                    approversCodes = db.WfapproversDetails.Join(db.Users,
                    approverDetail => approverDetail.UserCode,
                    users => users.UserCode,
                    (approverDetail, users) => new
                    {
                        approverDetail.Ref,
                        approverDetail.UserCode,
                        users.Department
                    }).Where(u => u.Department == userDetails.Department && u.Ref == approverId).Select(u => u.UserCode).Distinct().ToList();
                }

                if (detail.Approver.ToLower().Contains(supervisorTitle.ToLower()))
                {
                    var employeeSupervisor = db.HrpEmployee.FirstOrDefault(e => e.EmpNo == userDetails.EmpNo)?.Supervisor;

                    approversCodes = db.Users.Where(u => u.EmpNo == employeeSupervisor).Select(u => u.UserCode).Distinct().ToList();
                }

                if (detail.Approver.ToLower().Contains(deanTitle.ToLower()))
                {
                    approversCodes = db.Schools.Join(db.Users,
                    schools => schools.DeanUserName,
                    users => users.UserCode,
                    (schools, users) => new
                    {
                        users.UserCode
                    }).Select(u => u.UserCode).Distinct().ToList();
                }

                foreach (var approverCode in approversCodes)
                {
                    var wkDocCenterDetails = new WfdocCentreDetails
                    {
                        Ref = Convert.ToString(documentCenterId),
                        Approver = detail.Approver,
                        Level = detail.Level,
                        UserCode = approverCode,
                        Action = "Approval",
                        Reason = null,
                        Rdate = DateTime.UtcNow,
                        ActionSelected = null,
                        Station = null
                    };

                    db.WfdocCentreDetails.Add(wkDocCenterDetails);
                }
            }

            db.SaveChanges();

            return new ReturnData<string>
            {
                Success = true,
                Data = ""
            };
        }

		public WfdocCentreDetails GetDocCenterDetails(string docNumber)
		{
			var details = new WfdocCentreDetails();
			try
			{
				var docCenter = db.WfdocCentre.FirstOrDefault(c => c.DocNo.ToUpper().Equals(docNumber.ToUpper()));
				if(docCenter != null)
					details = db.WfdocCentreDetails.FirstOrDefault(d => d.Ref == docCenter.Id.ToString());

				return details;
			}
			catch (Exception)
			{
				return details;
			}
		}
	}
}
