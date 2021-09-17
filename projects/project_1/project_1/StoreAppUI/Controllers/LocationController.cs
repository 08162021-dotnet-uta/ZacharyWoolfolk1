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
  public class LocationController : Controller
  {
    private readonly IRepository<Location> _locationRepo;
    private readonly IManager<Location> _locationManager;
    private readonly ILogger<LocationController> _logger;

    public LocationController(IRepository<Location> lr, ILogger<LocationController> logger, IManager<Location> lM)
    {
      _locationRepo = lr;
      _locationManager = lM;
      _logger = logger;
    }

    // GET: LocationController
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    // GET: LocationController/Details/5
    [HttpGet("Locationlist")]
    public async Task<ActionResult<List<Location>>> Details(int id)
    {
      List<Location> locations = await _locationRepo.Select();

      //_logger.LogInformation();

      return locations;
    }

    // GET: LocationController/Create
    [HttpGet("addnewlocation")]
    public ActionResult Create()
    {
      return View();
    }

    // POST: LocationController/Create
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

    // GET: LocationController/Edit/5
    [HttpGet("locationedit/{id}")]
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: LocationController/Edit/5
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

    // GET: LocationController/Delete/5
    [HttpGet("locationdelet/{id}")]
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: LocationController/Delete/5
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
    /// Takes a location name and returns a location if one is found.
    /// Otherwise, returns NotFound();
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    [HttpGet("store/{name}")]
    public async Task<ActionResult<Location>> Enter(string location)
    {
      if (!ModelState.IsValid) return BadRequest();

      Location l = new Location() { Location1 = location };
      //send fname and lname into a method of business layer to check DB for customer
      Location chosenLocation = await _locationManager.GetElement(l.Location1);
      if (chosenLocation == null)
      {
        return NotFound();
      }

      return Ok(chosenLocation);
    }
  }
}
