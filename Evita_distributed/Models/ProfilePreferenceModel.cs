using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Evita_distributed.Models
{
    public class ProfilePreferenceModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]



        public int id { get; set; }
        public String userID { get; set; }
        public virtual ApplicationUser User { get; set; }



        public bool name { get; set; }
        public bool email { get; set; }



        public bool birthday { get; set; }
    }
}