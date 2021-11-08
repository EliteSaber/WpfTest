using System.ComponentModel.DataAnnotations;
using WpfTest.Interfaces;

namespace WpfTest.Models
{
    public class Entity : IEntity
    {
        [Required]
        public int Id { get ; set ; }
    }
}
