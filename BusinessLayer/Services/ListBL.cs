using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class ListBL : IListBL
    {
        IListRL iListRL;

        public ListBL(IListRL iListRL)
        {
           this.iListRL = iListRL;
        }

        public ListEntity AddList(ListModel listModel)
        {
            try
            {
                return iListRL.AddList(listModel);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public bool DeleteList(long listId)
        {
            try
            {
                return iListRL.DeleteList(listId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ListEntity UpdateList(ListEntity list)
        {
            try
            {
                return iListRL.UpdateList(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ListEntity> GetAllList()
        {
            try
            {
                return iListRL.GetAllList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
