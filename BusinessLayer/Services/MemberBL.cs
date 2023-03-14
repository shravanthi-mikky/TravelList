using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class MemberBL : IMemberBL
    {
        IMemberRL iMemberRL;

        public MemberBL(IMemberRL iMemberRL)
        {
            this.iMemberRL = iMemberRL;
        }

        public List<MemberModel> RetriveMembers(long ListId, string place)
        {
            try
            {
                return iMemberRL.RetriveMembers( ListId,place);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
