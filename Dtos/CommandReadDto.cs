using System.ComponentModel.DataAnnotations;

namespace MyAPi.Dtos{
    
    public class CommandReadDto
    {
        
        public int Id { get; set; }
        public string ?HowTo { get; set; }
        public string ?Platform { get; set; }
        public string ? Commandline { get; set; }

    }
}
