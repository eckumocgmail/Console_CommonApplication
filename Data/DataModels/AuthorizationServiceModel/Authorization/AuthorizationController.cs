using ApplicationDb.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
 

namespace ASpbLibs.Application.WebAPI
{
    
    [Route("api/[controller]/[action]")]
    public class AuthorizationController : Controller
    {
        private APIAuthorization _authorization;

        public AuthorizationController(
            APIAuthorization authorization)
        {
            _authorization = authorization;
        }


        public bool CanActivate(string URL)
        {
            lock (_authorization)
            {
                //var user = _authorization.Verify();
                //if (user == null) return false;
                //user.Account.RFID = URL.Encode();
                //user.Update();
                return _authorization.IsSignin();
            }            
        }

        public object IsSignin()
        {
            var res = _authorization.IsSignin();
            return new
            {
                IsSignin = res
            };
        }

        public object Signin(string Email, string Password)
        {
            try
            {
                _authorization.Signin(Email, Password, false);
            }
            catch (Exception ex)
            {
                string message = $"{ex.GetType().Name}: {ex.Message}";
                while(ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    message += $"\n {ex.GetType().Name}: {ex.Message}";
                }
                return new
                {
                    status = "failed",
                    message = message
                };
            }
            return new
            {
                status = "success"
            };
        }

        public object Signout()
        {
            try
            {
                _authorization.Signout(true);
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "failed",
                    message = ex.Message
                };
            }
            return new
            {
                status = "success"
            };
        } 

        
  
        public object Signup(string Email, string Password, string Confirmation, string SurName, string FirstName, string LastName, string Birthday, string Tel)
        {
            try
            {
                _authorization.Signup(Email, Password, Confirmation, SurName, FirstName, LastName, DateTime.Parse(Birthday), Tel);
            }
            catch (Exception ex)
            {
                string message = "";
                do
                {
                    message += ex.Message + ". ";
                    ex = ex.InnerException;
                }
                while (ex != null);
                return new
                {
                    status = "failed",
                    message = message
                };
            }
            return new
            {
                status = "success"
            };
        }

        public UserApi Verify()
        {
            return _authorization.Verify();
        }

        // 
        public object HasUserWithEmail(string Email)
        {
            bool has = _authorization.HasUserWithEmail(Email);
            if (has)
            {
                return new
                {
                    uniq = "User with this email already registered"
                };
            }
            else
            {
                return new { };
            }
            
        }

        public object HasUserWithTel(string Tel)
        {
            bool has = _authorization.HasUserWithTel(Tel);
            if (has)
            {
                return new
                {
                    uniq = "Use with this tel number already registered"
                };
            }
            else
            {
                return new { };
            } 
        }
    }



}

