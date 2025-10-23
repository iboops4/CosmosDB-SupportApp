using Microsoft.Azure.Cosmos;
using CosmoooDB.Models;

namespace CosmoooDB.Services
{
    public class CosmosService
    {
        private readonly Container _container;

        public CosmosService(string connectionString, string databaseName, string containerName)
        {
            // Opret CosmosClient med connection string fra appsettings.json
            var client = new CosmosClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _container = database.GetContainer(containerName);
        }

        // 🔹 Opret ny supporthenvendelse
        public async Task AddSupportMessageAsync(SupportMessage message)
        {
            if (string.IsNullOrWhiteSpace(message.Id))
                message.Id = Guid.NewGuid().ToString();

            message.CreatedAt = DateTime.UtcNow;

            await _container.CreateItemAsync(message, new PartitionKey(message.Category));
        }

        // 🔹 Hent alle henvendelser
        public async Task<List<SupportMessage>> GetAllMessagesAsync()
        {
            var query = _container.GetItemQueryIterator<SupportMessage>("SELECT * FROM c");
            var results = new List<SupportMessage>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }

            // Sortér nyeste først
            return results.OrderByDescending(m => m.CreatedAt).ToList();
        }
    }
}
