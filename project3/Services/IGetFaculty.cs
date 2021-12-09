using Project3_Base_Code.Models;

namespace Project3_Base_Code.Services
{
    public interface IGetFaculty
    {
        Task<List<Faculty>> GetAllFaculty();
    }
}