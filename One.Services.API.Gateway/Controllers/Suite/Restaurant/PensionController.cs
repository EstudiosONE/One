using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace One.Services.API.Gateway.Controllers.Suite.Restaurant
{
    [RoutePrefix("gateway/suite/restaurant/pension")]
    public class PensionController : ApiController
    {
        [Route("getvoucherinfo/{id}")]
        [HttpGet]
        public HttpResponseMessage GetVoucherInfo([FromUri]int id)
        {
            using (SecundarioDataContext secundario = new SecundarioDataContext())
            using (ParadiseDataContext paradise = new ParadiseDataContext())
            {
                var pensionData = (from x in secundario.Pension where x.Id == id select x).FirstOrDefault();
                if (pensionData == default(Pension)) return Request.CreateResponse(HttpStatusCode.NotFound);
                var reservaData = (from x in paradise.RESERVA where x.ResNro == pensionData.ResNro select x).FirstOrDefault();
                if (reservaData == default(RESERVA))
                    return Request.CreateResponse(HttpStatusCode.OK, new Voucher
                    {
                        Id = id,
                    });
                var habitacionData = (from x in paradise.HABITACION where x.HabNum == reservaData.ResHab select x).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, new Voucher
                {
                    Id = id,
                    Reservation = new Reservation
                    {
                        Id = reservaData.ResNro.ToString(),
                        Room = new Room
                        {
                            Id = habitacionData.HabNum,
                            Name = habitacionData.HabNom.TrimEnd(' ')
                        },
                        CheckIn = reservaData.ResFecEnt.Value,
                        CheckOut = reservaData.ResFecSal.Value
                    }
                });

            }
        }

        [Route("usevoucher/{id}/{operation}")]
        [HttpPost]
        public HttpResponseMessage UseVoucher([FromUri]int id, [FromUri]int? operation, [FromBody]string vc)
        {
            using (SecundarioDataContext secundario = new SecundarioDataContext())
            using (ParadiseDataContext paradise = new ParadiseDataContext())
            {
                var vouchers = from x in secundario.Pension where x.Id == id select x;
                if (vouchers.Count() == 0 || vouchers == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                foreach (var voucher in vouchers)
                {
                    if (voucher.Nro != vc) return Request.CreateResponse(HttpStatusCode.BadRequest);
                    if (voucher.ResNro.HasValue)
                    {
                        var reserva = paradise.RESERVA.Where(x => x.ResNro == voucher.ResNro).SingleOrDefault();
                        if (reserva == default(RESERVA)) return Request.CreateResponse(HttpStatusCode.BadRequest);
                        else
                        {
                            if (reserva.ResFecEnt.Value.Date > DateTime.Now.Date) return Request.CreateResponse(HttpStatusCode.BadRequest);
                            if (reserva.ResFecSal.Value.Date < DateTime.Now.Date) return Request.CreateResponse(HttpStatusCode.BadRequest);
                        }
                    }
                    if (voucher.Usado.HasValue) if (voucher.Usado.Value) return Request.CreateResponse(HttpStatusCode.Gone);
                    voucher.Usado = true;
                    voucher.FechaUso = DateTime.Now;
                    voucher.Operation = operation;
                }

                secundario.SubmitChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }


        }

        public class Voucher
        {
            public int Id { get; set; }
            public Reservation Reservation { get; set; }
        }
        public class Reservation
        {
            public string Id { get; set; }
            public Room Room { get; set; }
            public DateTime CheckIn { get; set; }
            public DateTime CheckOut { get; set; }
            public People Holder { get; set; }
        }
        public class Room
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class People
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string SecondName { get; set; }
            public string Surname { get; set; }
            public string SecondSurname { get; set; }
            public DateTime Birthday { get; set; }
        }
    }
}
