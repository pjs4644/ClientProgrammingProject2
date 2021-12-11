namespace Project3_Base_Code.Services
{
    public interface IGetDegrees
    {
        Task<List<Degrees>> GetAllDegrees();
    }
}
