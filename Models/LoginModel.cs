using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tacertoforms.Models
{
    public class LoginModel : PageModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set;}

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
    }
}
