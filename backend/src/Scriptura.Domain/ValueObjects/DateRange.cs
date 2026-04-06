namespace Scriptura.Domain.ValueObjects
{
    public record DateRange
    {
        public int? StartYear { get; init; }
        public int? EndYear { get; init; }

        public DateRange(int? startYear, int? endYear)
        {
            if (startYear.HasValue && endYear.HasValue && startYear > endYear)
                throw new ArgumentException("Start year cannot be greater than end year.");

            StartYear = startYear;
            EndYear = endYear;
        }
    }
}
