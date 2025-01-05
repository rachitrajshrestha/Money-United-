public class DebtTrans
{
    private int debtAmount;
    private string type;

    public int amount { get; set; }
    public string source { get; set; }
    public string date { get; set; }
    public string status { get; set; }
    public string note { get; set; }

    public DebtTrans(int debt_amount, string debt_source, string date, string status, string note)
    {
        amount = debt_amount;
        source = debt_source;
        this.date = date;
        this.status = status;
        this.note = note;
    }

    public DebtTrans(int debtAmount, string type, string source, string date)
    {
        this.debtAmount = debtAmount;
        this.type = type;
        this.source = source;
        this.date = date;
    }
}
