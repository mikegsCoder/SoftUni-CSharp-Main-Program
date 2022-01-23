using System.ComponentModel.DataAnnotations;

namespace Instagraph.DataProcessor.Dtos.Import
{
    public class UserFollowerImport
    {
        [Required]
        public string User { get; set; }

        [Required]
        public string Follower { get; set; }
    }
}
