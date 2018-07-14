using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace One.Tools.iGS.Restaurant.Pension
{
    class Program
    {
        static int voucher;
        static int vc;
        static int table;
        static int operation;

        static HttpClient client = new HttpClient();

        static Program()
        {
            client.BaseAddress = new Uri("http://192.168.2.12:9091/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        static void Main(string[] args)
        {
            PrintHeader();
        }

        static void PrintHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("=============================================================");
            Console.WriteLine("==                                                         ==");
            Console.WriteLine("==  iGS - Rimisol SA | Verificar Pension v: 18.07.14.0900  ==");
            Console.WriteLine("==                                                         ==");
            Console.WriteLine("=============================================================");
            Console.WriteLine("");
            GetVoucher();
        }

        static async void GetVoucher()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Voucher Nº: ");

            try
            {
                voucher = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                VoucherNotValid();
            }

            HttpResponseMessage response = client.GetAsync($"gateway/suite/restaurant/pension/getvoucherinfo/{voucher}").Result;

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    VoucherNotValid();
                    break;
                case System.Net.HttpStatusCode.InternalServerError:
                    ServerError();
                    break;
                case System.Net.HttpStatusCode.OK:
                    PrintVoucherInformation(await response.Content.ReadAsAsync<Voucher>());
                    break;
            }
        }

        static void PrintVoucherInformation(Voucher voucherData)
        {
            if (voucherData.Reservation != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("Información del Voucher:");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Chalet: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(voucherData.Reservation.Room.Name);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Check In: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(voucherData.Reservation.CheckIn.ToShortDateString().PadRight(16, ' '));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Check Out: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(voucherData.Reservation.CheckOut.ToShortDateString());
                Console.WriteLine("");

                if (voucherData.Reservation.CheckIn.Date > DateTime.Now.Date || voucherData.Reservation.CheckOut.Date < DateTime.Now.Date)
                {
                    VoucherNotValid("periodo");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("Información del Voucher:");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Voucher de pasante: ");
                Console.WriteLine("");
            }

            GetVC();
        }

        static void GetVC()
        {
            Console.Write("Ingrese código de verificación: ");

            try
            {
                vc = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                VCNotValid();
            }

            GetTable();
        }

        static async void GetTable()
        {
            Console.Write("Ingrese nº de mesa: ");

            try
            {
                table = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                VCNotValid();
            }

            HttpResponseMessage response = client.GetAsync($"gateway/suite/restaurante/table/gettable/{table}").Result;

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    TableNotValid();
                    break;
                case System.Net.HttpStatusCode.InternalServerError:
                    ServerError();
                    break;
                case System.Net.HttpStatusCode.OK:
                    var tableData = await response.Content.ReadAsAsync<Table>();
                    if (tableData.State == Table.StateNames.occupied) operation = tableData.Operation.Id;
                    else TableNotValid();
                    break;
            }

            response = client.PostAsJsonAsync<string>($"gateway/suite/restaurant/pension/usevoucher/{voucher}/{operation}", vc.ToString()).Result;

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    VCNotValid();
                    break;
                case System.Net.HttpStatusCode.InternalServerError:
                    ServerError();
                    break;
                case System.Net.HttpStatusCode.Gone:
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Voucher usado previamente!!!");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey(true);
                    PrintHeader();
                    break;
                case System.Net.HttpStatusCode.OK:
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ingresado correctamente.");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey(true);
                    PrintHeader();
                    break;
            }
        }

        static void VoucherNotValid(string error = "")
        {
            switch (error)
            {
                default:
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Debe ingresar un número de voucher válido");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey(true);
                    PrintHeader();
                    break;
                case "periodo":
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El voucher aun no es válido o está vencido");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey(true);
                    PrintHeader();
                    break;
            }
        }

        static void VCNotValid()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Debe ingresar código de verificación válido");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey(true);
            GetVC();
        }

        static void TableNotValid()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Debe ingresar un Nº de mesa válido y activo");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey(true);
            GetTable();
        }

        static void ServerError()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Debe ingresar un número de voucher válido");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey(true);
            PrintHeader();
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
            public int Id { get; set; }
        }
    }
}
