using EnterpriseName.SolutionName.Domain.BLL.Interfaces;
using EnterpriseName.SolutionName.Domain.Models.BusinessResults;
using EnterpriseName.SolutionName.Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace EnterpriseName.SolutionName.APIRest.Controllers
{
    public class BaseController : ControllerBase
    {
        private IBaseBusiness BaseBusiness { get; init; }

        public BaseController(IBaseBusiness baseBusiness)
        {
            BaseBusiness = baseBusiness;
        }

        #region Public Enums

        public enum JwtKeys
        {
            Id,
            Login,
            Exp,
            RowGuid
        }

        public enum TypeOfLog
        {
            Default
        }

        #endregion

        #region Public Methods

        public ResultInfo<User> CheckJwtToken()
        {
            ResultInfo<User> result = new ResultInfo<User>();
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;

            try
            {
                if (identity?.Claims.Count() == 0)
                {
                    result.Errors.Add(new ResultError
                    {
                        ErrorMessage = "It's mandatory use the token",
                        IsException = false,
                        Method = "BaseController.CheckJwtToken"
                    });
                    return result;
                }

                if (long.TryParse(identity?.Claims?.FirstOrDefault(x => x.Type == JwtKeys.Exp.ToString().ToLower())?.Value, out long expUnix))
                {
                    DateTime expireDate = DateTimeOffset.FromUnixTimeSeconds(expUnix).DateTime.ToLocalTime();
                    if (expireDate < DateTime.Now)
                    {
                        result.Errors.Add(new ResultError
                        {
                            ErrorMessage = "Token expired",
                            IsException = false,
                            Method = "BaseController.CheckJwtToken"
                        });
                        return result;
                    }
                }
                else
                {
                    result.Errors.Add(new ResultError
                    {
                        ErrorMessage = "Invalid expiration date",
                        IsException = false,
                        Method = "BaseController.CheckJwtToken"
                    });
                    return result;
                }

                string? guid = identity?.Claims?.FirstOrDefault(x => x.Type == JwtKeys.RowGuid.ToString().ToLower())?.Value;
                if (!string.IsNullOrEmpty(guid))
                {
                    //result = _usersQueryBusiness.GetUserByGuid(guid);
                }
                else
                {
                    result.Errors.Add(new ResultError
                    {
                        ErrorMessage = "Invalid token",
                        IsException = false,
                        Method = "BaseController.CheckJwtToken"
                    });
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Errors.Add(new ResultError { ErrorMessage = e.Message, IsException = true, Method = "BaseController.CheckJwtToken" });
            }

            return result;
        }

        public IPAddress? GetClientIP()
        {
            return Request.HttpContext.Connection.RemoteIpAddress;
        }

        #endregion
    }
}