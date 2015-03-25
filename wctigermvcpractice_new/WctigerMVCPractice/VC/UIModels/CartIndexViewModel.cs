using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Entities;

namespace VC.UIModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}