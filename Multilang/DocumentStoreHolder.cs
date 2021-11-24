using Raven.Client.Documents.Indexes.Analysis;
using Raven.Client.ServerWide.Operations.Analyzers;

namespace Multilang;

using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;

public static class DocumentStoreHolder
{
    private static readonly Lazy<IDocumentStore> LazyStore =
        new Lazy<IDocumentStore>(() =>
        {
            IDocumentStore store = new DocumentStore
            {
                Urls = new[] { "http://127.0.0.1:8080" },
                Database = "articles"
            };

            store.Initialize();

            // https://github.com/ravendb/lucenenet/tree/ravendb/v5.2/src/contrib/Analyzers/Fr
            store.Maintenance.Server.Send(new PutServerWideAnalyzersOperation(
                new AnalyzerDefinition
                {
                    Name = "FrenchAnalyzer",
                    Code = File.ReadAllText(Path.Combine(new []{"..", "..", "..", "Lucene", "FrenchAnalyzer.cs" }))
                }));

            IndexCreation.CreateIndexes(typeof(Program).Assembly, store);

            return store;
        });

    public static IDocumentStore Store => LazyStore.Value;
}
