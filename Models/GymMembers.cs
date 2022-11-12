using System.ComponentModel.DataAnnotations.Schema;

namespace GymApi.Models
{
    public class GymMembers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
