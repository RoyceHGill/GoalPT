using System.ComponentModel.DataAnnotations;
using GoalPtApp.Models.Enum;

namespace GoalPtApp.Models.UserResources
{
    public class UserObjective
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime DueDate { get; set; }

        public ObjectiveStatusEnum Status { get; set; } = ObjectiveStatusEnum.FutureObjective;

        public AppUser Author { get; set; }

        public AppUser Delegate { get; set; }

        public UserGoal Goal { get; set; }

        public ICollection<AppUser> Agents { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
