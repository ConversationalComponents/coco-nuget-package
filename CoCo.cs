using System;
using System.Text; 
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json; 
using Newtonsoft.Json.Linq;



namespace CoCoSDK
{
    
 public class CoCoContext 
{
        public string action_name {get; set;}

        public string response {get; set;}

        public bool component_done {get; set;}
        public bool conmponent_failed {get; set;}
        
        public bool out_of_context {get; set;}
        public float confidence {get; set;}

        public float response_time {get; set;}

        public string vp3_last_handler_called {get; set;}

        public Dictionary<string, string> updated_context {get; set;} 
    }

public class CoCo 
{
        const string HubApiUrl = @"https://cocohub.ai/api";

        public CoCoContext Exchange(string ComponentId, string SessionId, string UserInput, Dictionary<string, string> Context=null) {
            

            string requestUrlFormat = "{0}/exchange/{1}/{2}";
            
            string requestUrl = string.Format(requestUrlFormat, HubApiUrl, ComponentId, SessionId);

            if(Context == null){
                Context = new Dictionary<string, string>();
            }

            string StringContext = JsonConvert.SerializeObject(Context, Formatting.Indented);

            HttpClient Client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            
            string contentFormat = "{{\"user_input\": \"{0}\", \"flatten_context\": true, \"context\":{1} }}";

            string content = string.Format(contentFormat, UserInput, StringContext);
            
            request.Content = new StringContent(content,
                                                Encoding.UTF8, 
                                                "application/json"); //CONTENT-TYPE header


            using(Task<HttpResponseMessage> Response = Client.SendAsync(request)){
                   using (HttpContent Content = Response.Result.Content) 
                   {
                       string stringResult = Content.ReadAsStringAsync().Result;
                       CoCoContext ResultContext = JsonConvert.DeserializeObject<CoCoContext>(stringResult);
                       
                       return ResultContext;

                   }
            }
        }
    }
    
}
