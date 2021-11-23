using Multilang;
using Raven.Client.Documents;

var session = DocumentStoreHolder.Store.OpenSession();

Seed();

string term = "car";

DisplayResults("fr",
    session.Query<Search.Entry, Search>()
                                .Search(x => x.Text_fr, term)
                                .ProjectInto<Article>()
                                .ToList());


DisplayResults("en",
    session.Query<Search.Entry, Search>()
                                .Search(x => x.Text_en, term)
                                .ProjectInto<Article>()
                                .ToList());

foreach (string lang in new List<string> { "fr", "en" })
    DisplayResults(lang,
        session.Query<Search.Entry, Search>()
                                    .Search(x => x.Text[lang], term)
                                    .ProjectInto<Article>()
                                    .ToList());


void DisplayResults(string lang, List<Article> articles)
{
    Console.WriteLine();
    Console.WriteLine($"[Search2] Searching '{lang}' content for term : {term}");

    if (articles.Count == 0)
        Console.WriteLine("\tNo results");
    foreach (Article article in articles)
        Console.WriteLine($"\t{article.Id}");
}

void Seed()
{
    session.Store(new Article
    {
        Text = "This is a text about car",
        Language = "en"
    });

    session.Store(new Article
    {
        Text = "Je n'ai pas faim car j'ai pris le petit déjeuner",
        Language = "fr"
    });

    session.Store(new Article
    {
        Text = "The quick brown fox jumps over the lazy dog or a car",
        Language = ""
    });

    session.SaveChanges();
}


