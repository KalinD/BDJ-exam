using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDJ.Data;
using BDJ.Models;
using BDJ.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BDJ.Controllers
{
    public class TrainController : Controller
    {
        private readonly ITrainService trainService;

        public TrainController(ITrainService trainService)
        {
            this.trainService = trainService;
        }

        public IActionResult Index()
        {
            TrainsIndexViewModel model = new TrainsIndexViewModel()
            {
                Trains = trainService.GetAll().Select(t => new TrainIndexViewModel()
                {
                    Capacity = t.Capacity,
                    IsFast = t.Type == "Fast",
                    Number = t.Number,
                    TrainId = t.Id
                }).ToList()
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            trainService.Delete(trainService.GetById(id));

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(TrainCreateViewModel model) { 
            Train train = new Train() { 
                Capacity = model.Capacity,
                Number = model.Number,
                Type = model.IsFast ? "Fast" : "Normal"
            };

            trainService.Create(train);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Guid id) {
            Train train = trainService.GetById(id);
            var model = new TrainEditViewModel() { 
                Capacity = train.Capacity,
                IsFast = train.Type == "Fast" ? true : false,
                Number = train.Number
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(TrainEditViewModel model) { 
            Train train = new Train() { 
                Capacity = model.Capacity,
                Id = model.Id,
                Number = model.Number,
                Type = model.IsFast ? "Fast" : "Normal"
            };

            trainService.Update(train);

            return RedirectToAction("Index");
        }
    }
}