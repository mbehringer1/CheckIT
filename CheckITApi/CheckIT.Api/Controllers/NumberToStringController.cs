using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIT.Api.Controllers
{
    [Route("api/[controller]")]
    public class NumberToStringController : ControllerBase
    {
        private string Locale = "en-us";
        private IVolumeLoader VolumeLoader { get; set; }
        private IFactory Factory { get; set; }
        private MoneyToString MoneyToStringConverter { get; set; }
        public NumberToStringController(IVolumeLoader volumeLoader, IFactory factory)
        {
            VolumeLoader = volumeLoader;
            Factory = factory;
            MoneyToStringConverter = new MoneyToString(volumeLoader, factory, Locale);
        }

        [HttpPost("Money")]
        public string MoneyToString([FromBody]decimal value, string locale = "en-us")
            => MoneyToStringConverter.Parse(value);

        [HttpPost("MoneyAsync")]
        public async Task<string> MoneyToStringAsync([FromBody]decimal value, string locale = "en-us")
            => await MoneyToStringConverter.ParseAsync(value);

        [HttpGet("Money")]
        public string MoneyToString(string value, string locale = "en-us")
            => MoneyToStringConverter.Parse(value);

        [HttpGet("MoneyAsync")]
        public async Task<string> MoneyToStringAsync(string value, string locale = "en-us")
            => await MoneyToStringConverter.ParseAsync(value);
    }
}
