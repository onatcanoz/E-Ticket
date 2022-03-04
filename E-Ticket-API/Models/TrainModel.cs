using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticket_API.Models
{
    public class TrainModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VagonModel> Vagons { get; set; }
    }
}