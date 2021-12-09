using System.Net.Http.Headers;
using System.Text.Json;
using Project3_Base_Code.Models;

namespace Project3_Base_Code.Services
{
    public class GetFaculty : IGetFaculty
    {
        public async Task<List<Faculty>> GetAllFaculty()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/people/faculty", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonSerializer.Deserialize<Dictionary<string, List<Faculty>>>(data);

                    List<Faculty> facultyList = new List<Faculty>();

                    foreach (KeyValuePair<string, List<Faculty>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            facultyList.Add(item);
                        }
                    }

                    return facultyList;
                }

                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Faculty> facultyList = new List<Faculty>();
                    return facultyList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Faculty> facultyList = new List<Faculty>();
                    return facultyList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
