using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evita_distributed.Models
{
    public class FbLikesModel
    {


        public List<Datumlk> data { get; set; }

        public Paging paging { get; set; }
    }

    public partial class Datumlk
    {

        public string name { get; set; }


        public string id { get; set; }


        public string created_time { get; set; }
    }

    
}

   
