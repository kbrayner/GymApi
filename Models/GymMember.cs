using System.ComponentModel.DataAnnotations.Schema;

namespace GymApi.Models
{
    public class GymMember
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Registry { get; set; }
    }
}
