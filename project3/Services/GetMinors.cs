using System.Net.Http.Headers;
using System.Text.Json;
using Project3_Base_Code.Models;

namespace Project3_Base_Code.Services
{
    public class GetMinors : IGetMinors
    {
        public async Task<List<Minor>> GetAllMinor()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/minors", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonSerializer.Deserialize<Dictionary<string, List<Minor>>>(data);

                    List<Minor> minorList = new List<Minor>();

                    foreach (KeyValuePair<string, List<Minor>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            minorList.Add(item);
                        }
                    }

                    return minorList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Minor> minorList = new List<Minor>();
                    return minorList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Minor> minorList = new List<Minor>();
                    return minorList;
                    //return "Exception"; ;
                }
            }

        }
    }
}
