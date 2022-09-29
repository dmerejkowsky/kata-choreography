using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Choreograhpy.Test
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
