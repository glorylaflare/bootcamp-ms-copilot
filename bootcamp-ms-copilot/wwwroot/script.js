// Classe para validação de cartão baseada na implementação C#
class CardBrandValidator {
    static identifyBrand(cardNumber) {
        if (!cardNumber || cardNumber.trim() === '') {
            return 'Desconhecida';
        }

        // Remove espaços e hífens
        cardNumber = cardNumber.replace(/[\s-]/g, '');

        // Elo: vários intervalos conhecidos
        if (/^(4011|4312|4389|4514|4576|5041|5066|5067|509|6277|6362|6363)/.test(cardNumber)) {
            return 'Elo';
        }

        // Visa: começa com 4
        if (/^4/.test(cardNumber)) {
            return 'Visa';
        }

        // MasterCard: 51-55 ou 2221-2720
        if (/^5[1-5]/.test(cardNumber)) {
            return 'MasterCard';
        }
        if (/^(2221|222[2-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)/.test(cardNumber)) {
            return 'MasterCard';
        }

        // American Express: 34 ou 37
        if (/^(34|37)/.test(cardNumber)) {
            return 'American Express';
        }

        // Discover: 6011, 65, 644-649
        if (/^(6011|65|64[4-9])/.test(cardNumber)) {
            return 'Discover';
        }

        // Hipercard: 6062
        if (/^6062/.test(cardNumber)) {
            return 'Hipercard';
        }

        return 'Desconhecida';
    }
}

function formatCardNumber(value) {
    const number = value.replace(/\D/g, '');
    return number.replace(/(\d{4})(?=\d)/g, '$1 ');
}

function getBrandIcon(brand) {
    const icons = {
        'Visa': 'fab fa-cc-visa',
        'MasterCard': 'fab fa-cc-mastercard',
        'American Express': 'fab fa-cc-amex',
        'Discover': 'fab fa-cc-discover',
        'Elo': 'fas fa-credit-card',
        'Hipercard': 'fas fa-credit-card',
        'Desconhecida': 'fas fa-question-circle'
    };
    return icons[brand] || 'fas fa-question-circle';
}

function getBrandClass(brand) {
    const classes = {
        'Visa': 'brand-visa',
        'MasterCard': 'brand-mastercard',
        'American Express': 'brand-amex',
        'Discover': 'brand-discover',
        'Elo': 'brand-elo',
        'Hipercard': 'brand-hipercard',
        'Desconhecida': 'brand-unknown'
    };
    return classes[brand] || 'brand-unknown';
}

function updateBrandDisplay(brand) {
    const brandIcon = document.getElementById('brandIcon');
    const brandName = document.getElementById('brandName');
    const cardBrandDisplay = document.querySelector('.card-brand-display');
    brandIcon.innerHTML = `<i class="${getBrandIcon(brand)}"></i>`;
    brandName.textContent = brand;
    brandIcon.className = 'brand-icon';
    cardBrandDisplay.className = 'card-brand-display';
    brandIcon.classList.add(getBrandClass(brand));
    if (brand !== 'Desconhecida' && brand !== 'Digite um número de cartão') {
        cardBrandDisplay.classList.add('identified');
    }
}

// Função para validar o cartão via API
async function validateCardViaApi(cardNumber) {
    try {
        const response = await fetch('/api/card/validate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ cardNumber })
        });
        if (!response.ok) {
            return { brand: 'Desconhecida' };
        }
        const data = await response.json();
        return data;
    } catch (error) {
        return { brand: 'Desconhecida' };
    }
}

// Inicialização quando o DOM estiver carregado
document.addEventListener('DOMContentLoaded', function() {
    const cardNumberInput = document.getElementById('cardNumber');
    const exampleCards = document.querySelectorAll('.example-card');

    // Event listener para o input do cartão
    cardNumberInput.addEventListener('input', async function(e) {
        const rawValue = e.target.value;
        const formattedValue = formatCardNumber(rawValue);
        e.target.value = formattedValue;

        // Consulta a API para identificar a bandeira
        if (rawValue.trim() === '') {
            updateBrandDisplay('Digite um número de cartão');
        } else {
            const result = await validateCardViaApi(rawValue);
            // Aceita tanto 'brand' quanto 'Brand' (compatibilidade C#)
            const detectedBrand = result.brand || result.Brand || 'Desconhecida';
            updateBrandDisplay(detectedBrand);
        }
    });
    
    // Event listeners para os cartões de exemplo
    exampleCards.forEach(card => {
        card.addEventListener('click', function() {
            const exampleNumber = this.getAttribute('data-number');
            const formattedNumber = formatCardNumber(exampleNumber);
            
            cardNumberInput.value = formattedNumber;
            
            // Dispara o evento de input para atualizar a bandeira
            const event = new Event('input', { bubbles: true });
            cardNumberInput.dispatchEvent(event);
            
            // Foca no input
            cardNumberInput.focus();
        });
    });
    
    // Permite apenas números no input
    cardNumberInput.addEventListener('keypress', function(e) {
        // Permite backspace, delete, tab, escape, enter
        if ([8, 9, 27, 13, 46].indexOf(e.keyCode) !== -1 ||
            // Permite Ctrl+A, Ctrl+C, Ctrl+V, Ctrl+X
            (e.keyCode === 65 && e.ctrlKey === true) ||
            (e.keyCode === 67 && e.ctrlKey === true) ||
            (e.keyCode === 86 && e.ctrlKey === true) ||
            (e.keyCode === 88 && e.ctrlKey === true)) {
            return;
        }
        
        // Garante que é um número
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
    
    // Inicializa com estado padrão
    updateBrandDisplay('Digite um número de cartão');
});
