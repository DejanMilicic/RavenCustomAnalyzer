using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lucene.Net.Documents.Field;

namespace Multilang.Phonetic
{
    public static class SoundexDemo
    {
        public static IDocumentStore GertStore()
        {
            var store = (new DocumentStore
            {
                Urls = new[] { "http://127.0.0.1:8080" },
                Database = "People"
            }).Initialize();

            IndexCreation.CreateIndexes(new AbstractIndexCreationTask[] { new People_BySoundex() }, store);

            return store;
        }

        public static void Seed()
        {
            using var session = GertStore().OpenSession();

            session.Store(new Person {Name = "Robert" });
            session.Store(new Person {Name = "Rupert" });
            session.Store(new Person {Name = "Rubin" });
            session.Store(new Person {Name = "Ashcraft" });
            session.Store(new Person {Name = "Ashcroft" });

            session.SaveChanges();
        }
    }
}
