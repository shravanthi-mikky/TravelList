using CommonLayer.Models;
using RepositoryLayer.Entity;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IListRL 
    {
        public ListEntity AddList(ListModel listModel);
        public bool DeleteList(long listId);
        public IEnumerable<ListEntity> GetAllList();

        public ListEntity UpdateList(ListEntity list);
    }
}
