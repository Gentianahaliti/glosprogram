Console.WriteLine("glosprogram");

// UC-03: Hitta alla CSV-ordlistor i programmets wordlist-mapp.
string wordListDirectory = Path.Combine(AppContext.BaseDirectory, "wordlist");
string[] wordListPaths = Directory.GetFiles(wordListDirectory, "*.csv")
    .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
    .ToArray();

if (wordListPaths.Length == 0)
{
    throw new FileNotFoundException($"Inga CSV-ordlistor hittades i mappen '{wordListDirectory}'.");
}

List<TranslationFile> translationFiles = [];

foreach (string wordListPath in wordListPaths)
{
    // UC-02: Filnamnet anger källspråk och målspråk, till exempel swedish.english.csv.
    string[] languagePair = Path.GetFileNameWithoutExtension(wordListPath).Split('.');
    if (languagePair.Length != 2 ||
        string.IsNullOrWhiteSpace(languagePair[0]) ||
        string.IsNullOrWhiteSpace(languagePair[1]))
    {
        throw new InvalidDataException(
            $"Filnamnet '{Path.GetFileName(wordListPath)}' måste ha format källspråk.målspråk.csv.");
    }

    string[] wordLines = File.ReadAllLines(wordListPath);
    List<Word> words = [];

    // UC-01: Läs in varje CSV-rad som ett Word-objekt.
    for (int lineNumber = 0; lineNumber < wordLines.Length; lineNumber++)
    {
        string[] wordPair = wordLines[lineNumber].Split(',', 2);
        if (wordPair.Length != 2 ||
            string.IsNullOrWhiteSpace(wordPair[0]) ||
            string.IsNullOrWhiteSpace(wordPair[1]))
        {
            throw new InvalidDataException(
                $"Ogiltig rad {lineNumber + 1} i '{Path.GetFileName(wordListPath)}': {wordLines[lineNumber]}");
        }

        words.Add(new Word(
            wordPair[0].Trim(),
            wordPair[1].Trim(),
            languagePair[0],
            languagePair[1]));
    }

    Dictionary<string, List<Word>> translationsByWord = words
        .GroupBy(word => word.WordIn)
        .ToDictionary(group => group.Key, group => group.ToList());

    translationFiles.Add(new TranslationFile(
        languagePair[0],
        languagePair[1],
        translationsByWord));
}

// UC-04: Visa språkpar som hittades och låt användaren välja ett.
Console.WriteLine("Tillgängliga språkpar:");
for (int index = 0; index < translationFiles.Count; index++)
{
    TranslationFile translationFile = translationFiles[index];
    Console.WriteLine($"{index + 1}. {translationFile.SourceLanguage} → {translationFile.TargetLanguage}");
}

TranslationFile? selectedTranslationFile = null;
while (selectedTranslationFile is null)
{
    Console.Write("Välj språkpar genom att ange dess nummer: ");
    string? selection = Console.ReadLine();

    if (selection is null)
    {
        Console.WriteLine("Ingen inmatning tillgänglig. Programmet avslutas.");
        return;
    }

    if (int.TryParse(selection, out int selectedIndex) &&
        selectedIndex >= 1 &&
        selectedIndex <= translationFiles.Count)
    {
        selectedTranslationFile = translationFiles[selectedIndex - 1];
    }
    else
    {
        Console.WriteLine("Ogiltigt val. Ange numret för ett av språkparen.");
    }
}

// UC-05: Sök efter användarens ord med det valda språkparet.
while (true)
{
    Console.Write($"Ange ett ord på {selectedTranslationFile.SourceLanguage}: ");
    string? wordToTranslate = Console.ReadLine();

    if (wordToTranslate is null)
    {
        Console.WriteLine("Ingen inmatning tillgänglig. Programmet avslutas.");
        break;
    }

    wordToTranslate = wordToTranslate.Trim();
    if (wordToTranslate.Length == 0)
    {
        Console.WriteLine("Skriv ett ord.");
        continue;
    }

    if (selectedTranslationFile.TranslationsByWord.TryGetValue(wordToTranslate, out List<Word>? translations))
    {
        foreach (Word translation in translations)
        {
            Console.WriteLine(translation.WordOut);
        }
    }
    else
    {
        Console.WriteLine("Ordet finns inte i den valda ordlistan.");
    }
}

class Word(string wordIn, string wordOut, string languageIn, string languageOut)
{
    public string WordIn { get; } = wordIn;
    public string WordOut { get; } = wordOut;
    public string LanguageIn { get; } = languageIn;
    public string LanguageOut { get; } = languageOut;
}

class TranslationFile(
    string sourceLanguage,
    string targetLanguage,
    Dictionary<string, List<Word>> translationsByWord)
{
    public string SourceLanguage { get; } = sourceLanguage;
    public string TargetLanguage { get; } = targetLanguage;
    public Dictionary<string, List<Word>> TranslationsByWord { get; } = translationsByWord;
}
