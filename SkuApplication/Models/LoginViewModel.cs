using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SkuApplication.Models
{
    public class LoginViewModel
    {
        //[Remote(action: "VerifyUser", controller: "User")]
        [Required(ErrorMessage = "Vul aub een gebruikersnaam in")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vul aub een wachtwoord in")]
        public string Password { get; set; }
    }
}