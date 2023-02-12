using DreamWeddsManager.Application.Common.Mappings;
using DreamWeddsManager.Domain.Enums;
using DreamWeddsManager.Domain.Entities;

namespace DreamWeddsManager.Application.KeyValues.DTOs
{
    public partial class KeyValueDto : IMapFrom<KeyValue>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public TrackingState TrackingState { get; set; }
    }
}
