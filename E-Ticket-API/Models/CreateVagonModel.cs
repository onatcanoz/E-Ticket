using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticket_API.Models
{
    public class CreateVagonModel
    {
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}