﻿namespace Entities.Concrete.Entities.Bases
{
    public class FirstPagePersonBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SurName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
