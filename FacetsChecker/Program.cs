using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FacetsChecker
{
    class Program
    {
        public static int count =0;
        public static int downloadCount = 0;
        private static int downloadProcessCount =0;

        static void Main(string[] args)
        {
            RunFacetsCheckerAsync();
            Console.Read();
            
        }

        private static async Task RunFacetsCheckerAsync()
        {
            List<ESDataModel> jsonProxyObject = GetJsonObjectList();
            List<string> requestUrls = GetRequestUrls(jsonProxyObject);
            int FacetsPresenceCount = await FacetsPresenceChecker(requestUrls);

            Console.WriteLine("total : "+requestUrls.Count);
            Console.WriteLine("facets present in : "+ FacetsPresenceCount);
            Console.WriteLine("percentage : "+(requestUrls.Count/FacetsPresenceCount));
        }

        private static async Task<int> FacetsPresenceChecker(List<string> requestUrls)
        {
            int facetCount = 0;
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (var url in requestUrls)
            {
                tasks.Add(DownloadRequestString(url));
                Console.WriteLine(downloadCount++);
            }

            var results = await Task.WhenAll(tasks);
            foreach (var item in results)
            {
                facetCount = (CheckPresence(item)) ? facetCount++ : facetCount;
            }
            return facetCount;
        }

        private static async Task<string> DownloadRequestString(string url)
        {
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    string temp = await client.GetStringAsync(url);
                    temp = "[" + temp + "]";
                    return temp;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    Console.WriteLine("string is processed : " + downloadProcessCount++);
                }
            }
        }

        private static bool CheckPresence(string jsonData)
        {
            try
            {
                var responseModel = JsonConvert.DeserializeObject<List<RequestModel>>(jsonData);
                if (responseModel[0].facets != null) return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.WriteLine(count++);
            }
            return false;
        }

        private static List<string> GetRequestUrls(List<ESDataModel> jsonObjects)
        {
            List<string> requestStringList = new List<string>();
            var hitList = jsonObjects[0].responses[0].hits.hits;
            foreach(var item in hitList)
            {
                requestStringList.Add(item._source.request);
            }
            return requestStringList;
        }

        private static List<ESDataModel> GetJsonObjectList()
        {
            using (StreamReader r = new StreamReader("ESData.json"))
            {
                string applicationJson = r.ReadToEnd();
                applicationJson = "[" + applicationJson + "]";
                try
                {
                    return JsonConvert.DeserializeObject<List<ESDataModel>>(applicationJson);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
