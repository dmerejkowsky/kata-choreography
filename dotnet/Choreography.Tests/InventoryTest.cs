using Xunit;


namespace Choreography.Test
{
    public class InventoryTest
    {
        [Fact]
        public void UpdateCapacityWhenEnoughFreeSeats()
        {

            var inventory = new Inventory(100);
            inventory.DecrementCapacity(10);

            var newCapacity = inventory.CurrentCapacity();
        }

        [Fact]
        public void ThrowWhenOverBooked()
        {
            var inventory = new Inventory(10);
            Assert.Throws<OverbookedException>(() => inventory.DecrementCapacity(12));
        }
    }
}
