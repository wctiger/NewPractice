using Models.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VC.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository _repository;

        public NavController(IProductRepository repo)
        {
            _repository = repo;
        }
        
        public PartialViewResult Menu(string productModel = null)
        {
            ViewBag.productModel = productModel;
            var productModelGroups = _repository.Products
                .GroupBy<Product, string>(p => p.ProductModel)
                .Select(p => new { ProductionModel = p.Key, Count = p.Count() });
            var productModels = productModelGroups.OrderByDescending(g => g.Count)
                .Take(20).Select(g => g.ProductionModel);
            return PartialView("_Menu", productModels);
        }
	}
}