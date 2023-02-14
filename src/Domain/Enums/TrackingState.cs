﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWeddsManager.Domain.Enums
{
    public enum TrackingState
    {
        /// <summary>Existing entity that has not been modified.</summary>
        Unchanged,
        /// <summary>Newly created entity.</summary>
        Added,
        /// <summary>Existing entity that has been modified.</summary>
        Modified,
        /// <summary>Existing entity that has been marked as deleted.</summary>
        Deleted
    }
}
