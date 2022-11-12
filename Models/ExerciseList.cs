using System.ComponentModel.DataAnnotations.Schema;

namespace GymApi.Models
{
    public class ExerciseList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
