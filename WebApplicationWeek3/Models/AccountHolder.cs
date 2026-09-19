namespace WebApplicationWeek3.Models
{
    public class AccountHolder
    {
        public int AccountHolderId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateofBirth { get; set; }
        public string socialsecurityNumber { get; set; }
        public string phoneNumber { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
    }
}
