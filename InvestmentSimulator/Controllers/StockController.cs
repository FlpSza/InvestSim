using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
	private readonly AlphaVantageService _alphaVantageService;

	public StockController(AlphaVantageService alphaVantageService)
	{
		_alphaVantageService = alphaVantageService;
	}

	[HttpGet("{symbol}")]
	public async Task<IActionResult> GetStockData(string symbol)
	{
		var data = await _alphaVantageService.GetStockDataAsync(symbol);

		if (data != null)
		{
			return Ok(data); 
		}
		else
		{
			return NotFound("Dados não encontrados.");
		}
	}
}

