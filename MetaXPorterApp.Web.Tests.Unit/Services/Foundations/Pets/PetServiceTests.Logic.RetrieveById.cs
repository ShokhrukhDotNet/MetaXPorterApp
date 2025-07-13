﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using MetaXPorterApp.Web.Models.Foundations.Pets;
using Moq;

namespace MetaXPorterApp.Web.Tests.Unit.Services.Foundations.Pets
{
    public partial class PetServiceTests
    {
        [Fact]
        public async Task ShouldRetrievePetByIdAsync()
        {
            // given
            Guid randomPetId = Guid.NewGuid();
            Guid inputPetId = randomPetId;
            Pet randomPet = CreateRandomPet();
            Pet persistedPet = randomPet;
            Pet expectedPet = persistedPet.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectPetByIdAsync(inputPetId))
                    .ReturnsAsync(persistedPet);

            // when
            Pet actualPet = await this
                .petService.RetrievePetByIdAsync(inputPetId);

            // then
            actualPet.Should().BeEquivalentTo(expectedPet);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectPetByIdAsync(inputPetId), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
