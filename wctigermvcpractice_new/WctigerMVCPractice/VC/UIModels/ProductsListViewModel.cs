﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Entities;

namespace VC.UIModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentProductModel { get; set; }
    }
}