using System.Text.Json;
using DreamWeddsManager.Application.Interfaces.Serialization.Options;

namespace DreamWeddsManager.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}