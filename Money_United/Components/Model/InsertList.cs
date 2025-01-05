using System;
using System.Data.SQLite;
using System.IO;

public class InsertList
{
    string connection = "Data Source=D:\\Application development dev\\Money_United\\Money_United\\Components\\Model\\money_united.db; Version=3;";
    SQLiteConnection conn;

    public InsertList()
    {
        conn = new SQLiteConnection(connection);
        conn.Open();
    }

    public void AddUser(string userName, string password, int amount)
    {
        string sqlQuery = "INSERT INTO users (userName, password, amount) VALUES (@userName, @password, @amount)";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@userName", userName);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@amount", amount);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateAmount(int userId, int updatedAmount)
    {
        string sqlQuery = "UPDATE users SET amount = @updatedAmount WHERE user_id = @userId";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@updatedAmount", updatedAmount);
            command.Parameters.AddWithValue("@userId", userId);
            command.ExecuteNonQuery();
        }
    }

    public void IncrementAmount(int userId, int amount)
    {
        string sqlQuery = "UPDATE users SET amount = amount + @amount WHERE user_id = @userId";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@userId", userId);
            command.ExecuteNonQuery();
        }
    }

    public void DecrementAmount(int userId, int amount)
    {
        string sqlQuery = "UPDATE users SET amount = amount - @amount WHERE user_id = @userId";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@userId", userId);
            command.ExecuteNonQuery();
        }
    }

    public int LogInflow(int userId, int incomeAmount, string incomeSource, DateOnly transactionDate, string type, string note)
    {
        string sqlQuery = "INSERT INTO inflows (user_id, inflow_amount, inflow_source, date, type, note) VALUES (@userId, @incomeAmount, @incomeSource, @transactionDate, @inflowtype, @inflowNote)";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@incomeAmount", incomeAmount);
            command.Parameters.AddWithValue("@incomeSource", incomeSource);
            command.Parameters.AddWithValue("@transactionDate", transactionDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@inflowtype", type);
            command.Parameters.AddWithValue("@inflowNote", note);
            command.ExecuteNonQuery();
        }
        return (int)conn.LastInsertRowId;
    }

    public void LogOutflow(int userId, int expenseAmount, string expenseSource, DateOnly transactionDate, string type, string note)
    {
        string sqlQuery = "INSERT INTO outflows (user_id, outflow_amount, outflow_source, date, type, note) VALUES (@userId, @expenseAmount, @expenseSource, @transactionDate, @outflowtype, @outflowNote )";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@expenseAmount", expenseAmount);
            command.Parameters.AddWithValue("@expenseSource", expenseSource);
            command.Parameters.AddWithValue("@transactionDate", transactionDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@outflowtype", type);
            command.Parameters.AddWithValue("@outflowNote", note);
            command.ExecuteNonQuery();
        }
    }

    public void InsertDebtEntry(int userId, int amount, string source, DateOnly date, string status, string note)
    {
        string sqlQuery = "INSERT INTO debt (user_id, debt_amount, debt_source, date, status, note) VALUES (@userId, @amount, @source, @date, @status, @note)";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@source", source);
            command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@note", note);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateDebtEntry(int debtId, int incomeId, int paidAmount, string updatedCategory)
    {
        string sqlQuery = "UPDATE debt SET income_id = @incomeId, type = @updatedCategory, debt_amount = @paidAmount WHERE debt_id = @debtId";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@incomeId", incomeId);
            command.Parameters.AddWithValue("@paidAmount", paidAmount);
            command.Parameters.AddWithValue("@updatedCategory", updatedCategory);
            command.Parameters.AddWithValue("@debtId", debtId);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateTagsEntry(int debtId, int incomeId, int paidAmount, string updatedCategory)
    {
        string sqlQuery = "UPDATE debt SET income_id = @incomeId, type = @updatedCategory, debt_amount = @paidAmount WHERE debt_id = @debtId";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@incomeId", incomeId);
            command.Parameters.AddWithValue("@paidAmount", paidAmount);
            command.Parameters.AddWithValue("@updatedCategory", updatedCategory);
            command.Parameters.AddWithValue("@debtId", debtId);
            command.ExecuteNonQuery();
        }
    }

    public void CloseDatabase()
    {
        conn.Close();
    }
}
