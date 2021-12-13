using System.Net.Http.Headers;
using System.Text.Json;
using Project3_Base_Code.Models;

namespace Project3_Base_Code.Services
{
    public class GetDegrees : IGetDegrees
    {
         public async Task<List<Degrees>>GetAllDegrees()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/degrees/undergraduate", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonSerializer.Deserialize<Dictionary<string, List<Degrees>>>(data);

                    List<Degrees> underdegreeList = new List<Degrees>();

                    foreach (KeyValuePair<string, List<Degrees>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            underdegreeList.Add(item);
                        }
                    }

                    return underdegreeList;
                }

                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Degrees> underdegreeList = new List<Degrees>();
                    return underdegreeList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Degrees> underdegreeList = new List<Degrees>();
                    return underdegreeList;
                    //return "Exception"; ;
                }

                /*try
                {
                    HttpResponseMessage response = await client.GetAsync("api/people/degrees/graduate", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonSerializer.Deserialize<Dictionary<string, List<GetDegrees>>>(data);

                    List<Degrees> graddegreeList = new List<Degrees>();

                    foreach (KeyValuePair<string, List<Degrees>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            graddegreeList.Add(item);
                        }
                    }

                    return graddegreeList;
                }

                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Degrees> graddegreeList = new List<Degrees>();
                    return graddegreeList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Degrees> graddegreeList = new List<Degrees>();
                    return graddegreeList;
                    //return "Exception"; ;
                }*/
            }
        }
    }
}
