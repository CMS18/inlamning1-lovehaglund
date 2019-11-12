using System.ComponentModel.DataAnnotations;

namespace ALMBank.Models.ViewModels
{
    public class TransferDto
    {
        public int FromAccountId { get; set; }

        public int ToAccountId { get; set; }

        public decimal Sum { get; set; }
    }
}
