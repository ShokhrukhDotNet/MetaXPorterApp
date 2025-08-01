﻿//==================================================
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
        public async Task ShouldModifyPersonAsync()
        {
            // given
            Person randomPerson = CreateRandomPerson();
            Person inputPerson = randomPerson;
            Person persistedPerson = inputPerson.DeepClone();
            Person updatedPerson = inputPerson;
            Person expectedPerson = updatedPerson.DeepClone();
            Guid InputPersonId = inputPerson.Id;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectPersonByIdAsync(InputPersonId))
                    .ReturnsAsync(persistedPerson);

            this.storageBrokerMock.Setup(broker =>
                broker.UpdatePersonAsync(inputPerson))
                    .ReturnsAsync(updatedPerson);

            // when
            Person actualPerson =
                await this.personService
                    .ModifyPersonAsync(inputPerson);

            // then
            actualPerson.Should().BeEquivalentTo(expectedPerson);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectPersonByIdAsync(InputPersonId), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdatePersonAsync(inputPerson), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
