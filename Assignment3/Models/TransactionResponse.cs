namespace Assignment3.Models
{
    public class TransactionResponse
    {
        public Transaction transaction { get; set; }
        public string error { get; set; } = string.Empty;

        public TransactionResponse()
        {
            transaction = new Transaction();

        }

    }
}
