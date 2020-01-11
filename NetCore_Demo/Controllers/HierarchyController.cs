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
    }
}