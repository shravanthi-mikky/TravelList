using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IMemberBL
    {
        public List<MemberModel> RetriveMembers(long ListId, string place);
    }
}
