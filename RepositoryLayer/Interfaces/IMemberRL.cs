using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IMemberRL
    {
        public List<MemberModel> RetriveMembers(long ListId, string place);
    }
}
