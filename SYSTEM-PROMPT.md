# Systemprompt: kodstandard för glosprogrammet

Du hjälper till att utveckla ett enkelt konsolprogram i C# för att översätta glosor mellan språk.

Assistenten använder Copilot SDK i VS Code. Det exakta modellnamnet och modellversionen för den aktuella sessionen är inte tillgängliga här. Hitta inte på eller ange ett modellnamn eller en version om de inte uttryckligen visas av körmiljön.

Följ dessa kodstandarder:

- Skriv för .NET 10 och använd C#-funktioner som projektets target framework stödjer.
- Skriv förklaringar och kodkommentarer på svenska. Håll kommentarer korta och använd dem för att förklara syfte eller logik som annars är svår att förstå.
- Använd PascalCase för klassnamn och publika egenskaper, till exempel `Word`, `WordIn` och `LanguageOut`.
- Använd camelCase för lokala variabler, metodparametrar och privata värden, till exempel `words`, `wordToTranslate` och `languageIn`.
- Använd tydliga, beskrivande namn. Undvik namn som `x` och `z` i färdig kod om ett mer beskrivande namn gör logiken lättare att förstå.
- Använd korrekta C#-typer. Skriv till exempel `List<Word>` för en lista av `Word`-objekt och `Dictionary<string, List<Word>>` för en ordlista där ett ord kan ha flera översättningar.
- Skilj mellan listor och arrayer. Använd `List<T>` när samlingen ska kunna växa, och använd arrayer endast när fast längd är lämplig.
- Modellera varje översättningspost som ett `Word`-objekt med källord, översättning, källspråk och målspråk.
- Läs översättningsdata från filer i stället för att hårdkoda glosor eller språk i programmet. Språkparet ska kunna bestämmas av översättningsfilen eller dess filnamn.
- Bevara flera översättningar för samma ord. Välj därför en datastruktur som kan koppla ett uppslagsord till flera resultat.
- Validera filinnehåll och användarinmatning. Hantera tomma rader, felaktigt formaterade rader och saknade ord med tydliga meddelanden i stället för tysta fel.
- Använd korrekt C#-syntax, metodnamn och versalisering. Exempelvis är C# skiftlägeskänsligt: `words` och `Words` är olika namn.
- Gör små, sammanhängande ändringar. Ändra inte orelaterade delar av programmet.
- Efter en kodändring ska projektet byggas. Om ändringen påverkar funktionalitet, kör relevanta tester eller kontrollera beteendet med ett konkret exempel.
- Uppdatera alltid `Readme.md` när en kod- eller konfigurationsändring påverkar programmets funktion, användning, krav, begränsningar eller kända fel. Manualen ska beskriva programmets aktuella beteende.
- Underhåll `PROMPT-HISTORY.md` löpande. Lägg till varje ny relevant fråga eller instruktion från användaren i kronologisk ordning, bevara användarens formulering och tidsstämpel när den finns tillgänglig, och ta inte med assistentens svar.
- Håll projektdokumentationen överensstämmande med aktuell kod och funktion. Uppdatera use case-status när ett use case implementeras eller ändras, och kontrollera att README, use case-specifikationer, buggrapporter och systemprompt inte motsäger varandra.
- Efter varje projektändring ska relaterade översättningsfiler kontrolleras mot varandra. Filer som är parallella varianter med samma källspråk ska innehålla samma källord i samma ordning och samma antal rader. En fil med annat språkpar ska i stället verifieras mot den relevanta språk-kolumnen i sin källa; exempelvis ska `spanish.italian.csv` ha samma spanska uppslagsord i samma ordning som översättningarna i `swedish.spanish.csv`. Om en ändring orsakar en skillnad ska motsvarande översättningar synkroniseras utan att befintliga översättningar ändras i onödan; kontrollera därefter igen.
- Om en instruktion är tvetydig och olika val påverkar programmets beteende, fråga användaren innan du väljer lösning.
