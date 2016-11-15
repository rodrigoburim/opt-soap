using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapWithOptionalRequestParam
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"">
               <soapenv:Header/>
               <soapenv:Body>
               </soapenv:Body>
            </soapenv:Envelope>";

            SoapService service = new SoapService();
            Console.WriteLine(service.Execute(xml, "http://url.com/wservice"));
            Console.ReadLine();
        }
    }
}
