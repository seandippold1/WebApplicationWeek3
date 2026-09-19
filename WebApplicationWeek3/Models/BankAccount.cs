namespace WebApplicationWeek3.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public string accountNumber { get; set; }
        public decimal accountBalance { get; set; }
        public string accountName { get; set; }
        public string accountType { get; set; }
        public string originator { get; set; }
        public AccountHolder AccountHolder { get; set; }
        public int AccountHolderId { get; set; }
    }
}
