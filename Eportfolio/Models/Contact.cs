using System.ComponentModel.DataAnnotations;

namespace Eportfolio.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Imię jest wymagane.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole Email jest wymagane.")]
        [EmailAddress(ErrorMessage = "Wprowadź prawidłowy adres email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole Treść wiadomości jest wymagane.")]
        public string Message { get; set; }

        public DateTime SentAt { get; set; }
    }
}

