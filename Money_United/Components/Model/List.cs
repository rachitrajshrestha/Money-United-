﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Money_United.Components.Pages;

public class List
{
    public static List<InflowTrans> Inflows { get; set; } = new List<InflowTrans>();
    public static List<OutflowTrans> Outflows { get; set; } = new List<OutflowTrans>();
    public static List<DebtTrans> Debt { get; set; } = new List<DebtTrans>();

}
