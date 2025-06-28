using Xunit;

public class CardBrandValidatorTests
{
    [Theory]
    [InlineData("4111111111111111", "Visa")]
    [InlineData("4012888888881881", "Visa")]
    [InlineData("5105105105105100", "MasterCard")]
    [InlineData("5555555555554444", "MasterCard")]
    [InlineData("2221000000000009", "MasterCard")]
    [InlineData("2720999999999999", "MasterCard")]
    [InlineData("4011780000000000", "Elo")]
    [InlineData("4312740000000000", "Elo")]
    [InlineData("4389350000000000", "Elo")]
    [InlineData("4514160000000000", "Elo")]
    [InlineData("4576310000000000", "Elo")]
    [InlineData("5041750000000000", "Elo")]
    [InlineData("5066990000000000", "Elo")]
    [InlineData("5090000000000000", "Elo")]
    [InlineData("6277800000000000", "Elo")]
    [InlineData("6362970000000000", "Elo")]
    [InlineData("6363680000000000", "Elo")]
    [InlineData("340000000000009", "American Express")]
    [InlineData("370000000000002", "American Express")]
    [InlineData("6011000000000004", "Discover")]
    [InlineData("6500000000000002", "Discover")]
    [InlineData("6440000000000000", "Discover")]
    [InlineData("6490000000000000", "Discover")]
    [InlineData("6062825624254001", "Hipercard")]
    [InlineData("1234567890123456", "Desconhecida")]
    [InlineData("", "Desconhecida")]
    [InlineData(null, "Desconhecida")]
    public void IdentifyBrand_ShouldReturnCorrectBrand(string cardNumber, string expectedBrand)
    {
        var result = CardBrandValidator.IdentifyBrand(cardNumber);
        Assert.Equal(expectedBrand, result);
    }
}

