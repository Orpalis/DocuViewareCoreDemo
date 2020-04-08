using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;


namespace DocuViewareCoreDemo
{
    public static class Globals
    {
        public const string SERVEUR_URI = "https://passportpdfapi.com";
        public const string API_KEY = "";

        public static string BuildDocuViewareControlSessionID(HttpContext httpContext, string clientID)
        {
            if (httpContext.Session.GetString("DocuViewareInit") == null)
            {
                httpContext.Session.SetString("DocuViewareInit", "true");
            }

            return httpContext.Session.Id + clientID;
        }


        public static List<string>  GetDocuViewareLocale(HttpRequest request)
        {
            List<string> locales = new List<string>();
          
            if (request != null)
            {
                IList<StringWithQualityHeaderValue> acceptLanguage = request.GetTypedHeaders().AcceptLanguage;

                if (acceptLanguage != null)
                {
                    foreach (StringWithQualityHeaderValue language in acceptLanguage)
                    {
                        locales.Add(language.Value.Value);
                    }
                }
            }

            return locales;
        }
    }
}