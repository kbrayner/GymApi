using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApi.Models
{
    public class TrainingPlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainingPlanId { get; set; }
        [Required(ErrorMessage = "The training plan name is required")]
        [StringLength(50, ErrorMessage ="The training plan name must have at most 50 character")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The training plan description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The training plan start date is required")]
        public DateOnly StartDate { get; set; }
        [Required(ErrorMessage = "The training plan end date is required")]
        public DateOnly EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
