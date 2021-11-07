using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTest.Interfaces;

namespace WpfTest.Models
{
    public class Entity : IEntity
    {
        [Required]
        public int Id { get ; set ; }
    }
}
