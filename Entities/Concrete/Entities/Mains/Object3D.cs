﻿namespace Entities.Concrete.Entities.Mains
{
    public class Object3D : MaterialBase, IEntity
    {
        [Required]
        public Guid OwnerId { get; set; }

        public OtherPeople Owner { get; set; }

        [Required]
        public Guid ImageId { get; set; }

        public bool IsDestroyed { get; set; }

        public IList<Image> Images { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
