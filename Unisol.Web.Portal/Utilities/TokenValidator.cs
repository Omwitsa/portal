using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.Utilities
{
    public class TokenValidator
    {
        private readonly PortalCoreContext _context;

        public TokenValidator(PortalCoreContext context)
        {
            _context = context;

        }

        public ValidToken Validate(HttpContext context)
        {
            var result = new ValidToken { Success = false };
            try
            {
                var request = context.Request;
                var hasBearer = request.Headers.TryGetValue("Authorization", out var token); 
                if (hasBearer)
                {
                    var topAuth = token.ToArray().First();
                    var bearer = topAuth.Substring(7);
                    var user = _context.Users.Join(_context.UserTokens, u => u.Id, ut => ut.UserId, (u, ut) =>
                   new ValidToken
                   {
                       UserId = u.Id,
                       Role = u.Role,
                       UserGroupId = u.UserGroupsId,
                       Token = ut.Value

                   }).FirstOrDefault(v => v.Token.Equals(bearer));

                    if (user != null)
                    {
                        result.UserId = user.UserId;
                        result.UserGroupId = user.UserGroupId;
                        result.Role = user.Role;
                        result.Message = "Valid";
                        result.Success = true;
                        return result;
                    }

                    result.Message = "Invalid: Token does not exist";
                    return result;
                }

                result.Message = "Invalid: Token not provided";
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                result.Message = "Invalid: Error occured";
                return result;
            }

        }

    }

    public class ValidToken
    {

        public bool Success { get; set; }
        public string Message { get; set; }
        public int UserGroupId { get; set; }
        public Role Role { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}
