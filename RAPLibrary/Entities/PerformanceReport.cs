namespace RAPLibrary.Entities
{
    public class PerformanceReport
    {
        public string Category { get; set; }
        public List<(Entities.Researcher, float)> Researchers { get; set; } = new List<(Entities.Researcher, float)>();
    }

}
