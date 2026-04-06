namespace Scriptura.Domain.ValueObjects
{
    public record HistoricalDivision
    {
        public string? Governorate { get; set; }
        public string? County { get; set; }
        public string? Parish { get; set; }

        public HistoricalDivision(string governorate, string county, string parish)
        {
            if (string.IsNullOrWhiteSpace(governorate) &&
                string.IsNullOrWhiteSpace(county) &&
                string.IsNullOrWhiteSpace(parish))
            {
                throw new ArgumentException("At least one level of historical division must be provided.");
            }

            Governorate = governorate;
            County = county;
            Parish = parish;
        }
    }
}
