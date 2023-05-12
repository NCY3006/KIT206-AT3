namespace RAP.Entities
{
    public class PerformanceReport
    {
        public string Category { get; set; }
        public List<(Entities.Researcher, int)> Researchers { get; set; } = new List<(Entities.Researcher, int)>();
    }

}
