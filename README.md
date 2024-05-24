# Bankapplikationstest

## Testade funktioner

### Test_TransferMoney_InvalidChoice

**Beskrivning:**  
Testar överföringsfunktionen när ett ogiltigt val görs av användaren.

- **Arrange:** Skapar en kund och simulerar användarinmatning.
- **Act:** Anropar TransferMoney-metoden.
- **Assert:** Verifierar att rätt felmeddelande visas när ett ogiltigt val görs.

### Test_Withdraw_ValidAccountAndSufficientFunds

**Beskrivning:**  
Testar uttagsfunktionen när ett giltigt konto och tillräckliga medel finns.

- **Arrange:** Skapar en kund och ett konto med 1000 SEK, och simulerar användarinmatning.
- **Act:** Anropar Withdraw-metoden.
- **Assert:** Verifierar att kontots saldo minskas korrekt och att rätt belopp visas.

### Test_Deposit_ValidAccount

**Beskrivning:**  
Testar insättningsfunktionen på ett giltigt konto.

- **Arrange:** Skapar en kund och ett konto med 1000 SEK, och simulerar användarinmatning.
- **Act:** Anropar Deposit-metoden.
- **Assert:** Verifierar att kontots saldo ökas korrekt och att rätt belopp visas.

## Möjliga fel

### Test_TransferMoney_InvalidChoice

- **Fel:** Testet kan misslyckas om felmeddelandet ändras eller om inmatningen inte hanteras korrekt.
- **Lösning:** Se till att felmeddelandet är exakt och att inmatningen valideras ordentligt.

### Test_Withdraw_ValidAccountAndSufficientFunds

- **Fel:** Testet kan misslyckas om kontosaldot inte uppdateras korrekt eller om användarinmatningen inte tolkas rätt.
- **Lösning:** Kontrollera att kontots saldo hanteras korrekt och att inmatningen valideras ordentligt.

### Test_Deposit_ValidAccount

- **Fel:** Testet kan misslyckas om kontosaldot inte uppdateras korrekt eller om användarinmatningen inte tolkas rätt.
- **Lösning:** Kontrollera att kontots saldo hanteras korrekt och att inmatningen valideras ordentligt.

