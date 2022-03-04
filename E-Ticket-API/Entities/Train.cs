using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticket_API.Entities
{
    public class Train
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Vagon> Vagons { get; set; } 

    }
}