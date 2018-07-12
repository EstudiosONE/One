using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace One.Tools.iGS.Restaurant.Pension
{
    class Program
    {
        static int voucher;
        static int vc;

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
            Console.WriteLine("==  iGS - Rimisol SA | Verificar Pension v: 18.11.07.2000  ==");
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

            HttpResponseMessage response = client.PostAsJsonAsync<string>($"gateway/suite/restaurant/pension/usevoucher/{voucher}/0",vc.ToString()).Result;

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

        static void VoucherNotValid()
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

    }
}
