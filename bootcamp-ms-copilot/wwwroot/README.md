# Validador de Cartão de Crédito - Frontend

Este é um projeto front-end que implementa a mesma lógica de validação de cartão de crédito do projeto C# em uma interface web moderna e responsiva.

## Funcionalidades

- 🎯 **Identificação de Bandeiras**: Identifica automaticamente a bandeira do cartão conforme o usuário digita
- 💳 **Formatação Automática**: Formata o número do cartão com espaços para melhor legibilidade
- 🎨 **Interface Moderna**: Design responsivo e moderno com animações suaves
- 📱 **Responsivo**: Funciona perfeitamente em desktop, tablet e mobile
- 🔍 **Exemplos Interativos**: Cartões de exemplo clicáveis para teste

## Bandeiras Suportadas

- Visa
- MasterCard
- American Express
- Discover
- Elo
- Hipercard

## Como usar

1. Abra o arquivo `index.html` em seu navegador
2. Digite o número do cartão no campo de entrada
3. A bandeira será identificada automaticamente
4. Use os cartões de exemplo para testar diferentes bandeiras

## Estrutura do Projeto

```
frontend/
├── index.html      # Página principal
├── styles.css      # Estilos CSS
├── script.js       # Lógica JavaScript
└── README.md       # Este arquivo
```

## Tecnologias Utilizadas

- HTML5
- CSS3 (Grid, Flexbox, Animações)
- JavaScript (ES6+)
- Font Awesome (Ícones)

## Recursos Técnicos

- Validação baseada na mesma lógica do projeto C#
- Formatação automática do número do cartão
- Validação de entrada (apenas números)
- Feedback visual imediato
- Exemplos de teste integrados

## Exemplos de Teste

- **Visa**: 4111 1111 1111 1111
- **MasterCard**: 5555 5555 5555 4444
- **American Express**: 3782 8224 6310 005
- **Discover**: 6011 1111 1111 1117
