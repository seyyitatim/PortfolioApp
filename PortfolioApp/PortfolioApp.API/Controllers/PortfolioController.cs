using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Core.Services;
using PortfolioApp.Entity.Request;

namespace PortfolioApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private IPortfolioService _portfolioService { get; set; }

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("get-portfolios")]
        public async Task<IActionResult> GetPortfolios()
        {
            return Ok(await _portfolioService.GetPortfolios());
        }

        [HttpGet("get-salable-codes")]
        public async Task<IActionResult> GetSalableCodesAsync()
        {
            return Ok(await _portfolioService.GetSalableCodes());
        }

        [HttpPost("buying-currency")]
        public async Task<IActionResult> BuyingCurrencyAsync(BuyCurrencyRequest request)
        {
            return _portfolioService.BuyCurrencyAsync(request).Result.IsSucces ? Ok(request) : BadRequest();
        }

        [HttpPost("selling-currency")]
        public async Task<IActionResult> SellingCurrencyAsync(SellCurrencyRequest request)
        {
            return _portfolioService.SellCurrency(request).Result.IsSucces ? Ok(request) : BadRequest();
        }


        [HttpDelete("reset")]
        public async Task<IActionResult> ResetAsync()
        {
            await _portfolioService.Reset();
            return Ok();
        }
    }
}
