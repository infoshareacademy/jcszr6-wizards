using System.ComponentModel.DataAnnotations;

namespace LogCollector.Dto
{
    public class LogDto
    {
        [Required]
        public DateTime TimeStamp { get; set; }
        [Required]
        [StringLength(256)]
        public string AppName { get; set; }
        [Required]
        [StringLength(64)]
        public string LogLevel { get; set; }
        [Required]
        [StringLength(1024)]
        public string LogMessage { get; set; }
        [StringLength(4096)]
        public string Exception { get; set; }
        [StringLength(16384)]
        public string Properties { get; set; }
    }
}
