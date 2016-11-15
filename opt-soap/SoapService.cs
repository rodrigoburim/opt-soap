using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SoapWithOptionalRequestParam
{
    class SoapService
    {
        public string Execute(string xml, string url)
        {
            HttpWebRequest request = SoapRequest(url);
            XmlDocument envelope = new XmlDocument();

            envelope.LoadXml(xml);

            using (Stream stream = request.GetRequestStream())
            {
                envelope.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        //TODO: create a model? for header, content-type, accept and method @rburim
        public HttpWebRequest SoapRequest(string url)
        {
	        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); 
	        request.Headers.Add(@"SOAP:Action"); 
	        request.ContentType = "text/xml;charset=\"utf-8\""; 
	        request.Accept = "text/xml"; 
	        request.Method = "POST"; 
	        return request; 
        }
    }
}
