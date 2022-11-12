using System.ComponentModel.DataAnnotations.Schema;

namespace GymApi.Models
{
    public class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
