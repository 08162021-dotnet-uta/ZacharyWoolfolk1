using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreAppModelsLayer.EFModels;
using StoreAppModelsLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAppUI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class OrderController : Controller
  {
    private readonly IRepository<Order> _orderRepo;
    private readonly IOrderManager _orderManager;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IRepository<Order> or, ILogger<OrderController> logger, IOrderManager oM)
    {
      _orderRepo = or;
      _orderManager = oM;
      _logger = logger;
    }


    // GET: OrderController
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    // GET: OrderController/Details/5
    [HttpGet("Orderlist")]
    public async Task<ActionResult<List<Order>>> Details()
    {
      List<Order> orders = await _orderRepo.Select();

      //_logger.LogInformation();

      return orders;
    }

    // GET: OrderController/Create


    [HttpPost("placeorder")]
    public async Task<ActionResult<Order>> Create(Order o)
    {
      if (!ModelState.IsValid) return BadRequest();

      //o.OrderDate = DateTime.Today;
      //Customer c = new Customer() { FirstName = fname, LastName = lname };
      //send fname and lname into a method of business layer to check DB for customer
      Order order = await _orderManager.PlaceOrder(o);
      if (order == null)
      {
        return NotFound();
      }

      return Created($"~order/{o.OrderId.ToString()}", order);
    }

    // POST: OrderController/Create
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

    // GET: OrderController/Edit/5
    [HttpGet("editorder")]
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: OrderController/Edit/5
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

    // GET: OrderController/Delete/5
    [HttpGet("removeorder")]
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: OrderController/Delete/5
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
