using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarFinder
{
    abstract class GeneralCarFinder
    {
        public string StatusCode { get;  private set; }

        protected string AddParameterToUrl<T>(string url, string param, T value)
        {
            if (url.Contains("="))
            {
                return url + "&" + param + value;
            }
            return url + "?" + param + value;
        }



        protected string GetHtml(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentLength = 0;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StatusCode = response.StatusCode.ToString();
            
            if (StatusCode != "OK")
            {
                response.Close();
                return ("Response is not successful. "+ response.StatusCode.ToString() +" error"+response.StatusDescription);
            }
            else
            {
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string result = sr.ReadToEnd();
                sr.Close();
                response.Close();
                return result;
            }
                 
        }
    }
}
