using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using RepositoryLayer.TravelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class ListRL : IListRL
    {
        private readonly TravelsContext context;
        private readonly IConfiguration Iconfiguration;
        public ListRL(TravelsContext context, IConfiguration Iconfiguration)
        {
            this.context = context;
            this.Iconfiguration = Iconfiguration;
        }

        public ListEntity AddList(ListModel listModel)
        {
            try
            {
                ListEntity listEntity = new ListEntity();
                listEntity.Place = listModel.Place;
                listEntity.StartDate = listModel.StartDate;
                listEntity.EndDate = listModel.EndDate;
                listEntity.Duration = listModel.Duration;
                listEntity.Cost = listModel.Cost;
                listEntity.Members = listModel.Members;
                this.context.ListTable.Add(listEntity);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return listEntity;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ListEntity> GetAllList()
        {
            return context.ListTable.ToList();
        }

        public bool DeleteList(long listId)
        {
            try
            {
                var result = this.context.ListTable.FirstOrDefault(x => x.ListId == listId);
                context.Remove(result);
                int deletedList = this.context.SaveChanges();
                if (deletedList > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ListEntity UpdateList(ListModel list, int ListId)
        {
            try
            {
                ListEntity result = context.ListTable.Where(e => e.ListId == ListId).FirstOrDefault();

                if (result != null)
                {
                    //NoteEntity noteEntity = new NoteEntity();
                    result.Place = list.Place;
                    result.StartDate = list.StartDate;
                    result.EndDate = list.EndDate;
                    result.Duration = list.Duration;
                    result.Cost = list.Cost;
                    result.Members = list.Members;
                    context.ListTable.Update(result);
                    context.SaveChanges();
                    return result;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
