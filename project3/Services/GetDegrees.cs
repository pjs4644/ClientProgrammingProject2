namespace Project3_Base_Code.Services
{
    public class GetDegrees : IGetDegrees
    {
         public async Task<List<Degrees>> GetAllDegrees()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/people/degrees", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonSerializer.Deserialize<Dictionary<string, List<Faculty>>>(data);

                    List<Degrees> degreeList = new List<Degrees>();

                    foreach (KeyValuePair<string, List<Degrees>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            degreeList.Add(item);
                        }
                    }

                    return degreeList;
                }

                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Degrees> degreeList = new List<Degrees>();
                    return degreeList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Degrees> degreeList = new List<Degrees>();
                    return degreeList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
