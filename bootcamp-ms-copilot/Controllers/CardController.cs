// Controller responsável por validar a bandeira do cartão de crédito e listar as bandeiras suportadas.
//
// Métodos:
// - ValidateCard: Recebe um número de cartão via POST, identifica a bandeira e retorna o resultado da validação.
//   - Rota: POST api/card/validate
//   - Parâmetro: CardValidationRequest (contendo o número do cartão)
//   - Retorno: CardValidationResponse (número, bandeira e se é válida)
//
// - GetSupportedBrands: Retorna a lista de bandeiras de cartão suportadas pela API.
//   - Rota: GET api/card/brands
//   - Retorno: Lista de strings com os nomes das bandeiras
//
// Observação: Este controller utiliza a classe CardBrandValidator para identificar a bandeira do cartão.
//
// Exemplos de uso:
// - POST /api/card/validate { "cardNumber": "4111111111111111" }
// - GET /api/card/brands
//
// As respostas são retornadas em formato JSON.

using Microsoft.AspNetCore.Mvc;

namespace bootcamp_ms_copilot.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    [HttpPost("validate")]
    public IActionResult ValidateCard([FromBody] CardValidationRequest request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.CardNumber))
        {
            return BadRequest(new { error = "Número do cartão é obrigatório" });
        }

        var brand = CardBrandValidator.IdentifyBrand(request.CardNumber);
        
        return Ok(new CardValidationResponse 
        { 
            CardNumber = request.CardNumber,
            Brand = brand,
            IsValid = brand != "Desconhecida"
        });
    }

    [HttpGet("brands")]
    public IActionResult GetSupportedBrands()
    {
        var brands = new[]
        {
            "Visa",
            "MasterCard", 
            "American Express",
            "Discover",
            "Elo",
            "Hipercard"
        };

        return Ok(new { supportedBrands = brands });
    }
}

public class CardValidationRequest
{
    public string CardNumber { get; set; } = string.Empty;
}

public class CardValidationResponse
{
    public string CardNumber { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public bool IsValid { get; set; }
}
