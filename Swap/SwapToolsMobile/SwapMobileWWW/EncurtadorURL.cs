using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using GoogleAPI.UrlShortener;

namespace SwapMobileWWW
{
    public class EncurtadorURL
    {
        public string LengthenUrl(string url)
        {
            string resultado = string.Empty;
            UrlResource client = new UrlResource();
            //client.Endpoint= new System.ServiceModel.Description.ServiceEndpoint(new Sy
            // Shorten url according the parameter below.
            var response = client.Insert(
                new ShortenRequest { LongUrl = url });

            // Print short url. Ex: http://goo.gl/sOme
            Console.WriteLine(response.Id);
            resultado = response.Id;
            // Print long url. Ex: http://gshortener.codeplex.com
            Console.WriteLine(response.LongUrl);
            return resultado;
        }
    }
}