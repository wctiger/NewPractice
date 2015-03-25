using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Entities;
using Models.Abstract;
using Models.Concrete;
using VC.UIModels;

namespace VC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult DefaultList()
        {
            
            if (_repository.Products.Any(p => p.CultureID.Trim() == "en"))
            {
                var englishProducts = _repository.Products.Where(p => p.CultureID.Trim().Equals("en"));

                return View("List",englishProducts);
            }
            else
            {
                throw new Exception(_repository.Products.FirstOrDefault().CultureID);
            }
        }

        [OutputCache(Duration=30, VaryByParam="productModel;page")]
        public ViewResult List(string productModel, int page = 1)
        {
            ProductsListViewModel plvm = new ProductsListViewModel();
            var englishProducts = _repository.Products.Where(p => p.CultureID.Trim().Equals("en"))
                .Where(p => string.IsNullOrEmpty(productModel) || p.ProductModel.Contains(productModel));

            plvm.Products = englishProducts.OrderBy(p => p.ProductID)                
                .Skip((page - 1) * 10).Take(10);
            plvm.PagingInfo = new PagingInfo() { TotalItems = englishProducts.Count(), CurrentPage = page, ItemsPerPage = 10 };
            plvm.CurrentProductModel = string.IsNullOrEmpty(productModel) ? "" : productModel;

            return View(plvm);
        }
    }
}