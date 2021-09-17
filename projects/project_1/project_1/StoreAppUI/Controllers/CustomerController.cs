using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreAppModelsLayer.Interfaces;
using StoreAppModelsLayer.EFModels;
using Microsoft.Extensions.Logging;

namespace StoreAppUI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CustomerController : Controller
  {
    private readonly IRepository<Customer> _customerRepo;
    private readonly ICustomerManager _customerManager;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(IRepository<Customer> cr, ILogger<CustomerController> logger, ICustomerManager cM)
    {
      _customerRepo = cr;
      _customerManager = cM;
      _logger = logger;
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

      //_logger.LogInformation();

      return customers;
    }

    // GET: CustomerController/Create - for conventional routing
    // Attribut routing involves using attributes to define path


    [HttpPost("register")]
    public async Task<ActionResult<Customer>> Create(Customer c)
    {
      if (!ModelState.IsValid) return BadRequest();

      //Customer c = new Customer() { FirstName = fname, LastName = lname };
      //send fname and lname into a method of business layer to check DB for customer
      Customer cLoggedIn = await _customerManager.RegisterCustomer(c);
      if (cLoggedIn == null)
      {
        return NotFound();
      }

      return Created($"~customer/{c.CustomerId}",cLoggedIn);
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


    /// <summary>
    /// Takes a first and last name and returns a validated customer if one is found.
    /// Otherwise, returns NotFound();
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fname"></param>
    /// <param name="lname"></param>
    /// <returns></returns>
    [HttpGet("login/{fname}/{lname}")]
    public async Task<ActionResult<Customer>> Login(int id, string fname, string lname)
    {
      if (!ModelState.IsValid) return BadRequest();

      Customer c = new Customer() { FirstName = fname, LastName = lname };
      //send fname and lname into a method of business layer to check DB for customer
      Customer cLoggedIn = await _customerManager.LoginCustomer(c);
      if(cLoggedIn == null)
      {
        return NotFound();
      }

      return Ok(cLoggedIn);
    }
  }
}
