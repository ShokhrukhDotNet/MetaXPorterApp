//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Text.Json.Serialization;

namespace MetaXPorterApp.Web.Models.Foundations.Pets
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PetType
    {
        Unknown = 0,
        Cat = 1,
        Dog = 2,
        Parrot = 3,
        Other = 4
    }
}
