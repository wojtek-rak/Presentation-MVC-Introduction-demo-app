using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FirstTestApp
{
    public static class GithubApi
    {
        public static string GetJson(string userName, string repostioryName)
        {
            string url = "https://api.github.com/repos/" + userName + "/" + repostioryName;
            String htmlString;
            try
            {
                HttpWebRequest httpprequest = WebRequest.Create(url) as HttpWebRequest;

                httpprequest.UserAgent = "userAgent";

                httpprequest.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)httpprequest.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    htmlString = reader.ReadToEnd();
                }
            }
            catch
            {
                htmlString = "404";
            }
            return ParseToJsonString(htmlString);
        }

        public static string ParseToJsonString(string htmlString)
        {
            if (htmlString == "404") return htmlString;
            JsonTextReader rs = new JsonTextReader(new StringReader(htmlString));
            //return ("Token: {0}, Value: {1}" + read.TokenType + read.Value);
            //read.Read();
            JObject o2 = (JObject)JToken.ReadFrom(rs);
            IList<string> keys = o2.Properties().Select(p => p.Name).ToList();
            StringBuilder output = new StringBuilder();
            output.Append("{\n");
            JToken value = "full_name";
            List<string> mylist = new List<string>(new string[] { "full_name", "mirror_url" , "description", "clone_url","language", "open_issues_count" ,"watchers",
                "created_at" });
            foreach (JProperty property in o2.Properties())
            {
                if (mylist.Any(s => property.Name.Contains(s)))
                {

                    if (property.Value.Type.ToString() == "Integer")
                    {

                        output.Append("\"").Append(property.Name).Append("\": ").Append(property.Value).Append(",\n");
                    }
                    else if (property.Value.Type.ToString() == "Null")
                    {
                        output.Append("\"").Append(property.Name).Append("\": null,\n");
                    }
                    else
                    {
                        output.Append("\"").Append(property.Name).Append("\": \"").Append(property.Value).Append("\",\n");
                    }

                }


            }
            var jsonResult = output.ToString().Remove(output.Length - 2) + "\n}";
            return jsonResult;
        }


    }
}
