//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using MetaXPorterApp.Web.Models.Foundations.Persons;
using Moq;

namespace MetaXPorterApp.Web.Tests.Unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public async Task ShouldAddPersonAsync()
        {
            // given
            Person randomPerson = CreateRandomPerson();
            Person inputPerson = randomPerson;
            Person storagePerson = inputPerson;
            Person expectedPerson = storagePerson.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertPersonAsync(inputPerson))
                    .ReturnsAsync(storagePerson);

            // when
            Person actualPerson =
                await this.personService.AddPersonAsync(inputPerson);

            // then
            actualPerson.Should().BeEquivalentTo(expectedPerson);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertPersonAsync(inputPerson),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
