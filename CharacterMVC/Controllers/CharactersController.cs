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

    public IActionResult Details(int id)
    {
      var thisCharacter = Character.GetDetails(id);

      return View(thisCharacter);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Character character)
    {
      Character.Post(character);
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var thisCharacter = Character.GetDetails(id);
      return View(thisCharacter);
    }

    [HttpPost]
    public IActionResult Edit(Character character)
    {
      Character.Put(character);
      return RedirectToAction("Details", new { id = character.CharacterId });
    }

    public IActionResult Delete(int id)
      {
        var thisCharacter = Character.GetDetails(id);
        return View(thisCharacter);
      }

      [HttpPost, ActionName("Delete")]
      public IActionResult DeleteConfirmed(int id)
      {
        Character.Delete(id);
        return RedirectToAction("Index");
      }
  }
} 
