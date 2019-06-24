using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTest
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCanceledBy_SameUserCancelingThereservation_ReturnTrue()
        {
            //Arrange
            var user = new User();
            var reservation = new Reservation {MadeBy = user };

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.That(result, Is.True);

        }

        [Test]
        public void CanBeCanceledBy_AnotherUserCanCancellingReservation_ReturnIsFalse()
        {
            //Arrange
            var reservation = new Reservation { MadeBy = new User() };

            //Act
            var result = reservation.CanBeCancelledBy(new User());

            //Assert
            Assert.That(result, Is.False);

        }
    }
}
