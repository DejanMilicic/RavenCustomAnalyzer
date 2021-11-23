using Multilang;
using Raven.Client.Documents;

var session = DocumentStoreHolder.Store.OpenSession();

//session.Store(new Article
//{
//    Text = "This is a text about car",
//    Language = "en"
//});

//session.Store(new Article
//{
//    Text = "Je n'ai pas faim car j'ai pris le petit déjeuner",
//    Language = "fr"
//});

//session.SaveChanges();

string term = "car";

Console.WriteLine($"Searching French content for term : {term}" );

var res = session.Query<Search.Entry, Search>()
                            .Search(x => x.Text_fr, term)
                            .ProjectInto<Article>()
                            .ToList();

if (res.Count == 0)
    Console.WriteLine("\tNo results");
foreach (Article article in res)
    Console.WriteLine($"\t{article.Id}");


Console.WriteLine();
Console.WriteLine($"Searching English content for term : {term}" );

res = session.Query<Search.Entry, Search>()
                            .Search(x => x.Text_en, term)
                            .ProjectInto<Article>()
                            .ToList();

if (res.Count == 0)
    Console.WriteLine("\tNo results");
foreach (Article article in res)
    Console.WriteLine($"\t{article.Id}");


