using ATS.Domain.Entities;

namespace ATS.Application.DTOs
{
    public class CandidateDto
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public List<CandidateExperienceDto> Experiences { get; set; }
    }
}
