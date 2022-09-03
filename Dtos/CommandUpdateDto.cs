using System.ComponentModel.DataAnnotations;

namespace MyAPi.Dtos{
    
    public class CommandUpdateDto
    {
       
        [Required]
        public string ?HowTo { get; set; }
        [Required]
        [MaxLength(10)]
        public string ?Platform { get; set; }
        [Required]
        
        public string ? Commandline { get; set; }

    }

}