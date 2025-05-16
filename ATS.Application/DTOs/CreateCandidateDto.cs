using System.ComponentModel.DataAnnotations;
using ATS.Domain.Entities;

namespace ATS.Application.DTOs
{
    public class CreateCandidateDto
    {
        public string Name { get; set; } = string.Empty;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public List<CandidateExperienceDto> Experiences { get; set; } = [];
    }
}
