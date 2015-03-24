using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Entities;
using Models.Abstract;
using Models.Concrete;

namespace VC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult List()
        {
            
            if (_repository.Products.Any(p => p.CultureID.Trim() == "en"))
            {
                var englishProducts = _repository.Products.Where(p => p.CultureID.Trim().Equals("en"));

                return View(englishProducts);
            }
            else
            {
                throw new Exception(_repository.Products.FirstOrDefault().CultureID);
            }
        }
    }
}