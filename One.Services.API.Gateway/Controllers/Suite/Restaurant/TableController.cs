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
    [RoutePrefix("gateway/suite/restaurante/table")]
    public class TableController : ApiController
    {
        [Route("getactivetables")]
        [HttpGet]
        public HttpResponseMessage GetActiveTables()
        {
            List<Table> Tables = new List<Table>();

            using (SecundarioDataContext secundario = new SecundarioDataContext())
            using (ParadiseDataContext paradise = new ParadiseDataContext())
            {
                var query = from x in paradise.MESAPTOVTA where x.MesaPtoId == "RES" & x.MesaEstado == 'O' select x;

                if (query == null || query.Count() == 0) return Request.CreateResponse(HttpStatusCode.NotFound);

                foreach (var table in query)
                {


                    Tables.Add(new Table
                    {
                        TableNumber = table.MesaId,
                        TableName = table.MesaDsc.TrimEnd(' '),
                        TableType = Table.ParseTableType(table.MesaTipo.Value),
                        Consumers = table.MesaCubiertos.Value,
                        State = Table.ParseState(table.MesaEstado.Value),
                        Operation = new Operation()
                        {

                        }
                    });
                }

                return Request.CreateResponse(HttpStatusCode.OK, Tables);
            }
        }

        class Table
        {
            public int TableNumber { get; set; }
            public string TableName { get; set; }
            public TableTypeNames TableType { get; set; }
            public short Consumers { get; set; }
            public StateNames State { get; set; }
            public Operation Operation { get; set; }

            public static TableTypeNames ParseTableType(object value)
            {
                switch (value)
                {
                    case 1:
                        return TableTypeNames.square;
                    case 2:
                        return TableTypeNames.rectangular;
                    case 3:
                        return TableTypeNames.round;
                    case 4:
                        return TableTypeNames.oval;
                    case 'C':
                        return TableTypeNames.square;
                    case 'E':
                        return TableTypeNames.rectangular;
                    case 'R':
                        return TableTypeNames.round;
                    case 'O':
                        return TableTypeNames.oval;
                    default:
                        throw new ArgumentException("El argumento no pertenece a la lista de argumentos válidos. Argumentos válidos: 1, 2, 3, 4, C, E, R, O");
                }
            }

            public static StateNames ParseState(object value)
            {
                switch (value)
                {
                    case 0:
                        return StateNames.free;
                    case 1:
                        return StateNames.occupied;
                    case 'D':
                        return StateNames.free;
                    case 'O':
                        return StateNames.occupied;
                    default:
                        throw new ArgumentException("El argumento no pertenece a la lista de argumentos válidos. Argumentos válidos: 0, 1, D, O");
                }
            }

            public enum TableTypeNames
            {
                square = 1,
                rectangular = 2,
                round = 3,
                oval = 4
            }

            public enum StateNames
            {
                free = 0,
                occupied = 1
            }
        }
        class Operation
        {

        }
    }
}
