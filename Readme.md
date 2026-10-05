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

Programmet listar språkparen som hittades i `wordlist`. Välj ett genom att
skriva dess nummer och trycka på Enter. Skriv sedan ett ord på det angivna
källspråket. Alla översättningar som hittas visas, även om ordet har flera
översättningar.

Om ordet inte finns visas ett meddelande. Programmet fortsätter att fråga efter
ord. Avsluta med `Ctrl+C`. Om inmatningen stängs avslutar programmet också.

## Ordlistor

Lägg språkfiler i projektmappens `wordlist`-mapp. Filnamnet anger språkparet
som `källspråk.målspråk.csv`. Till exempel:

- `swedish.english.csv` — svenska till engelska
- `swedish.spanish.csv` — svenska till spanska

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

## Begränsningar

- Sökningen skiljer mellan stora och små bokstäver.
- Språkparet gäller i riktningen som anges i filnamnet. En separat fil behövs
  för omvänd översättning.
- Om inga CSV-filer finns i `wordlist` kan programmet inte starta.
