using One.Services.API.Gateway.Controllers.Suite.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;


namespace One.Services.API.Gateway
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:9091");
            config.MapHttpAttributeRoutes();

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                var ct = new CancellationToken();
                server.OpenAsync().Wait();
                StartTimer(ct);
                Console.WriteLine("Server is started...");
                while (Console.ReadKey().Key != ConsoleKey.Escape)
                {

                }
            }
        }

        public static async void StartTimer(CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                do
                {
                    using (SecundarioDataContext secundario = new SecundarioDataContext())
                    using (ParadiseDataContext paradise = new ParadiseDataContext())
                    {
                        var query = from x in paradise.MESAPTOVTA where x.MesaPtoId == "RES" & x.MesaEstado == 'O' select x;

                        foreach (var table in query)
                        {
                            var voucherQuery = from x in secundario.Pension where x.Operation == table.MesaTranId select x;

                            short entradas = 0, principal = 0, postre = 0, merienda = 0;

                            GASTOS operation = paradise.GASTOS.Where(x => x.GtoTranId == table.MesaTranId).Single();

                            foreach (var voucher in voucherQuery)
                            {
                                switch (voucher.Comida)
                                {
                                    case "Almuerzo o Cena":
                                        entradas += Convert.ToInt16(voucher.Cantidad.Value);
                                        principal += Convert.ToInt16(voucher.Cantidad.Value);
                                        postre += Convert.ToInt16(voucher.Cantidad.Value);
                                        break;
                                    case "Merienda":
                                        merienda += Convert.ToInt16(voucher.Cantidad.Value);
                                        break;
                                }
                            }

                            var operationDetailQuery = from x in paradise.GASTOS1
                                                       where x.GtoTranId == table.MesaTranId & x.GtoLinCantidad == 1
                                                       select x;

                            var operationDetailQuery_Buffet = from x in operationDetailQuery
                                                              join y in paradise.ARTICULOS on x.GtoLinArtId equals y.ArtId
                                                              where y.ArtSitConId == 50 & x.GtoLinEliminaSupervicion == 'S'
                                                              select x;
                            var operationDetailQuery_Entradas = from x in operationDetailQuery
                                                                join y in paradise.ARTICULOS on x.GtoLinArtId equals y.ArtId
                                                                where y.ArtSitConId == 1 & x.GtoLinEliminaSupervicion == 'S'
                                                                select x;
                            var operationDetailQuery_Principales = from x in operationDetailQuery
                                                                   join y in paradise.ARTICULOS on x.GtoLinArtId equals y.ArtId
                                                                   where y.ArtSitConId == 2 & x.GtoLinEliminaSupervicion == 'S'
                                                                   select x;
                            var operationDetailQuery_Postres = from x in operationDetailQuery
                                                               join y in paradise.ARTICULOS on x.GtoLinArtId equals y.ArtId
                                                               where y.ArtSitConId == 3 & x.GtoLinEliminaSupervicion == 'S'
                                                               select x;

                            foreach (var lin in operationDetailQuery_Buffet)
                            {
                                if (entradas > 0 & principal > 0 & postre > 0)
                                {
                                    if (lin.GtoLinDesId != 999)
                                    {
                                        lin.GtoLinDesId = 999;
                                        lin.GtoLinObsDescuento = "Descuento realizado automáticamente por iGS";
                                        lin.GtoLinImpTotal = 0;
                                        lin.GtoLinTotSImp = 0;
                                    }

                                    entradas--;
                                    principal--;
                                    postre--;
                                }
                            }
                            foreach (var lin in operationDetailQuery_Entradas)
                            {
                                if (entradas > 0)
                                {
                                    if (lin.GtoLinDesId != 999)
                                    {
                                        lin.GtoLinDesId = 999;
                                        lin.GtoLinObsDescuento = "Descuento realizado automáticamente por iGS";
                                        lin.GtoLinImpTotal = 0;
                                        lin.GtoLinTotSImp = 0;
                                    }

                                    entradas--;
                                }
                            }
                            foreach (var lin in operationDetailQuery_Principales)
                            {
                                if (principal > 0)
                                {
                                    if (lin.GtoLinDesId != 999)
                                    {
                                        lin.GtoLinDesId = 999;
                                        lin.GtoLinObsDescuento = "Descuento realizado automáticamente por iGS";
                                        lin.GtoLinImpTotal = 0;
                                        lin.GtoLinTotSImp = 0;
                                    }

                                    principal--;
                                }
                            }
                            foreach (var lin in operationDetailQuery_Postres)
                            {
                                if (postre > 0)
                                {
                                    if (lin.GtoLinDesId != 999)
                                    {
                                        lin.GtoLinDesId = 999;
                                        lin.GtoLinObsDescuento = "Descuento realizado automáticamente por iGS";
                                        lin.GtoLinImpTotal = 0;
                                        lin.GtoLinTotSImp = 0;
                                    }

                                    postre--;
                                }
                            }

                            decimal? GtoCabTotSImpuesto = 0;
                            decimal? GtoCabTotGeneral = 0;
                            decimal? GtoCabImpuesto = 0;

                            foreach (var lin in operationDetailQuery)
                            {
                                GtoCabTotSImpuesto += lin.GtoLinTotSImp;
                                GtoCabTotGeneral += lin.GtoLinImpTotal;
                            }

                            GtoCabImpuesto = GtoCabTotGeneral - GtoCabTotSImpuesto;

                            if (operation.GtoCabTotSImpuesto != GtoCabTotSImpuesto)
                                operation.GtoCabTotSImpuesto = GtoCabTotSImpuesto;
                            if (operation.GtoCabTotGeneral != GtoCabTotGeneral)
                                operation.GtoCabTotGeneral = GtoCabTotGeneral;
                            if (operation.GtoCabImpuesto != GtoCabImpuesto)
                                operation.GtoCabImpuesto = GtoCabImpuesto;

                            paradise.SubmitChanges();
                        }
                    }

                    using (SecundarioDataContext secundario = new SecundarioDataContext())
                    using (ParadiseDataContext paradise = new ParadiseDataContext())
                    {
                        var query = from x in secundario.Pension
                                    where x.FechaUso >= DateTime.Now.Date.AddHours(-2) & x.Operation.HasValue
                                    select x;

                        foreach (var voucher in query)
                        {
                            if(paradise.GASTOS.Where(x=> x.GtoTranId == voucher.Operation.Value).SingleOrDefault() == default(GASTOS))
                            {
                                voucher.Usado = null;
                                voucher.FechaUso = null;
                                voucher.Operation = null;

                                secundario.SubmitChanges();
                            }
                        }
                    }

                        await Task.Delay(10000, cancellationToken);
                } while (!cancellationToken.IsCancellationRequested);
            });

        }
    }
}
