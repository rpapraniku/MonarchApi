using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TheMonarchs.Services.Interfaces;
using TheMonarchsApi.DTO;

namespace TheMonarchs.Services
{
    public class FileService : IFileService
    {
        private readonly List<Monarch> _data;
        public FileService(IOptions<MonarchsJsonFile> options)
        {
            try
            {
                _data = JsonConvert.DeserializeObject<List<Monarch>>(options.Value.RawJsonData);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public int GetMonarchesTotalNumber()
        {
            return _data.Count;
        }
        public Monarch LongestMonarchRuled()
        {
            //with aggregate function we are comparing max with every next iteration and returning complete object
            var monarch = _data.Aggregate((max, next) => next.YearsRuled > max.YearsRuled ? next : max);
            return monarch;
        }

        public string LongestHouseRuled()
        {
            //group by House key, selector is complete x object, and we generate the projection { key, elements, sum }
            var groupByHouse = _data.GroupBy(x => x.House, x => x, (key, elements) => new { key, elements, sum = elements.Sum(x => x.YearsRuled) });
            var mostHouseRuled = groupByHouse.Aggregate((max, next) => next.sum > max.sum ? next : max);
            return mostHouseRuled.key;
        }

        public string MostCommonName()
        {
            //getting all names by spliting and take first()
            var firstNameList = _data.Select((x) => x.Name.Split(' ').First());
            //grouping by name and counting how many times is present
            var firstNameGrouped = firstNameList.GroupBy(key => key, name => name, (name, elements) => new { name, count = elements.Count() });
            //retriving max count name
            var maxName = firstNameGrouped.Aggregate((max, next) => next.count > max.count ? next : max);
            return maxName.name;
        }
    }
}
