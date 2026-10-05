// Skriver programmets namn i konsolfönstret.
Console.WriteLine("glosprogram");

// Typen är List<Word>: en lista som innehåller Word-objekt.
// Detta är en lista, inte en array. Hakparenteserna nedan är en
// collection expression som fyller listan med startvärden.
List<Word> words = [];

// UC-01: Läs CSV-filen från programmets körmapp, där projektet kopierar den vid byggning.
string wordListPath = Path.Combine(AppContext.BaseDirectory, "swedish.english.csv");
string[] wordLines = File.ReadAllLines(wordListPath);

// UC-01: Omvandla varje CSV-rad till ett Word-objekt och lägg det i listan.
for (int lineNumber = 0; lineNumber < wordLines.Length; lineNumber++)
{
    string[] wordPair = wordLines[lineNumber].Split(',', 2);
    if (wordPair.Length != 2)
    {
        throw new InvalidDataException(
            $"Ogiltig rad {lineNumber + 1} i översättningsfilen: {wordLines[lineNumber]}");
    }

    words.Add(new Word(wordPair[0].Trim(), wordPair[1].Trim(), "swedish", "english"));
}

// Listor använder nollbaserade index: [0] är första posten och [1] den andra.
// words[1] har typen Word. Egenskapen WordOut har typen string,
// så Console.WriteLine skriver ut texten "home".
Console.WriteLine(words[1].WordOut);

// En Dictionary kan också användas för uppslag med en nyckel,
// till exempel ett svenskt ord. En vanlig nyckel kan dock bara ha ett värde,
// så en lista passar bättre här när ett ord kan ha flera översättningar.

Dictionary<string, List<Word>> swedishToEnglish = words
    .GroupBy(word => word.WordIn)
    .ToDictionary(
        group => group.Key,
        group => group.ToList());

// referera till ett ord ur vår array (hem på engelska):   // Skillnad mellan referens och primitiva värden. Wordout? Handlar om optimering.
//Console.WriteLine(swedishtoenglish["hem"][0].WordOut);

while (true)
{
    Console.WriteLine("Ange vilket ord du vill översätta");
    string? wordToTranslate = Console.ReadLine();

    // If it contains the key
    if (wordToTranslate is not null && swedishToEnglish.ContainsKey(wordToTranslate))
    {
        // loopa ut sysnonymer
        foreach (var word in swedishToEnglish[wordToTranslate])
        {
            Console.WriteLine(word.WordOut);
        }
    }
    else
    {
        Console.WriteLine("This word does not exist in this dictionary");
    }
}


// Word är en klass, alltså en egen typ som beskriver en glospost.
// Alla fyra konstruktorparametrar är string-typer.
class Word(string wordIn, string wordOut, string languageIn, string languageOut)
{
    // string: ordet på källspråket.
    public string WordIn { get; } = wordIn;

    // string: översättningen till målspråket.
    public string WordOut { get; } = wordOut;

    // string: språket som WordIn tillhör, till exempel "swedish".
    public string LanguageIn { get; } = languageIn;

    // string: språket som WordOut tillhör, till exempel "english".
    public string LanguageOut { get; } = languageOut;
}
