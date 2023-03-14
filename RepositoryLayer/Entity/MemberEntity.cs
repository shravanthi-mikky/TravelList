using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public class MemberEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Residence { get; set; }
        public string Gender { get; set; }
        public string Place { get; set; }
        public string Age { get; set; }

        [ForeignKey("user")]
        public long ListId { get; set; }
        [JsonIgnore]
        public virtual ListEntity ListTable { get; set; }//allow lazy loading,overide userentity class
    }
}
