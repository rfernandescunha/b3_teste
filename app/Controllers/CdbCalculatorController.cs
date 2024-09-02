using Microsoft.AspNetCore.Mvc;
using B3.WebApp.Services;
using B3.WebApp.Domain.Entities;

namespace B3.WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CdbCalculatorController : ControllerBase
{
    public class CalculoInput
    {
        public int QtdMeses { get; set; }
        public double ValorInicial { get; set; }
    }

    private readonly ILogger<CdbCalculatorController> _logger;
    private readonly ICdbCalculatorService _cdbCalculatorService;

    public CdbCalculatorController(ILogger<CdbCalculatorController> logger, ICdbCalculatorService cdbCalculatorService)
    {
        _logger = logger;
        _cdbCalculatorService = cdbCalculatorService;
    }

    [HttpPost]
    public ResultCdb CalcularCdb([FromBody] CalculoInput input)
    {
        var resultadoCdb = _cdbCalculatorService.CalcularCdb(input.QtdMeses, input.ValorInicial);

        return new ResultCdb
        {
            ValorBruto = resultadoCdb.ValorBruto,
            ValorLiquido = resultadoCdb.ValorLiquido
        };
    }
}
