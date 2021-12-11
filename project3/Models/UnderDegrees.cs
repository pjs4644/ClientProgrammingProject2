namespace Project3_Base_Code.Models
{
    public class UnderDegrees
    {
        public List<Undergraduate> undergraduate { get; set; }
       
    }

    public class Undergraduate
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> concentrations { get; set; }
    }

}