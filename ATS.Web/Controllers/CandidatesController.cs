using ATS.Application.DTOs;
using ATS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ATS.Web.Controllers
{
    public class CandidatesController(ICandidateService service) : Controller
    {
        private readonly ICandidateService _service = service;

        public async Task<IActionResult> Index()
        {
            var candidates = await _service.GetAllAsync();
            return View(candidates);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCandidateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var candidate = await _service.GetByIdAsync(id);
            if (candidate is null) return NotFound();

            return View(new UpdateCandidateDto()
            {
                Name = candidate.Name,
                Birthdate = candidate.Birthdate,
                Email = candidate.Email,
                InsertDate = candidate.InsertDate,
                ModifyDate = candidate.ModifyDate,
                Experiences = candidate.Experiences
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateCandidateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _service.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var candidate = await _service.GetByIdAsync(id);
            if (candidate is null) return NotFound();

            return View(candidate);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int IdCandidate)
        {
            await _service.DeleteAsync(IdCandidate);
            return RedirectToAction(nameof(Index));
        }
    }
}
