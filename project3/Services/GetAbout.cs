using System.Net.Http.Headers;
using System.Text.Json;
using Project3_Base_Code.Models;


namespace Project3_Base_Code.Services
{
    public class GetAbout : IGetAbout
    {
        public async Task<List<AboutUs>> GetAllAbout()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/about", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonSerializer.Deserialize<Dictionary<string, List<AboutUs>>>(data);

                    List<AboutUs> aboutList = new List<AboutUs>();

                    foreach (KeyValuePair<string, List<AboutUs>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            aboutList.Add(item);
                        }
                    }

                    return aboutList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<AboutUs> aboutList = new List<AboutUs>();
                    return aboutList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    var msg = ex.Message;
                    List<AboutUs> aboutList = new List<AboutUs>();
                    return aboutList;
                    //return "Exception"; ;
                }
            }

        }
    }
}
