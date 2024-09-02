using B3.WebApp.Domain.Entities;

namespace B3.WebApp.Services;

public interface ICdbCalculatorService
{
    ResultCdb CalcularCdb(int qtdMeses, double ValorInicial);
    double CalcularCdbImposto(int qtdMeses, double valorResultadoBruto);
}
