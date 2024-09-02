using B3.WebApp.Services;

namespace B3.Test;

[TestClass]
public class CdbCalculoImpostoTest
{
    ICdbCalculatorService cdbCalculatorService = new CdbCalculatorService();

    [TestInitialize]
    public void Setup()
    {
        cdbCalculatorService = new CdbCalculatorService();
    }

    [TestMethod]
    public void Test_ValidacaoEntradaNegativa_QtdMeses()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.CalcularCdbImposto(-1, 1000));
    }

    [TestMethod]
    public void Test_ValidacaoEntradaNegativa_ValorResultadoBruto()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.CalcularCdbImposto(12, -1000));
    }

    [TestMethod]
    public void Test_ValidacaoIntervaloMeses()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.CalcularCdbImposto(0, 1000));
    }

    [TestMethod]
    public void Test_ValidacaoValorResultadoBruto()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.CalcularCdbImposto(12, 0));
    }

    [TestMethod]
    public void Test_CalculoImposto()
    {
        // Arrange
        double expectedImposto = 225; // Valor esperado para 22.5% de imposto
        double delta = 0.001; // Margem de erro para comparação de valores de ponto flutuante

        // Act
        double calculatedImposto = cdbCalculatorService.CalcularCdbImposto(6, 1000); // 6 meses e 1000 de valor

        // Assert
        Assert.AreEqual(expectedImposto, calculatedImposto, delta);
    }

    [TestMethod]
    public void Test_CalcularImposto_TaxaImpostoCorreta()
    {
        // Arrange & Act
        double resultado = cdbCalculatorService.CalcularCdbImposto(6, 1000);

        // Assert
        double expectedImposto = 1000 * 0.225; // Imposto de 22.5%
        double delta = 0.001; // Margem de erro para comparação de valores de ponto flutuante
        Assert.AreEqual(expectedImposto, resultado, delta);
    }

    [TestMethod]
    public void Test_CalcularImposto_ValorPositivo()
    {
        // Arrange & Act
        double resultado = cdbCalculatorService.CalcularCdbImposto(12, 1000);

        // Assert
        Assert.IsTrue(resultado >= 0);
    }

    [TestMethod]
    public void Test_CalcularImposto_QtdMesesMenorQueDois()
    {
        Assert.ThrowsException<ArgumentException>(() => cdbCalculatorService.CalcularCdbImposto(1, 1000));
    }

     [TestMethod]
    public void Test_CalcularImposto_TaxaAteSeisMeses()
    {
        // Arrange & Act
        double resultado = cdbCalculatorService.CalcularCdbImposto(6, 1000);

        // Assert
        double expectedImposto = 1000 * 0.225; // Imposto de 22.5%
        double delta = 0.001; // Margem de erro para comparação de valores de ponto flutuante
        Assert.AreEqual(expectedImposto, resultado, delta);
    }

    [TestMethod]
    public void Test_CalcularImposto_TaxaAteDozeMeses()
    {
        double resultado = cdbCalculatorService.CalcularCdbImposto(12, 1000);

        double expectedImposto = 1000 * 0.20; // Imposto de 20%
        double delta = 0.001; // Margem de erro para comparação de valores de ponto flutuante
        Assert.AreEqual(expectedImposto, resultado, delta);
    }

     [TestMethod]
    public void Test_CalcularImposto_TaxaAteVinteQuatroMeses()
    {
        double resultado = cdbCalculatorService.CalcularCdbImposto(24, 1000);

        double expectedImposto = 1000 * 0.175; 
        double delta = 0.001; 
        Assert.AreEqual(expectedImposto, resultado, delta);
    }

    [TestMethod]
    public void Test_CalcularImposto_TaxaAcimaVinteQuatroMeses()
    {
        double resultado = cdbCalculatorService.CalcularCdbImposto(36, 1000);

        double expectedImposto = 1000 * 0.15; 
        double delta = 0.001;
        Assert.AreEqual(expectedImposto, resultado, delta);
    }
}
