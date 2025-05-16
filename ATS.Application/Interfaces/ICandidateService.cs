using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Application.DTOs;

namespace ATS.Application.Interfaces
{
    public interface ICandidateService
    {
        Task<List<CandidateDto>> GetAllAsync();
        Task<CandidateDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateCandidateDto dto);
        Task UpdateAsync(int id, UpdateCandidateDto dto);
        Task DeleteAsync(int id);
    }
}
