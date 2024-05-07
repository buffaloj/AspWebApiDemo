namespace DemoApi.Api.Validators
{
    /// <summary>
    /// This is a test model
    /// </summary>
    public class TestModel
    {
        /// <summary>
        /// An example name
        /// </summary>
        /// <example>John Doe</example>
        /// <shouldfail value=""/>
        public string Name { get; set; }

        /// <summary>
        /// An example address
        /// </summary>
        /// <example>123 Fake Street</example>
        /// <shouldfail value=""/>
        public string Address { get; set; }

        /// <summary>
        /// An example zip code
        /// </summary>
        /// <example>46231</example>
        /// <shouldfail value=""/>
        public string ZipCode { get; set; }

        /// <summary>
        /// An example date of birth
        /// </summary>
        /// <example>11/22/2001</example>
        /// <shouldfail value=""/>
        public DateTime DOB { get; set; }
    }
}
