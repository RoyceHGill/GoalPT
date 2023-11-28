using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GoalPtApp.Models.Enum;

namespace GoalPtApp.Models.UserResources
{
    public class UserGoal
    {
        [Key]
        public int Id { get; set; }
        [StringLength(40)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; }

        [ReadOnly(true)]
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? DueDate { get; set; }

        public GoalStatusEnum Status { get; set; } = GoalStatusEnum.Acctive;

        public AppUser Author { get; set; }

        public AppUser Delegate { get; set; }

        public ICollection<UserObjective> Objectives { get; set; }

        public ICollection<AppUser> Agents { get; set; }
    }
}
