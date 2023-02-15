using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IListBL
    {
        public ListEntity AddList(ListModel listModel);
        public bool DeleteList(long listId);
        public IEnumerable<ListEntity> GetAllList();

        public ListEntity UpdateList(ListEntity list);
    }
}
