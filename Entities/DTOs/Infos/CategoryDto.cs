﻿using Core.Entities.Abstract;

namespace Entities.DTOs.Infos
{
    public class CategoryDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
