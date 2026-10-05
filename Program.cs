// Skriver programmets namn i konsolfönstret.
Console.WriteLine("glosprogram");

// List<Word> är en lista som fylls med Word-objekt när CSV-filen läses in.
List<Word> words = [];

// UC-01: Läs CSV-filen från programmets körmapp, där projektet kopierar den vid byggning.
string wordListPath = Path.Combine(AppContext.BaseDirectory, "swedish.english.csv");

// UC-02: Läs källspråk och målspråk från filnamnet, exempelvis swedish.english.csv.
string[] languagePair = Path.GetFileNameWithoutExtension(wordListPath).Split('.');
if (languagePair.Length != 2 ||
    string.IsNullOrWhiteSpace(languagePair[0]) ||
    string.IsNullOrWhiteSpace(languagePair[1]))
{
    throw new InvalidDataException(
        $"Filnamnet '{Path.GetFileName(wordListPath)}' måste ha format källspråk.målspråk.csv.");
}

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

    // UC-02: Spara språken från filnamnet på varje översättningspost.
    words.Add(new Word(wordPair[0].Trim(), wordPair[1].Trim(), languagePair[0], languagePair[1]));
}

// Listor använder nollbaserade index: [0] är första posten och [1] den andra.
// words[1] har typen Word. Egenskapen WordOut har typen string,
// så Console.WriteLine skriver ut texten "home".
Console.WriteLine(words[1].WordOut);

// En Dictionary kan också användas för uppslag med en nyckel,
// till exempel ett svenskt ord. En vanlig nyckel kan dock bara ha ett värde,
// så en lista passar bättre här när ett ord kan ha flera översättningar.

Dictionary<string, List<Word>> translationsByWord = words
    .GroupBy(word => word.WordIn)
    .ToDictionary(
        group => group.Key,
        group => group.ToList());

// Exempel på att hämta en översättning ur listan:
//Console.WriteLine(translationsByWord["hem"][0].WordOut);

while (true)
{
    Console.WriteLine("Ange vilket ord du vill översätta");
    string? wordToTranslate = Console.ReadLine();

    // Kontrollera om ordet finns som nyckel i ordlistan.
    if (wordToTranslate is not null && translationsByWord.ContainsKey(wordToTranslate))
    {
        // loopa ut sysnonymer
        foreach (var word in translationsByWord[wordToTranslate])
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
