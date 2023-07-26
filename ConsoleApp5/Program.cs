

string[] words = new string[]
{
    "ток","рост","кот","торс","Кто","фывап","рок"
};
string[][] _assertResult = new[]
       {
            new string[]{"ток", "кот", "Кто" },
            new string[]{"рост", "торс" },
            new string[]{"фывап" },
            new string[]{"рок" }
        };
var byDict = FindAnagrammsByDictionary(words);
var byLinq = FindAnagrammsByLinq(words);

Console.WriteLine();

Dictionary<string, List<string>> FindAnagrammsByDictionary(string[] words)
{
    var dictWords = new Dictionary<string, List<string>>();

    foreach (var word in words)
    {
        var chars = word.ToLower().ToArray();
        Array.Sort(chars);

        var sortedWord = new string(chars);
        if (!dictWords.ContainsKey(sortedWord))
            dictWords.Add(sortedWord, new List<string> { word });
        else
            dictWords[sortedWord].Add(word);
    }
    return dictWords;
}

Dictionary<string, List<string>> FindAnagrammsByLinq(string[] words)
{
    return words
    .GroupBy(x => x, new AnagrammEqualityComparer(ignoreCase: true))
    .ToDictionary(k => k.Key, v => v.ToList());
}

