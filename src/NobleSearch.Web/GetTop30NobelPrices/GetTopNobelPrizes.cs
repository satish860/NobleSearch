using FastEndpoints;
using NobleSearch.Model;
using Redis.OM;
using Redis.OM.Contracts;

namespace NobleSearch.Web.GetTop30NobelPrices
{
    public class GetTopNobelPrizes : Endpoint<EmptyRequest, List<Person>>
    {
        private readonly RedisConnectionProvider redisConnectionProvider;

        public GetTopNobelPrizes(RedisConnectionProvider redisConnectionProvider)
        {
            this.redisConnectionProvider = redisConnectionProvider;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/api/noblewinners");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            var provider = this.redisConnectionProvider.RedisCollection<Person>();
            var collection = provider.Skip(1).Take(30).ToList();
            await SendAsync(collection);
        }
    }
}
