using Raven.Client.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilang.Phonetic
{
    public class People_BySoundex : AbstractIndexCreationTask<Person, People_BySoundex.Entry>
    {
        public class Entry
        {
            public string Id { get; set; }

            public string Soudex { get; set; }

            public string Name { get; set; }
        }

        public People_BySoundex()
        {
            Map = people => from person in people
                select new Entry
                {
                    Soudex = Soundex.Compute(person.Name),
                    Name = person.Name
                };

            AdditionalSources = new Dictionary<string, string>
            {
                ["ComputeAveragePrice.cs"] =
                    File.ReadAllText(Path.Combine(new[]
                        { AppContext.BaseDirectory, "..", "..", "..", "Phonetic", "Soundex.cs" }))
            };
        }
    }
}
