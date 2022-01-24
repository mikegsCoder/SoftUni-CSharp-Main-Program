using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stations.DataProcessor.Dto.Import
{
    public class TrainImportDto
    {
        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        public string Type { get; set; }

        public List<SeatImportDto> Seats { get; set; } = new List<SeatImportDto>();
    }
}
