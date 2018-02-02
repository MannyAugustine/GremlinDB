using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GremlinDB
{
    class Program
    {
        static async Task MainAsync(string[] args)
        {

            string endpoint = ConfigurationManager.AppSettings["https://gremlindb.documents.azure.com:443/"];
            string authKey = ConfigurationManager.AppSettings["1UyOhoGS7QQpFYOKy64jU98Bz5JvFrsJT9hTzFWRdNX8wuBfnccsQo3WLMnGclkuPRAOz0dt2ncE6D7YL5kVOQ=="];

            DocumentClient client = new DocumentClient(new Uri(endpoint), authKey);

            Database database = await client.CreateDatabaseIfNotExistsAsync(new Database { Id = "graphdb" });

            DocumentCollection graph = await client.CreateDocumentCollectionIfNotExistsAsync(
            UriFactory.CreateDatabaseUri("graphdb"),
            new DocumentCollection { Id = "graphcollz" },
            new RequestOptions { OfferThroughput = 1000 });



        }
    }
}
