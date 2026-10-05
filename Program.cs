// Skriver programmets namn i konsolfönstret.
Console.WriteLine("glosprogram");

// Typen är List<Word>: en lista som innehåller Word-objekt.
// Detta är en lista, inte en array. Hakparenteserna nedan är en
// collection expression som fyller listan med startvärden.
List<Word> words =
[
    // Varje new Word(...) skapar ett Word-objekt.
    // Orden och språknamnen inom citationstecken är av typen string.
    new Word("hus", "house", "swedish", "english"),
    new Word("hem", "home", "swedish", "english"),

    // "stor" förekommer två gånger eftersom det har två översättningar.
    // På så sätt kan flera synonymer/översättningar sparas som egna poster.
    new Word("stor", "big", "swedish", "english"),
    new Word("stor", "large", "swedish", "english")
];

// Listor använder nollbaserade index: [0] är första posten och [1] den andra.
// words[1] har typen Word. Egenskapen WordOut har typen string,
// så Console.WriteLine skriver ut texten "home".
Console.WriteLine(words[1].WordOut);

// En Dictionary kan också användas för uppslag med en nyckel,
// till exempel ett svenskt ord. En vanlig nyckel kan dock bara ha ett värde,
// så en lista passar bättre här när ett ord kan ha flera översättningar.

Dictionary<string, Word> swedishToEnglish = words.ToDictionary(
    word => word.WordIn  //nyckeln   // Varför blir det null här? // för att det är en referens!
    word => word.WordOut  // värdet -typsikt hela objektet (referensen) //Pritiv// Pekar på en redan minnesplats.
);

// referera till ett ord ur vår array (hem på engelska):   // Skillnad mellan referens och primitiva värden. Wordout? Handlar om optimering.
Console.WriteLine(words [1].WordOut);


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
