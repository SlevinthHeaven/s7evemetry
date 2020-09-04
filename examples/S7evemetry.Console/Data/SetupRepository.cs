using Microsoft.Azure.Cosmos;
using S7evemetry.Console.Entities;
using S7evemetry.F1_2020.Structures;
using System.Threading.Tasks;

namespace S7evemetry.Console.Data
{
    public class SetupRepository
    {
        private readonly Container _cosmosContainer;
        public SetupRepository(CosmosClient cosmosClient)
        {
            _cosmosContainer = cosmosClient.GetContainer("S7evemetry", "SetupData");
        }

        public Task SaveAsync(int index, float timeSpan,  CarSetup carLap)
        {
            var objectToSave = new CosmosObject<CarSetup>
            {
                Id = $"14900522::{index}::{timeSpan}",
                ChannelId = "14900522",
                Item = carLap
            };
            return _cosmosContainer.UpsertItemAsync(objectToSave, new PartitionKey("14900522"));
        }
    }
}
