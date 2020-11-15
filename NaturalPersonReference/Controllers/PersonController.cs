using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.Factories;
using NaturalPersonReference.Models.Paging;
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

        // GET: PersonController/List/n
        public ActionResult List(int pageNumber, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var persons = _personModelFactory.PreparePersonListModel(pageNumber, searchString);           
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
            var personAdded = _personService.CreatePerson(person);
            return RedirectToAction(nameof(Details), new { model.Id });
        }

        [HttpPost]
        public ActionResult Edit(PersonModel model)
        {
            var person = _mapper.Map<Person>(model);
            _personService.UpdatePerson(person);

            var personModel = _personModelFactory.PreparePersonModel(person);
            return RedirectToAction(nameof(Details), new { model.Id });
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _personService.DeletePerson(id);
            return RedirectToAction(nameof(List));
        }
    }
}
