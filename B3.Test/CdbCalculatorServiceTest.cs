using B3.WebApp.Services;

namespace B3.Test;

[TestClass]
public class CdbCalculatorServiceTest
{
    ICdbCalculatorService cdbCalculatorService = new CdbCalculatorService();    

   [TestInitialize]
    public void Setup()
    {
        cdbCalculatorService = new CdbCalculatorService();
    }


    [TestMethod]
    public void Test_ExecutarCalculoCdb_ResultadosValidos()
    {
        int qtdMeses = 12;
        double valorInicial = 1000;

        var resultado = cdbCalculatorService.CalcularCdb(qtdMeses, valorInicial);

        Assert.IsNotNull(resultado);
        Assert.IsTrue(resultado.ValorBruto > valorInicial);
        Assert.IsTrue(resultado.ValorLiquido >= valorInicial);
    }

    [TestMethod]
    public void Test_ExecutarCalculoCdb_ResultadosDiferentesParaDiferentesValoresIniciais()
    {
        // Arrange
        int qtdMeses = 12;
        double valorInicial1 = 1000;
        double valorInicial2 = 1500;

        // Act
        var resultado1 = cdbCalculatorService.CalcularCdb(qtdMeses, valorInicial1);
        var resultado2 = cdbCalculatorService.CalcularCdb(qtdMeses, valorInicial2);

        // Assert
        Assert.AreNotEqual(resultado1.ValorBruto, resultado2.ValorBruto);
    }

    [TestMethod]
    public void Test_ExecutarCalculoCdb_QtdMesesNegativo()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.CalcularCdb(-1, 1000));
    }

    [TestMethod]
    public void Test_ExecutarCalculoCdb_ValorInicialNegativo()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.CalcularCdb(12, -1000));
    }

     [TestMethod]
    public void Test_ExecutarCalculoCdb_QtdMesesMenorQueDois()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.CalcularCdb(1, 1000));
    }
}