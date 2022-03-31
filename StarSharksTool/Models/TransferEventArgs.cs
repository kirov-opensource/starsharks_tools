namespace StarSharksTool.Models
{
    internal class TransferEventArgs : EventArgs
    {
        public int TokenId { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public bool Successful { get; set; }
    }
}
