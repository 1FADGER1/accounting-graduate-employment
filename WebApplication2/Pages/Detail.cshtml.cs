using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Pages
{
    public class DetailModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DetailModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<EmploymentStatus> EmploymentStatuses { get; set; } = default!;
        public IList<Workplace> Workplaces { get; set; } = default!;

        [BindProperty] public EmploymentStatusViewModel EmploymentStatus { get; set; } = default!;
        [BindProperty] public JobsViewModel Jobs { get; set; } = default!;
        [BindProperty] public MilitaryServiceViewModel MilitaryService { get; set; } = default!;
        [BindProperty] public SelfEmploymentViewModel SelfEmployment { get; set; } = default!;
        [BindProperty] public Student Student { get; set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            var student = await _context.Student.Include(s => s.Specialty).Include(s => s.Address).FirstOrDefaultAsync(m => m.ID == id);
            if (student != null)
            {
                Student = student;
            }
            else
                Console.WriteLine("Объект пустой");

            if (_context.EmploymentStatus != null)
                EmploymentStatuses = await _context.EmploymentStatus
                    .Include(e => e.SelfEmployment).Include(e => e.MilitaryServices).Include(e => e.Jobs).ThenInclude(j => j.Workplace)
                    .Where(e => e.IDStudent == id).OrderBy(e => e.StartDate)
                    .ToListAsync();
            if (_context.Workplace != null)
                Workplaces = await _context.Workplace.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            Console.WriteLine(Student.ID);
            if (EmploymentStatus.TypeEmployment != typeemployment.Работает)
            {
                ModelState.Remove("Jobs.IDWorkplace");
            }
            if (!ModelState.IsValid || EmploymentStatus == null)
            {
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    if (errors.Count > 0)
                    {
                        Console.WriteLine($"{key}: {string.Join(", ", errors.Select(e => e.ErrorMessage))}");
                    }
                }
                return NotFound();
            }

            EmploymentStatus.IDStudent = Student.ID;

            var newEmploymentStatus = new EmploymentStatus
            {
                IDStudent = EmploymentStatus.IDStudent,
                StartDate = EmploymentStatus.StartDate,
                TypeEmployment = EmploymentStatus.TypeEmployment
            };
            _context.EmploymentStatus.Add(newEmploymentStatus);
            await _context.SaveChangesAsync();

            if (EmploymentStatus.TypeEmployment == typeemployment.Работает && Jobs != null && _context.Jobs != null)
            {
                var newJob = new Jobs
                {
                    IDStatus = newEmploymentStatus.ID,
                    IDWorkplace = Jobs.IDWorkplace,
                    Position = Jobs.Position,
                    AvailabilityEmployment = Jobs.AvailabilityEmployment
                };
                _context.Jobs.Add(newJob);
            }

            if(EmploymentStatus.TypeEmployment == typeemployment.Самозанятый && SelfEmployment != null && _context.SelfEmployments != null)
            {
                var newSelfEmployment = new SelfEmployment
                {
                    IDStatus = newEmploymentStatus.ID,
                    TypeActivity = SelfEmployment.TypeActivity
                };
                _context.SelfEmployments.Add(newSelfEmployment);
            }

            if(EmploymentStatus.TypeEmployment == typeemployment.проходить_службу_в_ВС && MilitaryService != null && _context.MilitaryService != null) 
            {
                var newMilitaryService = new MilitaryService
                {
                    IDStatus = newEmploymentStatus.ID,
                    PlaceService = MilitaryService.PlaceService,
                    PostMilitary = MilitaryService.PostMilitary
                };
                _context.MilitaryService.Add(newMilitaryService);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/Detail", new { id = Student.ID });
        }

        public async Task<IActionResult> OnPostDeleteStudentAsync(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Address)
                .FirstOrDefaultAsync(m => m.ID == id);

            if(student != null && student.Address != null)
            {
                _context.Address.Remove(student.Address);
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDeleteStatusAsync(int? statusId)
        {
            if (statusId == null || _context.EmploymentStatus == null)
            {
                Console.WriteLine(statusId);
                Console.WriteLine(Student.ID);
                if (statusId == null)
                {
                    Console.WriteLine("пусто");
                }
                return NotFound();
            }

            var status = await _context.EmploymentStatus.FindAsync(statusId);

            if(status != null)
            {
                _context.EmploymentStatus.Remove(status);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Detail", new { id = Student.ID });
        }
    }
}
