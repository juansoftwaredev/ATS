using ATS.Application.DTOs;
using ATS.Application.Interfaces;
using ATS.Domain.Entities;
using ATS.Infraestructure.Repositories.Implementations;

namespace ATS.Application.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CandidateRepository _repo;

        public CandidateService(CandidateRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CandidateDto>> GetAllAsync()
        {
            var candidates = await _repo.GetAllAsync();
            return [.. candidates.Select(c => new CandidateDto
            {
                IdCandidate = c.IdCandidate,
                Name = c.Name,
                Birthdate = c.Birthdate,
                Email = c.Email,
                InsertDate = c.InsertDate,
                ModifyDate = c.ModifyDate,
                Experiences = [.. c.Experiences.Select(e => new CandidateExperienceDto
                {
                    IdCandidateExperience = e.IdCandidateExperience,
                    IdCandidate = e.IdCandidate,
                    Company = e.Company,
                    Job = e.Job,
                    Description = e.Description,
                    Salary = e.Salary,
                    BeginDate = e.BeginDate,
                    EndDate = e.EndDate,
                    InsertDate = e.InsertDate,
                    ModifyDate = e.EndDate
                })]
            })];
        }

        public async Task<CandidateDto> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return null;
            return new CandidateDto
            {
                IdCandidate = c.IdCandidate,
                Name = c.Name,
                Birthdate = c.Birthdate,
                Email = c.Email,
                InsertDate = c.InsertDate,
                ModifyDate = c.ModifyDate,
                Experiences = [.. c.Experiences.Select(e => new CandidateExperienceDto 
                {
                    IdCandidateExperience = e.IdCandidateExperience,
                    IdCandidate = e.IdCandidate,
                    Company = e.Company,
                    Job = e.Job,
                    Description = e.Description,
                    Salary = e.Salary,
                    BeginDate = e.BeginDate,
                    EndDate = e.EndDate,
                    InsertDate = e.InsertDate,
                    ModifyDate = e.EndDate
                })]
            };
        }

        public async Task<int> CreateAsync(CreateCandidateDto dto)
        {
            var candidate = new Candidate(dto.Name, dto.Birthdate, DateTime.Now, dto.Email);
            foreach (var exp in dto.Experiences)
                candidate.AddExperience(exp.IdCandidate,
                    exp.Company,
                    exp.Job,
                    exp.Description,
                    exp.Salary,
                    exp.BeginDate,
                    exp.EndDate,
                    DateTime.Now,
                    exp.ModifyDate);
            await _repo.AddAsync(candidate);
            return candidate.IdCandidate;
        }

        public async Task UpdateAsync(int id, UpdateCandidateDto dto)
        {
            var candidate = await _repo.GetByIdAsync(id);
            if (candidate == null) return;

            List<CandidateExperience> experiences = [];

            if (dto.Experiences != null || dto.Experiences?.Count > 0)
            {
                foreach (var e in dto.Experiences)
                {
                    experiences.Add(new CandidateExperience(
                        id, e.IdCandidateExperience, e.Company, e.Job, e.BeginDate, e.EndDate, e.InsertDate, e.ModifyDate, e.Description, e.Salary));
                }
            }

            candidate.Update(dto.Name, dto.Birthdate, DateTime.Now, experiences, dto.Email);
            await _repo.UpdateAsync(candidate);
        }

        public async Task DeleteAsync(int id)
        {
            var candidate = await _repo.GetByIdAsync(id);
            if (candidate != null)
                await _repo.DeleteAsync(candidate);
        }
    }
}
