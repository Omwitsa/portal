using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Messages;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Services
{
    public class SystemServices : ISystemServices
	{
		private IUnitOfWork _unitOfWork;
        private readonly UnisolAPIdbContext _unisolAPIdbContext;
        private readonly IConfiguration _configuration;
        private IStudentServices _studentServices;
        public SystemServices(IUnitOfWork unitOfWork, UnisolAPIdbContext unisolAPIdbContext, IConfiguration configuration, IStudentServices studentServices)
		{
			_unitOfWork = unitOfWork;
            _unisolAPIdbContext = unisolAPIdbContext;
            _configuration = configuration;
            _studentServices = studentServices;
		}

        public ReturnData<List<RecipientViewModel>> GetMessageRecepients(string userName)
        {
            var users = new List<RecipientViewModel>();
            var isGenesis = _studentServices.CheckIfGenesis().Success;
            string connetionString = DbSetting.ConnectionString(_configuration, "Unisol");
            SqlConnection connection = new SqlConnection(connetionString);
            connection.Open();

            string sql = "SELECT AdmnNo as username,[names] as fullname FROM Register"+
                " UNION" +
                " SELECT EmpNo as username,[Names] as fullname FROM hrpEmployee order by fullname asc";
            if (isGenesis)
                sql = "SELECT EmpNo as username,[Names] as fullname FROM hrpEmployee order by fullname asc";

            SqlCommand command = new SqlCommand(sql, connection);
            var listActiveColumns = new List<string>();
            using (var rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    var newUser = new RecipientViewModel
                    {
                        UserName = rdr.GetValue(0).ToString(),
                        RecipientName = rdr.GetValue(1).ToString()
                    };
                    users.Add(newUser);
                }
            }

            var distinctUsers = users.GroupBy(u => u.UserName).Select(u => u.First()).ToList();
            command.Dispose();
            connection.Close();
            return new ReturnData<List<RecipientViewModel>>
            {
                Data = distinctUsers,
                Success = true,
                Message = "Recipients found",
            };
        }
        //public ReturnData<List<RecipientViewModel>> GetMessageRecepients(string username = "")
        //{
        //    var recipients = _unisolAPIdbContext.Register.Where(r => r.AdmnNo.Contains(username) || r.Names.Contains(username))
        //        .Select(r => new RecipientViewModel
        //        {
        //            UserName = r.AdmnNo,
        //            RecipientName = r.Names
        //        }).Take(10).ToList();
        //    if(!recipients.Any())
        //    {
        //        recipients = _unisolAPIdbContext.HrpEmployee.Where(h => h.EmpNo.Contains(username) || h.Names.Contains(username))
        //            .Select(h => new RecipientViewModel
        //            {
        //                UserName = h.EmpNo,
        //                RecipientName = h.Names
        //            }).Take(10).ToList();
        //    }
        //    return new ReturnData<List<RecipientViewModel>>
        //    {
        //        Data = recipients,
        //        Success = false,
        //        Message = "Sorry, no data found in sysSetup",
        //    };
        //}
        public ReturnData<SysSetup> GetSystemSetup()
		{
			try
			{
				var systemSetup = _unitOfWork.SysSetup.GetFirstOrDefault();
				if (systemSetup == null)
					return new ReturnData<SysSetup>
					{
						Success = false,
						Message = "Sorry, no data found in sysSetup",
					};
				return new ReturnData<SysSetup>
				{
					Success = true,
					Message = "Institution details found",
					Data = systemSetup
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<SysSetup>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

	}
}
