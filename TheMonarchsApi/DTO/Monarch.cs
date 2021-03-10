using Newtonsoft.Json;
using System;
using System.Linq;

namespace TheMonarchsApi.DTO
{
    public class Monarch
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nm")]

        public string Name { get; set; }
        [JsonProperty("cty")]
        public string City { get; set; }
        [JsonProperty("hse")]
        public string House { get; set; }
        [JsonProperty("yrs")]
        public string Years { get; set; }
        public int YearsRuled
        {
            get
            {
                var yearRange = Years.Split('-').Select(x =>
                {
                    int parsedYear;
                    var canParse = int.TryParse(x, out parsedYear);

                    if (canParse)
                    {
                        return parsedYear;
                    }
                    return DateTime.Now.Year;
                }).ToList();

                if (yearRange.Count == 1)
                {
                    return 1;
                }
                else
                {
                    return yearRange.Last() - yearRange.First();
                }
            }
        }
    }

}
