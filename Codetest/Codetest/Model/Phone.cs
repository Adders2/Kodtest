namespace Codetest.Model
{
    public class Phone
    {
        public string? MobileNumber { get; set; }
        public string? LandlineNumber { get; set; }

        public Phone()
        {
            
        }

        public Phone(List<string> parsedRowValues)
        {
            MobileNumber = parsedRowValues[0];
            LandlineNumber = parsedRowValues.ElementAtOrDefault(1);
        }
    }
}
