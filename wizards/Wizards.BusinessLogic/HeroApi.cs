using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic
{
    public class HeroApi
    {

        public static void GetHeroName()
        {
            //try
            //{
            //    BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            //    binding.Name = "https://randomuser.me/api/";
            //    binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            //    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            //    binding.MaxReceivedMessageSize = 65536;

            //    EndpointAddress ea = new EndpointAddress("https://randomuser.me/api/");

            //    var ws = new ServiceReference3.OrlenWsSoapClient(binding, ea);
            //    var cred = new NetworkCredential("LotosB2BClient", "Nr6c3batMPB048X", "rafineria");
            //    ws.ClientCredentials.UserName.UserName = $"{cred.Domain}\\{cred.UserName}";
            //    ws.ClientCredentials.UserName.Password = cred.Password;
            //    ws.Open();
            //    var data = ws.GetTransportRequestsByDatesRange(new DateTime(2021, 12, 3), new DateTime(2021, 12, 3));
            //    foreach (var item in data)
            //    {
            //        Console.WriteLine($"{item.nr_zlec} | {item.data_zlec}");
            //    }
            //    ws.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            Console.WriteLine("Wciśnij dowolny przycisk, aby wrócić do poprzedniego okna.");
            Console.ReadKey();

        }
    }
}
