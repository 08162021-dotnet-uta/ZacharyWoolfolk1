using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreAppModelsLayer.EFModels;
using StoreAppModelsLayer.Interfaces;
using StoreAppModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAppUI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProductController : Controller
  {
    private readonly IProductRepository _productRepo;
    private readonly IManager<Product> _productManager;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductRepository pr, ILogger<ProductController> logger, IManager<Product> pM)
    {
      _productRepo = pr;
      _productManager = pM;
      _logger = logger;
    }

    // GET: ProductController
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    // GET: ProductController/Details/5
    [HttpGet("Productlist")]
    public async Task<ActionResult<List<Product>>> Details(int id)
    {
      List<Product> products = await _productRepo.Select();

      //_logger.LogInformation();

      return products;
    }

    [HttpGet("productlistings/{id}")]
    public async Task<ActionResult<List<ProductListing>>> StoreProducts(int id)
    {
      List<Product> products = await _productRepo.GetStoreProducts(id);
      List<StoreInventory> inventories = await _productRepo.GetStoreInventory(id);
      List<ProductListing> storeProducts = new List<ProductListing>();

      for(int i = 0; i < products.Count; i++)
      {
        ProductListing listing = new ProductListing();
        listing.ProductId = products[i].ProductId;
        listing.ProductName = products[i].ProductName;
        listing.ProductDescription = products[i].ProductDescription;
        listing.ProductPrice = products[i].ProductPrice;
        listing.QuantityAvailable = products[i].QuantityAvailable;
        listing.inventory = inventories[i].Inventory;
        storeProducts.Add(listing);
      }

      return storeProducts;
    }

    // GET: ProductController/Create
    [HttpGet("newproduct")]
    public ActionResult Create()
    {
      return View();
    }

    //// POST: ProductController/Create
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create(IFormCollection collection)
    //{
    //  try
    //  {
    //    return RedirectToAction(nameof(Index));
    //  }
    //  catch
    //  {
    //    return View();
    //  }
    //}

    // GET: ProductController/Edit/5
    [HttpGet("alterproduct")]
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: ProductController/Edit/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit(int id, IFormCollection collection)
    //{
    //  try
    //  {
    //    return RedirectToAction(nameof(Index));
    //  }
    //  catch
    //  {
    //    return View();
    //  }
    //}

    // GET: ProductController/Delete/5
    [HttpGet("removeproduct")]
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: ProductController/Delete/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Delete(int id, IFormCollection collection)
    //{
    //  try
    //  {
    //    return RedirectToAction(nameof(Index));
    //  }
    //  catch
    //  {
    //    return View();
    //  }
    //}
  }
}
