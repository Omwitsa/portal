using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Common.ViewModels.Users;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.Utilities
{
    public class UserCredentials
    {
        private readonly PortalCoreContext _context;
        private ValidationResult validationResults;
        LoginViewModel request;
        public UserCredentials(PortalCoreContext context)
        {
            _context = context;
            validationResults = new ValidationResult();
        }

        public ReturnData<List<Role>> GetRoles(bool isGenesis)
        {
            var roles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            if (isGenesis)
                roles.Remove(Role.Student);

            return new ReturnData<List<Role>>
            {
                Success = true,
                Message = "System user roles",
                Data = roles
            };
        }

        public ValidationResult PortalUserValidation(LoginViewModel userData)
        {
            request = userData;
            var validUser = ValidatePortalUser();
            if (!validUser.Valid)
            {
                return validUser;
            }

            //var validPasswordReset = ValidateResetPassword();
            //if (!validPasswordReset.Valid)
            //{
            //    return validPasswordReset;
            //}

            var validUserGroup = ValidateUserGroup();
            if (!validUserGroup.Valid)
            {
                return validUserGroup;
            }

            validationResults.Valid = true;
            return validationResults;
        }

        private ValidationResult ValidatePortalUser()
        {

            var portalUser = _context.Users.FirstOrDefault(k => k.UserName == request.Username);
            if (portalUser == null)
            {
                validationResults = new ValidationResult
                {
                    Errors = "Invalid username or password."
                };
                return validationResults;
            }

            var userGroup = _context.UserGroups.FirstOrDefault(g => g.Id == portalUser.UserGroupsId);
            if (userGroup == null)
            {
                validationResults = new ValidationResult
                {
                    Errors = "There was a problem with your login. Contact admin."
                };
                return validationResults;
            }
            if (userGroup.Role == Role.Student)
            {
                var portalLoginAllowed = _context.PortalConfigs.FirstOrDefault(c => c.Code == "003");
                if (portalLoginAllowed == null)
                {
                    validationResults = new ValidationResult
                    {
                        Errors = "Online login not allowed. Contact admin."
                    };
                    return validationResults;
                }
                if (!portalLoginAllowed.Status)
                {
                    validationResults.Valid = false;
                    validationResults.Errors = "Online login not allowed";
                    return validationResults;
                }
            }

            if (!portalUser.Status)
            {
                validationResults.Valid = false;
                validationResults.Errors = "Sorry, your account has been disabled. Please contact admin";
                return validationResults;
            }

            if (string.IsNullOrEmpty(portalUser.PasswordHash))
            {
                validationResults.Valid = false;
                validationResults.Errors = "Please reset your password";
                return validationResults;
            }

            if (!SecurePasswordHasher.Verify(request.Password, portalUser.PasswordHash))
            {
                validationResults.Valid = false;
                validationResults.Errors = "Sorry, username or password invalid. Kindly try again.";
                return validationResults;
            }

            validationResults.Valid = true;
            return validationResults;
        }

        private ValidationResult ValidateResetPassword()
        {
            var portalUser = _context.Users.FirstOrDefault(k => k.UserName == request.Username);
            var resetPassword = _context.UserResetPasswords.FirstOrDefault(u => u.UserId == portalUser.Id);
            if (resetPassword != null)
            {
                if (!resetPassword.Status)
                {
                    validationResults.Valid = false;
                    validationResults.Errors = "You asked for password reset, please confirm your email";
                    return validationResults;
                }
            }

            validationResults.Valid = true;
            return validationResults;
        }

        private ValidationResult ValidateUserGroup()
        {
            var portalUser = _context.Users.FirstOrDefault(k => k.UserName == request.Username);
            var userGroup = _context.UserGroups.FirstOrDefault(k => k.Id == (int)portalUser.UserGroupsId);
            if (userGroup == null)
            {
                validationResults.Valid = false;
                validationResults.Errors = "Sorry,we could not find your user group";
                return validationResults;
            }

            if (!userGroup.Status)
            {
                validationResults.Valid = false;
                validationResults.Errors = "Sorry, your group has been deactivated, please contact admin";
                return validationResults;
            }

            validationResults.Valid = true;
            return validationResults;
        }
    }
}
