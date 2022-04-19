namespace OCPLibrary
{
    public interface IApplicantModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        IAccounts2 AccountProcessor { get; set; }
    }
}