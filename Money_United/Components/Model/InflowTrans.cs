
public class InflowTrans
{
    public int amount { get; set; }
    public string type { get; set; }
    public string source { get; set; }
    public string date { get; set; }
    public string tags { get; set; }
    public string note { get; set; }

    public InflowTrans() { }
    public InflowTrans(int inflow_amount, string type, string inflow_source, string date, string tags, string note)
    {
        amount = inflow_amount;
        this.type = type;
        source = inflow_source;
        this.date = date;
        this.tags = tags;
        this.note = note;
    }


} 
