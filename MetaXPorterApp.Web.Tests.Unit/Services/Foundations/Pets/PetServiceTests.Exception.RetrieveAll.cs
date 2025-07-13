﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using FluentAssertions;
using MetaXPorterApp.Web.Models.Foundations.Pets.Exceptions;
using Microsoft.Data.SqlClient;
using Moq;

namespace MetaXPorterApp.Web.Tests.Unit.Services.Foundations.Pets
{
    public partial class PetServiceTests
    {
        [Fact]
        public void ShouldThrowCriticalDependencyExceptionOnRetrieveAllWhenSqlExceptionOccursAndLogIt()
        {
            // given
            SqlException sqlException = GetSqlError();

            var failedPetStorageException =
                new FailedPetStorageException(sqlException);

            var expectedPetDependencyException =
                new PetDependencyException(failedPetStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllPets()).Throws(sqlException);

            // when
            Action retrieveAllPetsAction = () =>
                this.petService.RetrieveAllPets();

            PetDependencyException actualPetDependencyException =
                Assert.Throws<PetDependencyException>(retrieveAllPetsAction);

            // then
            actualPetDependencyException.Should()
                .BeEquivalentTo(expectedPetDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllPets(), Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedPetDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOccursAndLogItAsync()
        {
            // given
            string exceptionMessage = GetRandomString();
            var serverException = new Exception(exceptionMessage);

            var failedPetServiceException =
                new FailedPetServiceException(serverException);

            var expectedPetServiceException =
                new PetServiceException(failedPetServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllPets()).Throws(serverException);

            // when
            Action retrieveAllPetActions = () =>
                this.petService.RetrieveAllPets();

            PetServiceException actualPetServiceException =
                Assert.Throws<PetServiceException>(retrieveAllPetActions);

            //then
            actualPetServiceException.Should()
                .BeEquivalentTo(expectedPetServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllPets(), Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedPetServiceException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
