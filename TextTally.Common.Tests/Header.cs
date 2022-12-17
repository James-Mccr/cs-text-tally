namespace TextTally.Common.Tests
{
    public class Header
    {
        public Header(string name, string[] values)
        {
            Name = name;
            Values = values;
        }

        public string Name { get; set; }
        public string[] Values { get; set; }
    }
}