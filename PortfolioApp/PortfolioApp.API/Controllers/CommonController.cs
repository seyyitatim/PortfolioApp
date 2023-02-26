using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Service.Utilities;

namespace PortfolioApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        [HttpGet("get-currency")]
        public IActionResult GetCurrency()
        {
            return Ok(CurrencyHelper.GetCurrency());
        }

        [HttpGet("get-currency-code")]
        public IActionResult GetCurrencyCode()
        {
            return Ok(CurrencyHelper.GetCurrencyCodes());
        }
    }
}
