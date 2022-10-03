using System.Net.Http.Headers;
using Xunit;


namespace Choreography.Test
{
    public class InventoryTest
    {
        private readonly SpyLogger logger;
        private readonly Inventory inventory;
        public InventoryTest()
        {
            logger = new SpyLogger();
            var context = new Context(logger, bus);
            var bus = new EventBus()
            inventory = new Inventory(logger, 100);
        }

        [Fact]
        public void UpdateCapacityWhenEnoughFreeSeats()
        {
            inventory.DecrementCapacity(10);

            var newCapacity = inventory.CurrentCapacity();
            Assert.Equal(90, newCapacity);
        }

        [Fact]
        public void ThrowWhenOverBooked()
        {
            Assert.Throws<OverbookedException>(() => inventory.DecrementCapacity(120));
        }
    }
}
