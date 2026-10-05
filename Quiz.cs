static class Quiz
{
    private static readonly QuizQuestion[] Questions =
    [
        new(
            "Vad är en array i C#?",
            ["En samling med fast längd", "En samling som alltid växer", "En metod som läser filer", "En typ av loop"],
            0,
            "En array har en bestämd längd när den skapas."),
        new(
            "Vilket index har det första elementet i en array eller lista?",
            ["1", "-1", "0", "Det beror på elementets typ"],
            2,
            "C# använder nollbaserad indexering."),
        new(
            "Vad betyder List<Word>?",
            ["En array med text", "En lista som innehåller Word-objekt", "En fil med ord", "En metod för översättning"],
            1,
            "Word anger elementtypen som listan innehåller."),
        new(
            "Vad beskriver klassen Word i projektet?",
            ["En CSV-fil", "En användarmeny", "En översättningspost med ord och språk", "En lista med språkpar"],
            2,
            "Varje Word-objekt innehåller källord, översättning och språk."),
        new(
            "Vilken C#-typ används för text, till exempel \"hus\"?",
            ["int", "bool", "string", "char[]"],
            2,
            "En string representerar text."),
        new(
            "Vad gör GroupBy(word => word.WordIn)?",
            ["Grupperar poster med samma källord", "Sorterar alfabetiskt efter översättningen", "Läser in en CSV-fil", "Vänder alla ord baklänges"],
            0,
            "Det gör att flera översättningar för samma källord kan samlas tillsammans."),
        new(
            "Vad lagrar Dictionary<string, List<Word>> i ordprogrammet?",
            ["En fil per ord", "En nyckel och listan med översättningsposter för den", "Bara en översättning per språk", "En lista med radnummer"],
            1,
            "Nyckeln är uppslagsordet och värdet kan innehålla flera Word-poster."),
        new(
            "Vad betyder raden hus,house i en CSV-ordlista?",
            ["Två ord utan samband", "Källordet hus och översättningen house", "Ett språkpar i filnamnet", "En kommentar"],
            1,
            "Kommat skiljer källordet från översättningen."),
        new(
            "Vad anger filnamnet swedish.english.csv?",
            ["Att svenska översätts till engelska", "Att engelska översätts till svenska", "Att filen har tre kolumner", "Att filen är en array"],
            0,
            "Första språket är källspråk och det andra målspråk."),
        new(
            "Var hittar programmet automatiskt översättningsfiler?",
            ["I mappen bin", "I mappen wordlist", "I mappen bugs", "I projektfilen"],
            1,
            "Programmet läser CSV-filer i wordlist-mappen."),
        new(
            "Vad händer när programmet startar och det finns flera ordlistor?",
            ["Det väljer alltid den första utan att fråga", "Det visar språkparen och låter användaren välja", "Det slår ihop orden i en fil", "Det frågar efter ett filnamn"],
            1,
            "Språkparen från filerna listas som val i konsolen."),
        new(
            "Vad gör användaren efter att ha valt ett språkpar?",
            ["Skriver ett ord på källspråket", "Ändrar projektfilen", "Skapar en array", "Skriver ett nytt filnamn"],
            0,
            "Programmet söker efter användarens ord i den valda ordlistan."),
        new(
            "Hur visas flera översättningar för samma källord?",
            ["Endast den sista visas", "Alla matchande översättningar skrivs ut", "Programmet avslutas", "De slås ihop till ett nytt ord"],
            1,
            "Uppslaget behåller och visar alla poster för nyckeln."),
        new(
            "Vad gör programmet om ett sökt ord saknas?",
            ["Visar ett meddelande om att ordet inte finns", "Skapar automatiskt en översättning", "Tar bort CSV-filen", "Avslutar datorn"],
            0,
            "Det ger användaren ett tydligt besked om att uppslaget misslyckades."),
        new(
            "Vad händer nu om Console.ReadLine() returnerar null?",
            ["Programmet fortsätter skriva felmeddelanden för alltid", "Programmet avslutar inmatningen", "Programmet väljer första ordet", "Programmet läser om CSV-filen"],
            1,
            "Slut på indata hanteras genom att avsluta i stället för att loopa."),
        new(
            "Varför kunde den tidigare exempelutskriften words[1] krascha?",
            ["Listan kan ha färre än två poster", "Index 1 betyder sista elementet", "WordOut är en int", "Listor kan inte indexeras"],
            0,
            "Om listan har noll eller ett element finns inget element på index 1."),
        new(
            "Vad betyder UC i projektets UC-01, UC-02 och UC-08?",
            ["User Control", "Use case, alltså användningsfall", "Unicode", "Unit Code"],
            1,
            "Ett use case beskriver ett användarmål och kriterier för när det fungerar."),
        new(
            "Vad gör UC-01?",
            ["Läser in en översättningsfil", "Väljer en användare", "Skapar en spansk-italiensk fil", "Översätter med proxy"],
            0,
            "UC-01 handlar om att läsa in glosor från CSV."),
        new(
            "Vad gör UC-02?",
            ["Hämtar språkparet från filnamnet", "Startar quizet", "Vänder en lista", "Validerar användarens lösenord"],
            0,
            "Till exempel ger swedish.english.csv språkparet svenska–engelska."),
        new(
            "Vad gör UC-03?",
            ["Läser CSV-ordlistor från wordlist-mappen", "Översätter engelska till italienska", "Skapar buggrapporter", "Visar bara synonymer"],
            0,
            "UC-03 låter programmet hitta språkfiler i wordlist."),
        new(
            "Vad gör UC-04?",
            ["Låter användaren välja språkpar", "Gör listan till en array", "Sparar svar i README", "Översätter via proxy"],
            0,
            "Programmet visar tillgängliga språkpar som val."),
        new(
            "Vad gör UC-05?",
            ["Söker efter användarens ord i valt språkpar", "Läser modellversionen", "Skapar språkfiler", "Kontrollerar Git"],
            0,
            "UC-05 använder användarens inmatning för att slå upp en översättning."),
        new(
            "Vad är UC-06 i den nuvarande specifikationen?",
            ["Visa flera översättningar för ett ord", "Översätta åt båda håll", "Läsa alla mappar", "Bygga projektet"],
            0,
            "UC-06 beskriver synonym- och flervärdesresultat; dubbelriktad sökning är en annan funktion."),
        new(
            "Vad är UC-08 tänkt att möjliggöra?",
            ["Översättning mellan språk via ett gemensamt proxyspråk", "Att lägga till kommentarer i koden", "Att öppna en ny terminal", "Att sortera CSV-filer efter storlek"],
            0,
            "UC-08 är planerad proxyöversättning, till exempel engelska → svenska → spanska."),
        new(
            "Hur ska ordlistor kopplas ihop vid proxyöversättning?",
            ["Genom att para ihop rader med samma radnummer", "Genom att matcha orden i proxyspråket", "Genom att dubblera alla Word-objekt", "Genom att jämföra filstorleken"],
            1,
            "Matchning ska göras på proxyordet, inte radpositionen."),
        new(
            "Varför undviker vi att skapa en ny Word-instans för varje omvänd riktning?",
            ["För att Word saknar egenskaper", "För att undvika onödiga dubblerade objekt", "För att CSV inte stöder text", "För att Dictionary kräver arrayer"],
            1,
            "Ett omvänt uppslag kan använda de redan inlästa posterna."),
        new(
            "Vad innehåller spanish.italian.csv?",
            ["Spanska uppslagsord och deras italienska översättningar", "Svenska och engelska", "Bara språkens namn", "En lista med användarfrågor"],
            0,
            "Filnamnet definierar spanska som källspråk och italienska som målspråk."),
        new(
            "Vad verifierade vi mellan CSV-filerna?",
            ["Att radantal och gemensamma uppslagsord stämmer i relevant ordning", "Att alla översättningar är exakt lika", "Att filerna har samma namn", "Att varje ord förekommer bara en gång"],
            0,
            "Paritetskontrollen jämför ord och ordning, inte översättningstexten."),
        new(
            "Vad är glosprogram.csproj?",
            ["Projektfilen för C#/.NET-programmet", "En CSV-ordlista", "En buggrapport", "Ett quizresultat"],
            0,
            "En .csproj-fil beskriver .NET-projektet; .cproj är inte den vanliga ändelsen här."),
        new(
            "Vad beskriver README-filen i projektet?",
            ["Hur användaren startar och använder programmets funktioner", "Endast klassernas minnesadresser", "Bara prompt-historiken", "Automatiskt alla Git-commits"],
            0,
            "README ska spegla programmets aktuella användning och begränsningar.")
    ];

    public static void Run()
    {
        int score = 0;
        Console.WriteLine();
        Console.WriteLine($"Quiz: dagens projektarbete ({Questions.Length} frågor)");
        Console.WriteLine("Svara med numret för ditt val.");

        for (int questionIndex = 0; questionIndex < Questions.Length; questionIndex++)
        {
            QuizQuestion question = Questions[questionIndex];
            Console.WriteLine();
            Console.WriteLine($"Fråga {questionIndex + 1}/{Questions.Length}: {question.Text}");

            for (int optionIndex = 0; optionIndex < question.Options.Length; optionIndex++)
            {
                Console.WriteLine($"{optionIndex + 1}. {question.Options[optionIndex]}");
            }

            int? answer = ReadAnswer(question.Options.Length);
            if (answer is null)
            {
                Console.WriteLine();
                Console.WriteLine("Quizet avbröts eftersom inmatningen tog slut.");
                PrintScore(score, questionIndex);
                return;
            }

            if (answer.Value == question.CorrectOption)
            {
                score++;
                Console.WriteLine("Rätt! " + question.Explanation);
            }
            else
            {
                Console.WriteLine(
                    $"Inte riktigt. Rätt svar är {question.CorrectOption + 1}: " +
                    $"{question.Options[question.CorrectOption]}. {question.Explanation}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Quizet är klart!");
        PrintScore(score, Questions.Length);
    }

    private static int? ReadAnswer(int optionCount)
    {
        while (true)
        {
            Console.Write("Ditt svar: ");
            string? input = Console.ReadLine();

            if (input is null)
            {
                return null;
            }

            if (int.TryParse(input, out int answer) && answer >= 1 && answer <= optionCount)
            {
                return answer - 1;
            }

            Console.WriteLine($"Ange ett nummer mellan 1 och {optionCount}.");
        }
    }

    private static void PrintScore(int score, int answeredQuestions)
    {
        Console.WriteLine($"Poäng: {score}/{answeredQuestions}.");

        if (answeredQuestions > 0)
        {
            double percentage = score * 100.0 / answeredQuestions;
            Console.WriteLine($"Rätt: {percentage:F0}%.");
        }
    }

    private sealed record QuizQuestion(
        string Text,
        string[] Options,
        int CorrectOption,
        string Explanation);
}
