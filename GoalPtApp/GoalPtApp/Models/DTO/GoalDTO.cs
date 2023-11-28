using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoalPtApp.Models.DTO
{
    public class GoalDTO
    {
        [StringLength(100)]
        public string? Title { get; set; } = string.Empty;
    }
}
