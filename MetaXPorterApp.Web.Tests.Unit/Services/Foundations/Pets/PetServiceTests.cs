//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using MetaXPorterApp.Web.Brokers.Loggings;
using MetaXPorterApp.Web.Brokers.Storages;
using MetaXPorterApp.Web.Models.Foundations.Pets;
using MetaXPorterApp.Web.Services.Foundations.Pets;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

namespace MetaXPorterApp.Web.Tests.Unit.Services.Foundations.Pets
{
    public partial class PetServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IPetService petService;

        public PetServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.petService = new PetService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Pet CreateRandomPet() =>
            CreatePetFiller().Create();

        private IQueryable<Pet> CreateRandomPets()
        {
            return CreatePetFiller()
                .Create(count: GetRandomNumber()).AsQueryable();
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 9).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static SqlException GetSqlError() =>
            (SqlException)RuntimeHelpers.GetUninitializedObject(typeof(SqlException));

        private static T GetInvalidEnum<T>()
        {
            int randomNumber = GetRandomNumber();

            while (Enum.IsDefined(typeof(T), randomNumber) is true)
            {
                randomNumber = GetRandomNumber();
            }

            return (T)(object)randomNumber;
        }

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private static Filler<Pet> CreatePetFiller()
        {
            var filler = new Filler<Pet>();

            return filler;
        }
    }
}
