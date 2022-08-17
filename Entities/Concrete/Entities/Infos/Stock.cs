﻿namespace Entities.Concrete.Entities.Infos
{
    public class Stock : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid LibraryId { get; set; }

        public Library Library { get; set; }

        [Required]
        public string StockCode { get; set; }

        [Required]
        public uint Quantity { get; set; } = 1;

        public bool IsDeleted { get; set; }
    }
}
