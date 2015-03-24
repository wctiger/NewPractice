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

        public ProductsController()
        {
            _repository = new EFProductRepository();
        }

        public ViewResult List()
        {
            return View(_repository.Products);
        }
	}
}