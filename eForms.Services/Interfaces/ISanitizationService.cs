﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public interface ISanitizationService
    {
        string Sanitize(string html);
    }
}
