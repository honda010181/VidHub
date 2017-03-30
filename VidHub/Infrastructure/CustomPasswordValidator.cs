using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
namespace VidHub.Infrastructure
{
    public class CustomPasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync (string pass)
        {
            IdentityResult result = await base.ValidateAsync(pass);
            if (pass.Contains("123456"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Passwords cannot contain numeric sequence");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}