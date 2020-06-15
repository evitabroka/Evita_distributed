using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Evita_distributed.Client
{
    public enum HttpVerb { GET, POST }
    public class Restclient
    {


  
        
                public String endpoint { get; set; }


                public Restclient()
                {
                    this.endpoint = string.Empty;
                }
                public String Request(HttpVerb httpMethod, Dictionary<string, string> headers)
                {
                    string strResponseValue = string.Empty;


                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(endpoint);


                    request.Method = httpMethod.ToString();


                    //for each header in our list (dictionary) headers
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }





                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new ApplicationException($"Error Code: {response.StatusCode}");
                        }


                        using (Stream responseStream = response.GetResponseStream())
                        {
                            if (responseStream != null)
                            {
                                using (StreamReader reader = new StreamReader(responseStream))
                                {
                                    strResponseValue = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                    return strResponseValue;
                }
        }
    }








