using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace XamBodyFit
{
    public class ServerCommunication
    {
        public static string GetAuthKey()
        {
            string result;
            RootObject rootObject;
            try
            {
                Device device = new Device();
                device.GetDeviceId();
                string inputJson = "{\"deviceid\":\"" + device.Id + "\"}";
                var tempJson = Initiate(device.Id, AppConfig.URL_INITIALIZE, inputJson);
                rootObject = JsonConvert.DeserializeObject<RootObject>(tempJson);
                AppConfig appConfig = new AppConfig(rootObject.authtoken);
                result = "INFO:" + rootObject.authtoken.ToString();
            }
            catch (Exception exception)
            {
                result = "EXCEPTION:" + exception.Message.ToString();
            }
            return result;
        }
        public static string Initiate(string deviceId, string url, string inputJson)
        {
            string result;
            WebRequest httpWebRequest = WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(inputJson);
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            return result;
        }

        public static string ServerCallWebRequest(string url, string inputJson)
        {
            string result;
            WebRequest httpWebRequest = WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 10000;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(inputJson);
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            return result;
        }

        private void JsonKeyValue(string tempJson)
        {
            //JObject parsed = JObject.Parse(tempJson);

            //foreach (var pair in parsed)
            //{
            //    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            //}
        }
    }
}