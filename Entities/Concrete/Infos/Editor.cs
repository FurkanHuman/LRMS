﻿using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete.Infos
{
    public class Editor : FirstPagePersonBase, IEntity
    {
        public IList<AcademicJournal> AcademicJournals { get; set; }
    }
}