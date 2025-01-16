public class DebtTrans
{
    private int debtAmount;
    private string type;

    public int amount { get; set; }
    public string status { get; set; }
    public string source { get; set; }
    public string date { get; set; }
    public string tags { get; set; }
    public string note { get; set; }

    public DebtTrans(int debt_amount, string status, string debt_source, string date,  string tags, string note)
    {
        amount = debt_amount;
        this.status = status;
        source = debt_source;
        this.date = date;
        this.tags = tags;   
        this.note = note;
    }
}
