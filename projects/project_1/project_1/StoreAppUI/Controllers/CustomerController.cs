using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreAppModelsLayer.Interfaces;
using StoreAppModelsLayer.EFModels;

namespace StoreAppUI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CustomerController : Controller
  {
    private readonly IRepository<Customer> _customerRepo;

    public CustomerController(IRepository<Customer> cr)
    {
      _customerRepo = cr;
    }

    // GET: CustomerController
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    // GET: CustomerController/Details/5
    [HttpGet("Customerlist")]
    public async Task<ActionResult<List<Customer>>> Details()
    {
      List<Customer> customers = await _customerRepo.Select();
      return customers;
    }

    // GET: CustomerController/Create - for conventional routing
    // Attribut routing involves using attributes to define path
    [HttpPut("customercreate/{id}")]
    public ActionResult Create(int id)
    {
      return View();
    }

    // POST: CustomerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: CustomerController/Edit/5
    [HttpGet("customeredit/{id}")]
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: CustomerController/Edit/5
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

    // GET: CustomerController/Delete/5
    [HttpGet("customerdelete/{id}")]
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: CustomerController/Delete/5
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
