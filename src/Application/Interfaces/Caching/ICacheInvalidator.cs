﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWeddsManager.Application.Interfaces.Caching;
public interface ICacheInvalidator
{
    string CacheKey { get => String.Empty; }
    CancellationTokenSource? SharedExpiryTokenSource { get => null; }
}

