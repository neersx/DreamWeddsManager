using AutoMapper;
using AutoMapper.QueryableExtensions;
using DreamWeddsManager.Application.Interfaces;
using DreamWeddsManager.Application.Interfaces.Caching;
using DreamWeddsManager.Application.KeyValues.Caching;
using DreamWeddsManager.Application.KeyValues.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DreamWeddsManager.Application.KeyValues.Queries.ByName
{
    public class KeyValuesQueryByName : IRequest<IEnumerable<KeyValueDto>>, ICacheable
    {
        public string Name { get; set; }

        public string CacheKey => KeyValueCacheKey.GetCacheKey(Name);

        public MemoryCacheEntryOptions Options => new MemoryCacheEntryOptions().AddExpirationToken(new CancellationChangeToken(KeyValueCacheTokenSource.ResetCacheToken.Token));
    }
    public class KeyValuesQueryByNameHandler : IRequestHandler<KeyValuesQueryByName, IEnumerable<KeyValueDto>>
    {

        private readonly IBlazorHeroContext _context;
        private readonly IMapper _mapper;

        public KeyValuesQueryByNameHandler(
            IBlazorHeroContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<KeyValueDto>> Handle(KeyValuesQueryByName request, CancellationToken cancellationToken)
        {
            var data = await _context.KeyValues.Where(x => x.Name == request.Name)
               .ProjectTo<KeyValueDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
            return data;
        }
    }
}
