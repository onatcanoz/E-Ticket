using E_Ticket_API.Contexts;
using E_Ticket_API.Entities;
using E_Ticket_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace E_Ticket_API.Controllers
{
    public class TrainsController : ApiController
    {
        private readonly TrainsContext _db;

        public TrainsController()
        {
            _db = new TrainsContext();
        }

        [System.Web.Http.HttpGet]
        public TrainModel Get()
        {
            return _db.Trains.Select(m => new TrainModel()
            {
                Id = m.Id,
                Name = m.Name,

                Vagons = m.Vagons.Select(r => new VagonModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Capacity = r.Capacity,
                    NumberOfFullSeats = r.NumberOfFullSeats,
                    TrainId = r.TrainId
                }).ToList()
            }).FirstOrDefault();

        }


        [System.Web.Http.HttpPost]
        public string CreateTicket(CreateVagonModel vagonInfo)
        {

            var train = new List<TrainModel>()
            {
                _db.Trains.Select(m => new TrainModel()
                {
                Id = m.Id,
                Name = m.Name,

                Vagons = m.Vagons.Select(r => new VagonModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Capacity = r.Capacity,
                    NumberOfFullSeats = r.NumberOfFullSeats,
                    TrainId = r.TrainId
                    }).ToList()
                }).FirstOrDefault()
            };

            int kisiSayisi = vagonInfo.RezervasyonYapilacakKisiSayisi;
            string output = "";
            foreach (var item in train[0].Vagons)
            {
                int satilabilirKoltukSayisi = ((item.Capacity * 70) / 100) - item.NumberOfFullSeats;

                if (vagonInfo.KisilerFarkliVagonlaraYerlestirilebilir == false)
                {
                    if (satilabilirKoltukSayisi >= kisiSayisi)
                    {
                        output += "Vagon Adı: " + item.Name + "," + "Kişi Sayısı: " + kisiSayisi;
                        break;
                    }
                    else
                    {
                        output += "Vagonda yer yok.";
                        break;
                    }
                }
                else
                {
                    if (satilabilirKoltukSayisi >= kisiSayisi)
                    {
                        output += "Vagon Adı: " + item.Name + "," + "Kişi Sayısı: " + kisiSayisi + " ";
;
                        break;
                    }
                    else if(kisiSayisi >= satilabilirKoltukSayisi)
                    {
                        output += "Vagon Adı: " + item.Name + "," + "Kişi Sayısı: " + satilabilirKoltukSayisi + " ";
;
                        kisiSayisi = kisiSayisi - satilabilirKoltukSayisi;
                    }
                }

            }

           
            return output;
        }
    }
}