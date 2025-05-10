using System.ComponentModel.DataAnnotations;

namespace SimpleDoctor.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Doktor adı zorunludur")]
        [StringLength(100, ErrorMessage = "Doktor adı en fazla 100 karakter olabilir")]
        [Display(Name = "Doktor Adı")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Uzmanlık alanı zorunludur")]
        [StringLength(100, ErrorMessage = "Uzmanlık alanı en fazla 100 karakter olabilir")]
        [Display(Name = "Uzmanlık Alanı")]
        public string Specialty { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Yan dal en fazla 100 karakter olabilir")]
        [Display(Name = "Yan Dal")]
        public string? SubSpecialty { get; set; }

        [Required(ErrorMessage = "Mezun olduğu okul zorunludur")]
        [StringLength(200, ErrorMessage = "Okul adı en fazla 200 karakter olabilir")]
        [Display(Name = "Mezun Olduğu Okul")]
        public string GraduationSchool { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mezuniyet yılı zorunludur")]
        [Range(1950, 2024, ErrorMessage = "Geçerli bir mezuniyet yılı giriniz")]
        [Display(Name = "Mezuniyet Yılı")]
        public int GraduationYear { get; set; }

        [StringLength(500, ErrorMessage = "Özgeçmiş en fazla 500 karakter olabilir")]
        [Display(Name = "Özgeçmiş")]
        public string? Biography { get; set; }

        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Display(Name = "E-posta")]
        public string? Email { get; set; }

        [StringLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olabilir")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Çalışma Saatleri")]
        public string? WorkingHours { get; set; }

        public List<Appointment> Appointments { get; set; } = new();
    }
} 