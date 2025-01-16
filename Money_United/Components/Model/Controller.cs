using System.Data.SQLite;
using System.Diagnostics;
//using CoreMotion;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        string select = @"SELECT inflow_amount, type, inflow_source, date, tags, note FROM inflows;";

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
                    string tags = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    string note = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

                    List.Inflows.Add(new InflowTrans(inflowAmount, type, source, date, tags, note));
                }
            }
        }
    }

    public int SelectOutflow()
    {
        string select = @"SELECT outflow_amount, type, outflow_source, date, tags, note FROM outflows;";
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
                    string tags = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    string note = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

                    List.Outflows.Add(new OutflowTrans(outflowAmount, type, source, date, tags, note));
                }
                return 0;
            }
        }
    }

    public int SelectDebt()
    {
        string select = @"SELECT debt_amount, status, debt_source, date, tags, note FROM debt;";

        using (var command = new SQLiteCommand(select, conn))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int debtAmount = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0));
                    string status = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    string source = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    string date = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    string tags = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    string note = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

                    List.Debt.Add(new DebtTrans(debtAmount, status, source, date, tags, note));
                }
                return 0;
            }
        }
    }

    public int selectTags()
    {
        string select = @"SELECT tags_content FROM tags;";

        using (var command = new SQLiteCommand(select, conn))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tags = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);

                    List.Tags.Add(new TagsTrans(tags));
                }
                return 0;
            }
        }
    }

    public void selectDateInflow()
    {
        string select = @"SELECT inflow_amount, type, inflow_source, date, tags, note FROM inflows ORDER BY date;";

        using (var command = new SQLiteCommand(select, conn))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int inflowAmount = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0));
                    string type = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    string source = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    string date = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    string tags = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    string note = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

                    List.Inflows.Add(new InflowTrans(inflowAmount, type, source, date, tags, note));
                }
            }
        }
    }

    public int selectDateOutflow()
    {
        string select = @"SELECT outflow_amount, type, outflow_source, date, tags, note FROM outflows ORDER BY date;";

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
                    string tags = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    string note = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

                    List.Outflows.Add(new OutflowTrans(outflowAmount, type, source, date, tags, note));
                }
                return 0;
            }
        }
    }


    public int selectDateDebt()
    {
        string select = @"SELECT debt_amount, status, debt_source, date, tags, note FROM debt ORDER BY date;";

        using (var command = new SQLiteCommand(select, conn))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int debtAmount = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0));
                    string status = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    string source = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    string date = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    string tags = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    string note = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

                    List.Debt.Add(new DebtTrans(debtAmount, status, source, date, tags, note));
                }
                return 0;
            }
        }
    }

    public void searchFilterInflow(int userId, string type, string source, DateOnly date, DateOnly lastDate, string tags, string note, string order)
    {
        Debug.WriteLine(userId);
        Debug.WriteLine("type " + type);
        Debug.WriteLine("source"  + source);
        Debug.WriteLine("firstdate" + date);
        Debug.WriteLine("firstdate" + date.ToString("yyyy-MM-dd"));
        Debug.WriteLine("lastdate" + lastDate.ToString("yyyy-MM-dd"));
        Debug.WriteLine("tag: " + tags);
        Debug.WriteLine(note);
        Debug.WriteLine(order);

        string select = @"
        SELECT inflow_amount, type, inflow_source, date, tags, note
        FROM inflows
        WHERE 
              date BETWEEN @date AND @lastDate
              AND type LIKE CONCAT('%', @inflow_type, '%')
              AND tags LIKE CONCAT('%', @tags, '%')
              AND inflow_source LIKE CONCAT('%', @source, '%')
                ";

        using (var command = new SQLiteCommand(select, conn))
        {
            command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@lastDate", lastDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@inflow_type", type);
            command.Parameters.AddWithValue("@tags", tags);
            command.Parameters.AddWithValue("@source", source);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Debug.WriteLine("ayo");
                    List.Inflows.Add(new InflowTrans
                    {
                        amount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        type = reader.IsDBNull(1) ? "" : reader.GetString(1),
                        source = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        date = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        tags = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        note = reader.IsDBNull(5) ? "" : reader.GetString(5)

                    });
                }
            }
        }
    }

    public void searchFilterOutflow(int userId, string type, string source, DateOnly date, DateOnly lastDate, string tags, string note, string order)
    {
        Debug.WriteLine(userId);
        Debug.WriteLine("type " + type);
        Debug.WriteLine("source" + source);
        Debug.WriteLine("firstdate" + date);
        Debug.WriteLine("firstdate" + date.ToString("yyyy-MM-dd"));
        Debug.WriteLine("lastdate" + lastDate.ToString("yyyy-MM-dd"));
        Debug.WriteLine("tag: " + tags);
        Debug.WriteLine(note);
        Debug.WriteLine(order);

        string select = @"
        SELECT inflow_amount, type, inflow_source, date, tags, note
        FROM inflows
        WHERE 
              date BETWEEN @date AND @lastDate
              AND type LIKE CONCAT('%', @inflow_type, '%')
              AND tags LIKE CONCAT('%', @tags, '%')
              AND inflow_source LIKE CONCAT('%', @source, '%')
                ";

        using (var command = new SQLiteCommand(select, conn))
        {
            command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@lastDate", lastDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@inflow_type", type);
            command.Parameters.AddWithValue("@tags", tags);
            command.Parameters.AddWithValue("@source", source);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Debug.WriteLine("ayo");
                    List.Inflows.Add(new InflowTrans
                    {
                        amount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        type = reader.IsDBNull(1) ? "" : reader.GetString(1),
                        source = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        date = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        tags = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        note = reader.IsDBNull(5) ? "" : reader.GetString(5)

                    });
                }
            }
        }
    }



}
