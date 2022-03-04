using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticket_API.Models
{
    public class VagonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int NumberOfFullSeats { get; set; }

        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }

        public int TrainId { get; set; }
        public TrainModel Train { get; set; }
    }
}