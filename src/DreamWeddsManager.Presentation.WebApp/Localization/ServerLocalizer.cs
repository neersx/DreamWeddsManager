﻿using Microsoft.Extensions.Localization;

namespace SmartAdmin.WebUI.Localization
{
    internal class ServerLocalizer<T> where T : class
    {
        public IStringLocalizer<T> Localizer { get; }

        public ServerLocalizer(IStringLocalizer<T> localizer)
        {
            Localizer = localizer;
        }
    }
}
