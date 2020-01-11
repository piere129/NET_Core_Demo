using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class ParentAssetService : IParentAsset
    {

        // specific implementation of interface service, uses context to call query results
        private LibraryContext _context;

        public ParentAssetService(LibraryContext context) {
            this._context = context;
        }
        public void Add(Parent parent)
        {
            _context.Add(parent);
            _context.SaveChanges();
        }

        public string GetAddress(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parent> GetAll()
        {
            return _context.parents.Include(p => p.Children).Include(p => p.Items);
        }

        public Parent GetById(int id)
        {
            return _context.parents.Include(p => p.Children)
                .Include(p => p.Items)
                .FirstOrDefault(Parent => Parent.Id == id);
        }

        public IEnumerable<Child> GetChildrenOfParent(int id)
        {
            return _context.parents.Include(p=> p.Children).FirstOrDefault(p => p.Id == id).Children;
        }

        public string GetFullName(int id)
        {
            return _context.parents.FirstOrDefault(p => p.Id == id).FirstName + " " +
                _context.parents.FirstOrDefault(p => p.Id == id).LastName;
        }

        public IEnumerable<Item> GetItemsOfParent(int id)
        {
            return _context.parents.Include(p => p.Children).FirstOrDefault(p => p.Id == id).Items;
        }

        public string GetTelephoneNumber(int id)
        {
            return _context.parents.FirstOrDefault(p => p.Id == id).TelephoneNumber;
        }

        public void UpdateAddress(int id, string address)
        {
           var parent = GetById(id);
            parent.Address = address;
            _context.Update(parent);
            _context.SaveChanges();
        }
    }
}
