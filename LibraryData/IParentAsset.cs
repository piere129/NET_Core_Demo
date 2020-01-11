using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IParentAsset
    {
        IEnumerable<Parent> GetAll();
        Parent GetById(int id);
        void Add(Parent parent);
        string GetFullName(int id);
        string GetAddress(int id);
        string GetTelephoneNumber(int id);
        IEnumerable<Child> GetChildrenOfParent(int id);
        IEnumerable<Item> GetItemsOfParent(int id);
    }
}
