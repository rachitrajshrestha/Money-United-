using System.Data.SQLite;

public class Controller
{
    string connection = @"Data Source=D:\Application development dev\Money_United\Money_United\Components\Model\money_united.db;Version=3;";
    SQLiteConnection conn;

    public Controller()
    {
        conn = new SQLiteConnection(connection);
        conn.Open();
    }

    public int SelectAmount()
    {
        string select = @"SELECT amount FROM users;";  // Added LIMIT 1 to ensure only one value is returned

        using (var command = new SQLiteCommand(select, conn))
        {
            using (var value = command.ExecuteReader())
            {
                if (value.Read())
                {
                    return value.GetInt32(0);
                }
                return 0;
            }
        }
    }

    public void SelectInflow()
    {
        string select = @"SELECT inflow_amount, type, inflow_source, date, note FROM inflows;";

        using (var command = new SQLiteCommand(select, conn))
        {
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int inflowAmount = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0));
                    string type = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    string source = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    string date = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    string note = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

                    List.Inflows.Add(new InflowTrans(inflowAmount, type, source, date, note));
                }
            }
        }
    }

    public int SelectOutflow()
    {
        string select = @"SELECT outflow_amount, type, outflow_source, date, note FROM outflows;";  // Corrected to outflow_amount from outflows table

        using (var command = new SQLiteCommand(select, conn))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int outflowAmount = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0));
                    string type = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    string source = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    string date = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    string note = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

                    List.Outflows.Add(new OutflowTrans(outflowAmount, type, source, date, note));
                }
                return 0;
            }
        }
    }

    public int SelectDebt()
    {
        string select = @"SELECT debt_amount, status, debt_source, date, note FROM debt;";  // Corrected to debt_amount from debt table

        using (var command = new SQLiteCommand(select, conn))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int debtAmount = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0));
                    string type = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    string source = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    string date = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    string note = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

                    List.Debt.Add(new DebtTrans(debtAmount, type, source, date, note));
                }
                return 0;
            }
        }
    }

    public void selectDateInflow()
    {
        string query = @"
        SELECT date, amount, source, type, note
        FROM inflows
        ORDER BY date;";

        using (var command = new SQLiteCommand(query, conn))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    DateTime date = reader.IsDBNull(0) ? DateTime.MinValue : reader.GetDateTime(0);
                    int inflowAmount = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                    string source = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    string type = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    string note = reader.IsDBNull(3) ? string.Empty : reader.GetString(4);

                    List.Inflows.Add(new InflowTrans(inflowAmount, type, source, date.ToString("dd-mm-yyyyy"),note));
                }
            }
        }
    }


}
