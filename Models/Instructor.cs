using System.ComponentModel.DataAnnotations.Schema;

namespace GymApi.Models
{
    public class Instructor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CREF { get; set; }
    }
}
