using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CharacterMVC.Models;

namespace CharacterMVC.Controllers
{
  public class CharactersController : Controller
  {
    private readonly ILogger<CharactersController> _logger;

    public CharactersController(ILogger<CharactersController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var allCharacters = Character.GetCharacters();
      return View(allCharacters);
    }

    public ActionResult Details(int id)
    {
      var thisCharacter = Character.GetDetails(id);

      return View(thisCharacter);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Character character)
    {
      Character.Post(character);

      return RedirectToAction("Index");
    }

  }
} 
