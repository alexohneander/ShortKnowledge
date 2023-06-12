using ShortKnowledge.Models;
namespace ShortKnowledge.Helpers;

public static class LocalizationHelper
{
public static IEnumerable<Language> Languages = new List<Language> { 
    new Language {
        Name = "English",
        Code = "en",
        query = "Summarize the following text for me to a maximum of 100 words and in English: "
    },
    new Language {
        Name = "German",
        Code = "de",
        query = "Fasse mir folgenden Text auf maximal 100 Wörter und auf deutsch zusammen: "
    }
};
}
