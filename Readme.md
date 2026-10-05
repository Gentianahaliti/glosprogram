# Glosprogram

Ett konsolprogram där du väljer ett språkpar och söker efter översättningar i
CSV-ordlistor.

## Krav

- .NET 10 SDK
- Minst en giltig CSV-fil i projektmappen `wordlist`

CSV-filerna kopieras automatiskt till programmets körmapp när projektet byggs.

## Starta programmet

Öppna en terminal i projektmappen och kör:

```text
dotnet run
```

Välj först läge:

1. **Översätt ord** — programmet listar språkparen i `wordlist`. Välj ett
   nummer och skriv sedan ett ord på källspråket. Alla matchande översättningar
   visas.
2. **Spela quiz om dagens projektarbete** — svara på flervalsfrågorna med
   alternativets nummer. Efter varje fråga visas om svaret var rätt och en
   kort förklaring. I slutet visas poäng och procent.

I översättningsläget visas ett meddelande om ordet inte hittas. Programmet
fortsätter att fråga efter ord. Avsluta med `Ctrl+C`. Om inmatningen stängs
avslutar både översättningsläget och quizet på ett kontrollerat sätt.

## Ordlistor

Lägg språkfiler i projektmappens `wordlist`-mapp. Filnamnet anger språkparet
som `källspråk.målspråk.csv`. Till exempel:

- `swedish.english.csv` — svenska till engelska
- `swedish.spanish.csv` — svenska till spanska
- `spanish.italian.csv` — spanska till italienska

Varje rad ska innehålla ett källspråksord och en översättning, separerade med
ett kommatecken:

```csv
hus,house
stor,big
stor,large
```

Blanksteg runt orden tas bort. Om samma källord står på flera rader visas alla
dess översättningar. Raden delas vid det första kommatecknet; CSV-citattecken
och escaping stöds inte. Rader utan två ifyllda fält orsakar ett tydligt
inläsningsfel med filnamn och radnummer. Filnamnet måste innehålla exakt två
språknamn före `.csv`.

Den spansk-italienska ordlistan använder de spanska översättningarna från den
svensk-spanska ordlistan som uppslagsord, i samma ordning. Språkparen läses in som
separata, riktade ordlistor; omvänd översättning kräver en fil med omvänt
språkpar.

## Begränsningar

- Sökningen skiljer mellan stora och små bokstäver.
- Språkparet gäller i riktningen som anges i filnamnet. En separat fil behövs
  för omvänd översättning.
- Om inga CSV-filer finns i `wordlist` kan programmet inte starta.
