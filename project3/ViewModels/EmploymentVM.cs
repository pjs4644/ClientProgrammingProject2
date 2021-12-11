using Project3_Base_Code.Models;

namespace Project3_Base_Code.ViewModels
{
    public class EmploymentVM
    {
        public List<string> employerNames { get; set; }
        public List<string> DegreeStatistics { get; set; }
        public List<CoopInformation> coopInformation { get; set; }
        //public List<EmployerInformation> city { get; set; }
        //public List<EmployerInformation> startDate { get; set; }

    }
}
