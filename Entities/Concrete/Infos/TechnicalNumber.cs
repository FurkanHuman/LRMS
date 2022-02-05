﻿using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class TechnicalNumber : IEntity
    {
        [Key]
        public int Id { get; set; }

        public long? Barcode { get; set; }

        public ulong? ISBN { get; set; }

        public ulong? ISSN { get; set; }

        [MaxLength(64)]
        public string? CertificateCode { get; set; }

        public bool IsDeleted { get; set; }
    }
}