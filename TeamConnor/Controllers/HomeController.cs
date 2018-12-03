using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TeamConnor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public class HTTPClient
        {
            private const string LOGIN_ENDPOINT = "https://rest.tsheets.com/api/v1/";
            static HTTPClient()
            {
                // SF requires TLS 1.1 or 1.2
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            }

            const string WEBSERVICE_URL = "https://rest.tsheets.com/api/v1/";

            public String Query(string endpoint, string parameters)
            {
                String jsonResponse;
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL + endpoint + parameters);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("Authorization", "Bearer S.2__1f86e6a053b024b395a5cb4a6f11ad6221f756e0");
                }
                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        jsonResponse = sr.ReadToEnd();
                        return String.Format("{0}", jsonResponse);
                    }
                }
            }
        }
    }
}