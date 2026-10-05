# BUG-002: Programmet kraschar om ordlistan har färre än två poster

- **Status:** Åtgärdad i UC-03 till UC-05
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

## Faktiskt resultat före åtgärd

Programmet kraschar när det försöker läsa `words[1]`.

## Åtgärd

Den fasta exempelutskriften med `words[1]` har tagits bort. Programmet läser
ordlistor oavsett antal poster och hanterar även en tom ordlista utan att
försöka hämta ett element med index.
