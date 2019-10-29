using System;
using System.Threading.Tasks;
using Xunit;

namespace GarageApp.Tests
{
    public class CheckingOut_Fails
    {

        private readonly GarageParking SUT;

        public CheckingOut_Fails()
        {
            // Too many dependencies! And these dependencies have other dependencies.
            // Too many failure points! There should be a better way to unit test!!!
            SUT = new GarageParking(null, null, null);
        }

        [Fact]
        public async Task When_Ticket_Number_Is_Null_By_Raising_Exception()
        {
            // Arrange
            string invalidTicket = null;

            // Act
            var e = await Assert.ThrowsAsync<InvalidOperationException>(() => SUT.CheckOutAsync(invalidTicket, "bob@gmail.com", ReceiptFormat.Print));

            // Assert
            Assert.NotNull(e);
        }
    }
}