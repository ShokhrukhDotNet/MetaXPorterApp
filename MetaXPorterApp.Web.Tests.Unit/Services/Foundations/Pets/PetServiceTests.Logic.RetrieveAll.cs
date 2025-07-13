//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Linq;
using FluentAssertions;
using Force.DeepCloner;
using MetaXPorterApp.Web.Models.Foundations.Pets;
using Moq;

namespace MetaXPorterApp.Web.Tests.Unit.Services.Foundations.Pets
{
    public partial class PetServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllPets()
        {
            // given
            IQueryable<Pet> randomPet = CreateRandomPets();
            IQueryable<Pet> storagePet = randomPet;
            IQueryable<Pet> expectedPet = storagePet.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllPets())
                    .Returns(storagePet);

            // when
            IQueryable<Pet> actualPet =
                this.petService.RetrieveAllPets();

            // then
            actualPet.Should().BeEquivalentTo(expectedPet);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllPets(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
