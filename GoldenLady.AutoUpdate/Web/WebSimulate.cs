using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GoldenLady.AutoUpdate
{
    internal class WebSimulate
    {
        const int RequestTimeOut = 30 * 1000;
        private HttpMethod m_method;
        /// <summary>
        /// Http请求方式
        /// </summary>
        public HttpMethod Method
        {
            get { return m_method; }
            set { m_method = value; }
        }
        public WebSimulate()
        {
            m_method = HttpMethod.Get;
        }
        public WebSimulate(HttpMethod method)
        {
            m_method = method;
        }
        public Stream Simulate(string uri, out long dataLength)
        {
            return Simulate(uri, string.Empty, out dataLength);
        }
        public Stream Simulate(string uri, string data, out long dataLength)
        {
            try
            {
                Uri remoteUrl = new Uri(uri);
                return Simulate(remoteUrl, data, out dataLength);
            }
            catch (System.ArgumentNullException ex)
            {
                throw ex;
            }
            catch (System.UriFormatException x)
            {
                throw x;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public Stream Simulate(Uri uri, string data, out long dataLength)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                if (!string.IsNullOrWhiteSpace(data))
                {
                    request.Method = m_method == HttpMethod.Post ? "POST" : "GET";
                    request.ContentType = "application/x-www-form-urlencoded";
                    byte[] requestBytes = Encoding.UTF8.GetBytes(data);
                    request.ContentLength = requestBytes.Length;
                    request.Timeout = RequestTimeOut;
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(requestBytes, 0, requestBytes.Length);
                        requestStream.Close();
                    }
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                dataLength = response.ContentLength;
                return response.GetResponseStream();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public enum HttpMethod
        {
            Post,
            Get
        }
    }
}
