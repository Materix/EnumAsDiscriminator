using System.ComponentModel.DataAnnotations;

namespace EnumAsDiscriminator.API
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }

        public Direction Direction { get; set; }
    }

    public enum Direction
    {
        Left,
        Right
    }
}