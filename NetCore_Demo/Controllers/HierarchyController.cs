using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using NetCore_Demo.Models;

namespace NetCore_Demo.Controllers
{
    public class HierarchyController : Controller
    {
        private IParentAsset _assets;

        public HierarchyController(IParentAsset assets)
        {
            this._assets = assets;
        }
        public IActionResult Index()
        {
            var parents = _assets.GetAll();
            var listingResult = parents.Select(listing => new HierarchyViewModel
            {
                Id = listing.Id,
                FirstName = listing.FirstName,
                LastName = listing.LastName,
                Address = listing.Address,
                TelephoneNumber = listing.TelephoneNumber,
                children = listing.Children
            });
            return View(listingResult);
        }

        public IActionResult Detail(int id)
        {
            var parent = _assets.GetById(id);
            var listingResult = new HierarchyDetailViewModel
            {
                Id = parent.Id,
                FirstName = parent.FirstName,
                LastName = parent.LastName,
                Address = parent.Address,
                TelephoneNumber = parent.TelephoneNumber,
                children = parent.Children
            };
            return View(listingResult);
        }

        public IActionResult Edit(int id)
        {
            var parent = _assets.GetById(id);
            var listingResult = new HierarchyDetailViewModel
            {
                Id = parent.Id,
                FirstName = parent.FirstName,
                LastName = parent.LastName,
                Address = parent.Address,
                TelephoneNumber = parent.TelephoneNumber,
                children = parent.Children
            };
            return View(listingResult);
        }

        [HttpPost]
        public IActionResult EditParent(int id, string address)
        {
            _assets.UpdateAddress(id, address);
            return RedirectToAction("Detail", new { id });
        }
    }
}