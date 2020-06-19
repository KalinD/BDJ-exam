using BDJ.Data;
using BDJ.Models;
using BDJ.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BDJ.Controllers
{
    public class LineController : Controller
    {
        private readonly ILineService lineService;
        private readonly ITrainService trainService;

        public LineController(ILineService lineService, ITrainService trainService)
        {
            this.lineService = lineService;
            this.trainService = trainService;
        }

        public IActionResult Index()
        {
            LinesIndexViewModel model = new LinesIndexViewModel()
            {
                Lines = lineService.GetAll().Select(l => new LineIndexViewModel()
                {
                    ArrivalTime = l.ArrivalTime.ToString("hh:mm"),
                    Date = l.Date.ToString("MM/dd/yyyy"),
                    Departure = l.Departure,
                    DepartureTime = l.DepartureTime.ToString("hh:mm"),
                    Destination = l.Destination,
                    TrainNumber = trainService.GetById(l.TrainId).Number,
                    LineId = l.Id
                }).ToList()
            };

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            LineCreateViewModel model = new LineCreateViewModel()
            {
                Trains = trainService.GetAll(),
                DepartureTime = DateTime.Now.Date,
                ArrivalTime = DateTime.Now.Date,
                Date = DateTime.Now.Date
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(LineCreateViewModel model)
        {
            Line line = new Line()
            {
                ArrivalTime = model.ArrivalTime,
                Departure = model.Departure,
                DepartureTime = model.DepartureTime,
                Destination = model.Destination,
                Train = trainService.GetById(model.TrainId),
            };
            lineService.Create(line);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Guid id)
        {
            Line line = lineService.GetById(id);
            var model = new LineEditViewModel()
            {
                ArrivalTime = line.ArrivalTime,
                Date = line.Date,
                Departure = line.Departure,
                DepartureTime = line.DepartureTime,
                Destination = line.Destination,
                TrainId = line.TrainId,
                Trains = trainService.GetAll(),
                LineId = line.Id
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(LineEditViewModel model)
        {
            Line line = new Line()
            {
                ArrivalTime = model.ArrivalTime,
                Date = model.Date,
                Departure = model.Departure,
                DepartureTime = model.DepartureTime,
                Destination = model.Destination,
                Id = model.LineId,
                TrainId = model.TrainId,
                Train = trainService.GetById(model.TrainId)
            };

            lineService.Update(line);

            return RedirectToAction("Index");
        }
        public IActionResult Search(string? searchString)
        {
            LineSearchViewModel model;
            if (searchString != null)
            {
                model = new LineSearchViewModel()
                {
                    Lines = lineService.GetAll().Where(l => l.Destination.Contains(searchString)
                        || l.Departure.Contains(searchString)
                        || l.DepartureTime.ToString().Contains(searchString)).Select(l => new Line()
                        {
                            ArrivalTime = l.ArrivalTime,
                            Date = l.Date,
                            Departure = l.Departure,
                            DepartureTime = l.DepartureTime,
                            Destination = l.Destination,
                            Train = trainService.GetById(l.TrainId),
                            Id = l.Id,
                            TrainId = l.TrainId
                        }).ToList()
                };
            }
            else
            {
                model = new LineSearchViewModel()
                {
                    Lines = lineService.GetAll().Select(l => new Line()
                    {
                        ArrivalTime = l.ArrivalTime,
                        Date = l.Date,
                        Departure = l.Departure,
                        DepartureTime = l.DepartureTime,
                        Destination = l.Destination,
                        Train = trainService.GetById(l.TrainId),
                        Id = l.Id,
                        TrainId = l.TrainId
                    }).ToList()
                };
            }
            return View(model);
        }
    }
}