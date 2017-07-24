using CheckIT.Configuration.Interfaces;
using CheckIT.Core.Numbers.Interfaces;
using CheckIT.Parsing;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckIT.Api.Controllers
{
    [Route("api/[controller]")]
    public class NumberToStringController : ControllerBase
    {
        /// <summary>
        /// The locale for language
        /// </summary>
        private string Locale = "en-us";

        /// <summary>
        /// Gets or sets the volume loader.
        /// </summary>
        /// <value>
        /// The volume loader.
        /// </value>
        private IVolumeLoader VolumeLoader { get; set; }

        /// <summary>
        /// Gets or sets the factory.
        /// </summary>
        /// <value>
        /// The factory.
        /// </value>
        private IFactory Factory { get; set; }
        
        /// <summary>
        /// Gets or sets the money to string converter.
        /// </summary>
        /// <value>
        /// The money to string converter.
        /// </value>
        private MoneyToString MoneyToStringConverter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberToStringController" /> class.
        /// </summary>
        /// <param name="volumeLoader">The volume loader.</param>
        /// <param name="factory">The factory.</param>
        public NumberToStringController(IVolumeLoader volumeLoader, IFactory factory)
        {
            VolumeLoader = volumeLoader;
            Factory = factory;
            MoneyToStringConverter = new MoneyToString(volumeLoader, factory, Locale);
        }

        /// <summary>
        /// Moneys to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="locale">The locale.</param>
        /// <returns></returns>
        [HttpPost("Money")]
        public string MoneyToString([FromBody]decimal value, string locale = "en-us")
                    => MoneyToStringConverter.Parse(value);

        /// <summary>
        /// Moneys to string asynchronous.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="locale">The locale.</param>
        /// <returns></returns>
        [HttpPost("MoneyAsync")]
        public async Task<string> MoneyToStringAsync([FromBody]decimal value, string locale = "en-us")
                    => await MoneyToStringConverter.ParseAsync(value);

        /// <summary>
        /// Moneys to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="locale">The locale.</param>
        /// <returns></returns>
        [HttpGet("Money")]
        public string MoneyToString(string value, string locale = "en-us")
                    => MoneyToStringConverter.Parse(value);

        /// <summary>
        /// Moneys to string asynchronous.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="locale">The locale.</param>
        /// <returns></returns>
        [HttpGet("MoneyAsync")]
        public async Task<string> MoneyToStringAsync(string value, string locale = "en-us")
                    => await MoneyToStringConverter.ParseAsync(value);
    }
}
