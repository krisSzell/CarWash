using CarWash.Core.UseCases.WorkDays;
using CarWash.Persistence;
using CarWash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarWash.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkDaysFactory _workDaysFactory;
        private readonly IWorkDaysFormatter _workDaysFormatter;

        public HomeController(
            IUnitOfWork unitOfWork, 
            IWorkDaysFactory factory, 
            IWorkDaysFormatter formatter)
        {
            _unitOfWork = unitOfWork;
            _workDaysFactory = factory;
            _workDaysFormatter = formatter;
        }

        public ActionResult Index()
        {
            var viewModel = new HomeIndexViewModel(_workDaysFactory, _workDaysFormatter);
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}