using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Money_United.Components.Pages;

public static class List
{
    public static List<InflowTrans> Inflows { get; set; } = new List<InflowTrans>();
    public static List<OutflowTrans> Outflows { get; set; } = new List<OutflowTrans>();
    public static List<DebtTrans> Debt { get; set; } = new List<DebtTrans>();
    public static List<TagsTrans> Tags { get; set; } = new List<TagsTrans>();
    public static user user { get; set; } = new user();

    public static void ClearInflow()
    {
        Inflows.Clear();
    }

    public static void ClearOutflow()
    {
        Outflows.Clear();
    }
    public static void ClearDebt()
    {
        Debt.Clear();
    }
    public static void ClearTags()
    {
        Tags.Clear();
    }
}
