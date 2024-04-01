using System;

namespace Pages.Helpers
{
    [AttributeUsage(AttributeTargets.Field)]
    public class LocationAttribute : Attribute
    {
        public string Location { get; private set; }

        public LocationAttribute(string usingValue)
        {
            Location = usingValue;
        }
    }
}
