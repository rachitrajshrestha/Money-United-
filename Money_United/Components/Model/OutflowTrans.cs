public class OutflowTrans
{
    public int amount { get; set; }
    public string type { get; set; }
    public string source { get; set; }
    public string date { get; set; }
    public string tags { get; set; }
    public string note { get; set; }

    public OutflowTrans(int outflow_amount, string type, string outflow_source, string date, string tags, string note)
    {
        amount = outflow_amount;
        this.type = type;
        source = outflow_source;
        this.date = date;
        this.tags = tags;
        this.note = note;
    }
}
