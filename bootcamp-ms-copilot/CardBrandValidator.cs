using System.Text.RegularExpressions;

public static class CardBrandValidator
{
    public static string IdentifyBrand(string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber))
            return "Desconhecida";

        cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

        // Elo: vários intervalos conhecidos
        if (Regex.IsMatch(cardNumber, "^(4011|4312|4389|4514|4576|5041|5066|5067|509|6277|6362|6363)"))
            return "Elo";

        // Visa: começa com 4
        if (Regex.IsMatch(cardNumber, "^4"))
            return "Visa";

        // MasterCard: 51-55 ou 2221-2720
        if (Regex.IsMatch(cardNumber, "^(5[1-5])"))
            return "MasterCard";
        if (Regex.IsMatch(cardNumber, "^(2221|222[2-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)"))
            return "MasterCard";

        // American Express: 34 ou 37
        if (Regex.IsMatch(cardNumber, "^(34|37)"))
            return "American Express";

        // Discover: 6011, 65, 644-649
        if (Regex.IsMatch(cardNumber, "^(6011|65|64[4-9])"))
            return "Discover";

        // Hipercard: 6062
        if (Regex.IsMatch(cardNumber, "^6062"))
            return "Hipercard";

        return "Desconhecida";
    }
}
