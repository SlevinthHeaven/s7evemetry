using Microsoft.Azure.Cosmos;
using S7evemetry.Console.Entities;
using S7evemetry.F1_2020.Structures;
using System.Threading.Tasks;

namespace S7evemetry.Console.Data
{
    public class CarLapRepository
    {
        private readonly Container _cosmosContainer;
        public CarLapRepository(CosmosClient cosmosClient)
        {
            _cosmosContainer = cosmosClient.GetContainer("S7evemetry", "CarLapData");
        }

        public Task SaveAsync(int index, float timeSpan,  CarLap carLap)
        {
            var objectToSave = new CosmosObject<CarLap>
            {
                Id = $"14900522::{index}::{timeSpan}",
                ChannelId = "14900522",
                Item = carLap
            };
            return _cosmosContainer.UpsertItemAsync(objectToSave, new PartitionKey("14900522"));
        }
    }
}
