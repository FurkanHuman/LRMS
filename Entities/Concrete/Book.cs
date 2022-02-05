﻿using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete
{
    public class Book : BasePaper, IEntity
    {
        public string? OriginalBookName { get; set; }
    }
}
