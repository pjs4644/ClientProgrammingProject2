namespace Project3_Base_Code.Services
{
    public interface IGetDegrees
{
  Task<Dictionary<string, List<Degrees>>GetAllDegrees();
}
}
