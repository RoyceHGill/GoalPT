using System.ComponentModel.DataAnnotations;
using GoalPtApp.Models.Enum;

namespace GoalPtApp.Models.UserResources
{
    public class UserTask : BaseModel
    {
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public string ObjectiveId { get; set; }

        public UserObjective UserObjective { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        public DateTime? StartTime { get; set; }

        public DateTime? DueTime { get; set; }

        public DateTime? Completed { get; set; }

        public DateTime? NotificationTime { get; set; }

        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.FutureTask;
    }
}
