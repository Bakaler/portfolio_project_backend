using System.ComponentModel.DataAnnotations;


namespace PortfolioBackend.Models.Calculator
{
    public class CalculateRequest
    {
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public required string user_input { get; set; }

        // [Required]
        [StringLength(50)]
        public required string command_line { get; set; }

        // [Required]
        [StringLength(50)]
        public required string equation_line { get; set; }
    }

    public class CalculateResponse
    {
        public required string equation_line { get; set; }
        public required string command_line { get; set; }
        public required string user_input { get; set; }
    }

}
