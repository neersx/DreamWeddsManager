
using DreamWeddsManager.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace DreamWeddsManager.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}