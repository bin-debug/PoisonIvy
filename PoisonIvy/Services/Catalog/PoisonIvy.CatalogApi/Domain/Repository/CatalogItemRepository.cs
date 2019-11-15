using Couchbase;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PoisonIvy.CatalogApi.Domain.Interfaces;
using PoisonIvy.CatalogApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoisonIvy.CatalogApi.Domain.Repository
{
    public class CatalogItemRepository : IRepository<CatalogItem>
    {
        private readonly IBucket _bucket;
        public IConfiguration Configuration { get; }

        public CatalogItemRepository(IBucketProvider bucketProvider, IConfiguration configuration)
        {
            Configuration = configuration;
            _bucket = bucketProvider.GetBucket("catalog");
        }

        public async Task<List<CatalogItem>> Get()
        {
            var query = "select * from catalog where type='catalogItem'";
            var result = await _bucket.QueryAsync<dynamic>(query);
            var results = new List<CatalogItem>();

            foreach (var row in result.Rows)
            {
                var obj = new CatalogItem();
                obj.CatalogItemID = row.catalog.catalogItemID;
                obj.CatalogItemName = row.catalog.catalogItemName;
                obj.CatalogItemPrice = row.catalog.catalogItemPrice;
                obj.Quantity = row.catalog.quantity;
                results.Add(obj);
            }

            return results;
        }

        public Task<string> Upsert(CatalogItem data)
        {
            string id = "";

            if (string.IsNullOrEmpty(data.CatalogItemID))
            {
                id = Guid.NewGuid().ToString();
                data.CatalogItemID = id;
            }
            else
                id = data.CatalogItemID.ToString();

            var doc = new Document<CatalogItem> { Id = id, Content = data };

            var result = _bucket.UpsertAsync<CatalogItem>(doc).Result;

            if (result.Status == Couchbase.IO.ResponseStatus.Success)
                return Task.FromResult(id);
            else
                return Task.FromResult(string.Empty);
        }
    }
}
