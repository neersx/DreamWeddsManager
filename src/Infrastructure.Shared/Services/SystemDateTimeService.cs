using DreamWeddsManager.Application.Interfaces.Services;
using System;

namespace DreamWeddsManager.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}