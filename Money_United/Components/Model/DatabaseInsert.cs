using System;
using System.Data.SQLite;
using System.IO;
using Money_United.Components.Pages;

public class DatabaseInsert
{
    string connection = "Data Source=D:\\Application development dev\\Money_United\\Money_United\\Components\\Model\\money_united.db; Version=3;";
    SQLiteConnection conn;

    // Constructor that initializes the SQLite connection and opens it
    public DatabaseInsert()
    {
        conn = new SQLiteConnection(connection);
        conn.Open();
    }

    // Adds a new user to the 'users' table
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

    // Updates the amount for a specific user
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

    // Increases the user's amount by a specified value
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

    // Decreases the user's amount by a specified value
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

    // Logs an inflow (income) transaction for a user
    public int LogInflow(int userId, int incomeAmount, string incomeSource, DateOnly transactionDate, string type, string usertags, string note)
    {
        string sqlQuery = "INSERT INTO inflows (user_id, inflow_amount, inflow_source, date, type, tags, note) VALUES (@userId, @incomeAmount, @incomeSource, @transactionDate, @inflowtype, @inflowtags, @inflowNote)";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@incomeAmount", incomeAmount);
            command.Parameters.AddWithValue("@incomeSource", incomeSource);
            command.Parameters.AddWithValue("@transactionDate", transactionDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@inflowtype", type);
            command.Parameters.AddWithValue("@inflowtags", usertags);
            command.Parameters.AddWithValue("@inflowNote", note);
            command.ExecuteNonQuery();
        }
        return (int)conn.LastInsertRowId;
    }

    // Logs an outflow (expense) transaction for a user
    public void LogOutflow(int userId, int expenseAmount, string expenseSource, DateOnly transactionDate, string type, string usertags, string note)
    {
        string sqlQuery = "INSERT INTO outflows (user_id, outflow_amount, outflow_source, date, type, tags, note) VALUES (@userId, @expenseAmount, @expenseSource, @transactionDate, @outflowtype, @outflowtags, @outflowNote)";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@expenseAmount", expenseAmount);
            command.Parameters.AddWithValue("@expenseSource", expenseSource);
            command.Parameters.AddWithValue("@transactionDate", transactionDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@outflowtype", type);
            command.Parameters.AddWithValue("@outflowtags", usertags);
            command.Parameters.AddWithValue("@outflowNote", note);
            command.ExecuteNonQuery();
        }
    }

    // Logs a debt entry for a user
    public void InsertDebtEntry(int userId, int amount, string source, DateOnly date, string status, string usertags, string note)
    {
        string sqlQuery = "INSERT INTO debt (user_id, debt_amount, debt_source, date, status, tags, note) VALUES (@userId, @amount, @source, @date, @status, @debttags, @note)";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@source", source);
            command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@debttags", usertags);
            command.Parameters.AddWithValue("@note", note);
            command.ExecuteNonQuery();
        }
    }

    // Inserts a tag entry for a user
    public void InsertTagsEntry(int userId, string tags)
    {
        string sqlQuery = "INSERT INTO tags (user_id, tags_content) VALUES (@userId, @tags_content)";
        using (var command = new SQLiteCommand(sqlQuery, conn))
        {
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@tags_content", tags);
            command.ExecuteNonQuery();
        }
    }

    // Closes the database connection
    public void CloseDatabase()
    {
        conn.Close();
    }
}