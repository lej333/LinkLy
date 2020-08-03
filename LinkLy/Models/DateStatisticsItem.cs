namespace LinkLy.Models
{
    /// <summary>
    /// Model for basic statistics based on year and month ie area charts (clicks)
    /// TODO: interface implementation
    /// </summary>
    public class DateStatisticsItem
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Count { get; set; }
    }
}
