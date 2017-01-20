using RPGmvc.Models;
using RPGmvc.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPGmvc.Controllers
{
    public class CharactersController : Controller
    {
        private readonly CharacterRepository repo = new CharacterRepository();
        // For more about error handling, please go to 
        // http://www.codeguru.com/csharp/.net/net_asp/mvc/handling-errors-in-asp.net-mvc-applications.htm


        // GET: Characters
        public ActionResult Index()
        {
            List<Character> my_characs;
            try
            {
                my_characs = repo.Get().ToList();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(my_characs);
        }

        //ACCEDER AU FORMULAIRE DE CREATION
        //GET: /Characters/Create
        public ActionResult Create()
        {
            return View();
        }

        //TRAITER LE FORMULAIRE DE CREATION
        // POST: /Characters/Create/characterName/playerName
        [HttpPost]
        public ActionResult Create(string characterName, string playerName)
        {
            Character nouveauPerso;

            try
            {
                repo.Create(characterName, playerName);
                nouveauPerso = repo.Get(characterName);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View("Details", nouveauPerso);
        }

        // SEE DETAILS OF A CHARACTER
        // GET: /Characters/Details/Name
        public ActionResult Details(string name)
        {
            Character searched_character;
            try
            {
                searched_character = repo.Get(name);
            }
            catch(Exception ex){
                return View("Error");
            }

            return View(searched_character);
        }

        // ACCESS EDIT FORM
        // GET: /Characters/Edit/Name
        public ActionResult Edit(string name)
        {
            Character character_to_edit;
            try
            {
                character_to_edit = repo.Get(name);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

            return View(character_to_edit);

        }

        //TREAT EDIT FORM
        //POST: /Characters/Edit/name
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Character currentVersion)
        {
            Character toUpdate;
            try
            {
                toUpdate = repo.Get(currentVersion.characterName);
                repo.Update(toUpdate, currentVersion);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

            return View("Details", currentVersion);
        }

        //GET Non-job SKILLS FROM CHARACTER FOR EDIT
        //GET : /Characters/EditSkills/name
        public ActionResult EditSkills(string name)
        {
            Character to_edit;
            try
            {
                to_edit = repo.Get(name);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

            return View(to_edit);
        }

        //TREAT EDITSKILLS FORM
        //POST: /Characters/EditSkills/name
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSkills(Character currentVersion)
        {


            Character toUpdate;
            try
            {
                toUpdate = repo.Get(currentVersion.characterName);
                repo.UpdateSkills(toUpdate, currentVersion);
                toUpdate = repo.Get(toUpdate.characterName);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

            return View("Details", toUpdate);
        }

        //GET JOB SKILLS FROM CHARACTER FOR EDIT
        //GET : /Characters/EditJobSkills/name
        public ActionResult EditJobSkills(string name){
            Character to_edit;

            try{
                to_edit = repo.Get(name);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

            return View(to_edit);
        }

        //TREAT EDITSKILLS FORM
        //POST: /Characters/EditSkills/name
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJobSkills(Character currentVersion)
        {
            Character toUpdate;
            try
            {
                toUpdate = repo.Get(currentVersion.characterName);
                repo.UpdateSkills(toUpdate, currentVersion);
                toUpdate = repo.Get(toUpdate.characterName);
            }
            catch(Exception ex){
                return View("Error");
            }
            return View("Details", toUpdate);
        }

    }
}