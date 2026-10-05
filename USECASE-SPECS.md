# Use case-specifikationer

Målet är att utveckla glosprogrammet stegvis. Implementera och verifiera ett use case i taget innan nästa påbörjas.

## UC-01: Läsa in en översättningsfil

**Som användare** vill jag att programmet läser glosor från en CSV-fil, så att jag inte behöver skriva in dem direkt i koden.

**Kriterier för godkännande**

- Programmet läser den befintliga svenska-engelska CSV-filen.
- Varje giltig rad läses in som en översättningspost.
- Inlästa glosor kan visas eller användas av programmet.
- Grundläggande syntax- och filnamnsfel som hindrar körning är åtgärdade.

## UC-02: Hämta språkparet från filnamnet

**Som användare** vill jag att programmet avgör språken från översättningsfilens namn, så att språk inte behöver hårdkodas i programmet.

**Exempel**

- `swedish.english.csv` anger svenska som källspråk och engelska som målspråk.

**Kriterier för godkännande**

- Båda språken hämtas från filnamnet.
- Varje inläst översättningspost får rätt käll- och målspråk.
- Inga fasta svenska eller engelska språksträngar krävs för att hantera filen.

## UC-03: Läsa alla språkfiler från `wordlist`

**Som användare** vill jag lägga översättningsfiler i mappen `wordlist`, så att programmet hittar dem automatiskt.

**Kriterier för godkännande**

- Programmet läser giltiga översättningsfiler från `wordlist`.
- Filernas språkpar identifieras enligt UC-02.
- Att lägga till en kompatibel fil kräver inte ändringar i programkoden.

## UC-04: Välja språkpar

**Som användare** vill jag välja ett tillgängligt språkpar, så att jag kan använda samma program för olika översättningar.

**Exempel**

- Svenska → engelska.
- Franska → svenska.

**Kriterier för godkännande**

- Språkpar som erbjuds baseras på tillgängliga filer.
- Användaren kan välja ett språkpar innan uppslag görs.
- Programmet använder det valda språkparet för efterföljande sökningar.

## UC-05: Söka efter ett ord i valt språkpar

**Som användare** vill jag skriva in ett ord och få dess översättning, så att programmet fungerar som en ordbok.

**Kriterier för godkännande**

- Programmet frågar efter ett ord.
- Sökningen använder användarens inmatning och det valda språkparet.
- Uppslaget är inte begränsat till ett hårdkodat ord.
- Om ordet saknas visas ett tydligt meddelande.

## UC-06: Visa flera översättningar

**Som användare** vill jag se alla översättningar som finns för ett ord, så att synonymer inte tappas bort.

**Kriterier för godkännande**

- Flera rader med samma källord bevaras vid inläsning.
- Alla motsvarande översättningar visas vid uppslag.
- En post med endast en översättning visas korrekt.

## UC-07: Hantera felaktiga filer och indata

**Som användare** vill jag få tydlig återkoppling när en fil eller inmatning är ogiltig, så att jag kan förstå och rätta problemet.

**Kriterier för godkännande**

- Saknad eller oläsbar fil ger ett begripligt felmeddelande.
- Tomma rader och rader med fel antal kolumner hanteras tydligt.
- Tom eller utebliven användarinmatning hanteras utan att programmet kraschar.
- Saknade ord rapporteras tydligt och förväxlas inte med lyckade uppslag.
