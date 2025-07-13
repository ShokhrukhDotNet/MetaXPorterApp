//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
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
        public async Task ShouldRetrievePersonByIdAsync()
        {
            // given
            Guid randomPersonId = Guid.NewGuid();
            Guid inputPersonId = randomPersonId;
            Person randomPerson = CreateRandomPerson();
            Person persistedPerson = randomPerson;
            Person expectedPerson = persistedPerson.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectPersonByIdAsync(inputPersonId))
                    .ReturnsAsync(persistedPerson);

            // when
            Person actualPerson = await this
                .personService.RetrievePersonByIdAsync(inputPersonId);

            // then
            actualPerson.Should().BeEquivalentTo(expectedPerson);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectPersonByIdAsync(inputPersonId), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
