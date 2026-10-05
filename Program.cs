// Skriver programmets namn i konsolfönstret.
Console.WriteLine("glosprogram");

// Typen är List<Word>: en lista som innehåller Word-objekt.
// Detta är en lista, inte en array. Hakparenteserna nedan är en
// collection expression som fyller listan med startvärden.
List<Word> words = []

// fyll listan med ord från (swedish.english.cvs) filen)
foreach(string line in File.ReadAlllines("./swedish.english.cvs"))
{
   String[] wordpair = line.Split(",");    
  words.Add(new Word(wordpair[0], wordpair[1], "swedish", "english"));
};

[
    // Varje new Word(...) skapar ett Word-objekt.
    // Orden och språknamnen inom citationstecken är av typen string.
    new Word("hus", "house", "swedish", "english"),
    new Word("hem", "home", "swedish", "english"),

    // "stor" förekommer två gånger eftersom det har två översättningar.
    // På så sätt kan flera synonymer/översättningar sparas som egna poster.
    new Word("stor", "big", "swedish", "english"),
    new Word("stor", "large", "swedish", "english")
     // stor => big, large
];

// Listor använder nollbaserade index: [0] är första posten och [1] den andra.
// words[1] har typen Word. Egenskapen WordOut har typen string,
// så Console.WriteLine skriver ut texten "home".
Console.WriteLine(words[1].WordOut);

// En Dictionary kan också användas för uppslag med en nyckel,
// till exempel ett svenskt ord. En vanlig nyckel kan dock bara ha ett värde,
// så en lista passar bättre här när ett ord kan ha flera översättningar.

Dictionary<string, List<Word>> swedishToEnglish = Words  // du använder nyckeln här som är word.WordIn
GroupBy(word => word.WordIn)
ToDictionary(
    x => x.key  //nyckeln   // Varför blir det null här? // för att det är en referens!  //spelar ingen roll vasd vi kallar det kan vara word x,z osv det är för jag ska förstår vad jag håller på med
    z => z.ToList()  // värdet -typsikt hela objektet (referensen) //Pritiv// Pekar på en redan minnesplats.
);

// referera till ett ord ur vår array (hem på engelska):   // Skillnad mellan referens och primitiva värden. Wordout? Handlar om optimering.
//Console.WriteLine(swedishtoenglish["hem"][0].WordOut);

While (true)
{
    
Console .WriteLine("Ange vilket ord du vill översätta");
string? wordToTranslate = Console.ReadLine();

// If it contains the key 
if (SwedishToEnglish.Cointainskey(wordToTranslate!))= Console.ReadLine()


// loopa ut sysnonymer 
foreach(var word in SwedishToEnglish["hem"])
{}
    Console.WriteLine(word,wordout);
}
{
else
Consolee.WriteLine("This word does not exist in this dictionary");
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

