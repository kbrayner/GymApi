using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApi.Models
{
    public class TrainingPlanExercise
    {
        public int TrainingPlanId{ get; set; }
        public TrainingPlan TrainingPlan { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

    }
}
