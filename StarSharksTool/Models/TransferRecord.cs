using StarSharksTool.Enums;

namespace StarSharksTool.Models
{
    public class TransferRecord
    {
        public string? From { get; set; }
        public string? To { get; set; }
        public int TokenId { get; set; }
        public SharkType SharkType { get; set; } = SharkType.Shark;
    }
}
