# BUG-001: Programmet fortsätter loopa när inmatningen tar slut

- **Status:** Öppen
- **Allvarlighetsgrad:** Medel
- **Berörd funktion:** Inmatningsloopen i `Program.cs`

## Beskrivning

Om konsolens standardindata tar slut returnerar `Console.ReadLine()` `null`.
Programmet behandlar då detta som ett okänt ord och fortsätter `while`-loopen.
Det kan leda till att felmeddelandet skrivs ut om och om igen utan möjlighet
att mata in ett nytt ord.

## Steg för att återskapa

1. Starta programmet med standardindata som avslutas, till exempel genom att
   köra programmet från en process eller pipeline som stänger sin indataström.
2. Vänta tills programmet försöker läsa nästa rad.

## Förväntat resultat

Programmet avslutar inmatningsloopen när `Console.ReadLine()` returnerar `null`.

## Faktiskt resultat

Programmet visar meddelandet om att ordet saknas och försöker läsa igen i en
oändlig loop.

## Förslag på åtgärd

Kontrollera om inmatningen är `null` och avsluta loopen innan uppslaget görs.
