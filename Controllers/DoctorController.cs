using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleDoctor.Data;
using SimpleDoctor.Models;
using Microsoft.Extensions.Logging;

namespace SimpleDoctor.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(ApplicationDbContext context, ILogger<DoctorController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return View(doctors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    _logger.LogWarning("Details action called with null id");
                    return NotFound();
                }

                _logger.LogInformation($"Fetching doctor details for id: {id}");
                
                var doctor = await _context.Doctors
                    .Include(d => d.Appointments)
                    .FirstOrDefaultAsync(d => d.Id == id);

                if (doctor == null)
                {
                    _logger.LogWarning($"Doctor not found with id: {id}");
                    return NotFound();
                }

                _logger.LogInformation($"Found doctor: {doctor.Name}");
                return View(doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching doctor details for id: {id}");
                return StatusCode(500, "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    _logger.LogWarning("Edit action called with null id");
                    return NotFound();
                }

                var doctor = await _context.Doctors.FindAsync(id);
                if (doctor == null)
                {
                    _logger.LogWarning($"Doctor not found with id: {id}");
                    return NotFound();
                }

                return View(doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching doctor for edit with id: {id}");
                return StatusCode(500, "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Doctor doctor)
        {
            try
            {
                if (id != doctor.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(doctor);
                        await _context.SaveChangesAsync();
                        _logger.LogInformation($"Doctor updated successfully: {doctor.Name}");
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DoctorExists(doctor.Id))
                        {
                            return NotFound();
                        }
                        throw;
                    }
                }
                return View(doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating doctor with id: {id}");
                return StatusCode(500, "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
} 