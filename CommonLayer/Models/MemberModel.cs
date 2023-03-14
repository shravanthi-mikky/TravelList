using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace CommonLayer.Models
{
    public class MemberModel
    {
        
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Residence { get; set; }
        public string Gender { get; set; }
        public string Place { get; set; }
        public string Age { get; set; }
    }
}
