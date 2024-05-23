using System.ComponentModel.DataAnnotations;

namespace MeetUp.ViewModels.Speakers
{
    public class CreateSpeakerVM
    {

        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Subtitle { get; set; }
    }
}
