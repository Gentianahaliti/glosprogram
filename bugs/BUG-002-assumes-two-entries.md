# BUG-002: Programmet kraschar om ordlistan har färre än två poster

- **Status:** Öppen
- **Allvarlighetsgrad:** Medel
- **Berörd funktion:** Exempelutskriften efter CSV-inläsningen i `Program.cs`

## Beskrivning

Efter att ordlistan lästs in hämtar programmet alltid `words[1]`. Om CSV-filen
är tom eller innehåller endast en giltig rad finns inget element på index `1`,
och programmet avslutas med ett `ArgumentOutOfRangeException`.

## Steg för att återskapa

1. Gör en tillfällig kopia av `swedish.english.csv`.
2. Lämna endast en giltig rad i filen, till exempel `hus,house`.
3. Starta programmet.

## Förväntat resultat

Programmet startar även med en giltig lista som innehåller färre än två poster,
eller visar ett tydligt meddelande om att ordlistan inte har tillräckligt med
data för exempelutskriften.

## Faktiskt resultat

Programmet kraschar när det försöker läsa `words[1]`.

## Förslag på åtgärd

Ta bort exempelutskriften eller kontrollera listans längd innan index `1`
används.
