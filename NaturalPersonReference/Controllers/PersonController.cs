using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.Factories;
using NaturalPersonReference.Models.Person;
using NaturalPersonReference.Services.Persons;

namespace NaturalPersonReference.Controllers
{
    public class PersonController : Controller
    {
        private IPersonModelFactory _personModelFactory;
        private IMapper _mapper;
        private IPersonService _personService;

        public PersonController(IPersonModelFactory personModelFactory, IMapper mapper, IPersonService personService)
        {
            _personModelFactory = personModelFactory;
            _mapper = mapper;
            _personService = personService;
        }
        // GET: PersonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonController/List/
        public ActionResult List()
        {
            var persons = _personModelFactory.PreparePersonListModel();
            return View(persons);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            var person = _personService.Get(id);
            if (person == null)
                return RedirectToAction("List");

            var model = _personModelFactory.PreparePersonModel(person);

            return View(model);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            PersonModel model = _personModelFactory.PreparePersonModel();
            return View(model);
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonModel model)
        {
            var person = _mapper.Map<Person>(model);
            _personService.CreatePerson(person);
            return Json("1213");
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
