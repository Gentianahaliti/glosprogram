# Glosprogram

Ett enkelt konsolprogram som läser en svensk-engelsk ordlista från en CSV-fil
och låter dig söka efter engelska översättningar av svenska ord.

## Krav

- .NET 10 SDK
- `swedish.english.csv` i projektmappen

CSV-filen kopieras automatiskt till programmets körmapp när projektet byggs.

## Starta programmet

Öppna en terminal i projektmappen och kör:

```text
dotnet run
```

Programmet visar först en exempelöversättning (`home`) och frågar sedan:

```text
Ange vilket ord du vill översätta
```

Skriv ett svenskt ord som finns i ordlistan och tryck på Enter. Programmet
skriver ut den eller de engelska översättningarna. Om ordet inte hittas visas:

```text
This word does not exist in this dictionary
```

Programmet fortsätter att fråga efter ord. Avsluta det med `Ctrl+C`.

## Ordlistans format

Programmet läser för närvarande filen `swedish.english.csv`. Filnamnet anger
språkparet i formatet `källspråk.målspråk.csv`. Programmet använder dessa
språknamn på varje inläst översättningspost. Varje rad i filen ska innehålla
ett källspråksord och dess översättning, separerade med ett kommatecken:

```csv
hus,house
hem,home
stor,big
stor,large
```

Blanksteg runt orden tas bort. Om samma svenska ord finns på flera rader
visas alla dess översättningar vid sökning. Programmet delar varje rad vid det
första kommatecknet och behandlar resten av raden som översättningen.

## Begränsningar i nuvarande version

- Programmet läser för närvarande bara `swedish.english.csv`. Andra språkfiler,
  till exempel `swedish.spanish.csv`, kopieras till körmappen men kan ännu inte
  väljas eller användas.
- Sökningen skiljer mellan stora och små bokstäver. Skriv ordet med samma
  versalisering som i CSV-filen.
- Saknas CSV-filen, eller saknar en rad kommatecken, avbryts programmet med
  ett fel. CSV-citattecken och escaping stöds inte.
- Programmet visar för närvarande exempelöversättningen `home` vid start.
- Om ordlistan innehåller färre än två poster kraschar programmet vid
  exempelutskriften.
- Om programmets standardindata tar slut fortsätter det att upprepa meddelandet
  om att ordet saknas. Avsluta programmet med `Ctrl+C`.