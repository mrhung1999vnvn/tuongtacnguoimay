using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class mvcPhoneModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string GeneralNote { get; set; }
    }
}