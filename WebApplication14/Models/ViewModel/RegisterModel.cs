using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models.ViewModel
{
    public class RegisterModel
    {

        public string First_name { get; set; }
     
        public string Last_name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string PlaceOfBirth{get;set;}

        public string ConfirmPassword { get; set; }
        public DateTime Year { get; set; }

    }
}
