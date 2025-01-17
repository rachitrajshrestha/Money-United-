using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class DebtManager
{
    // SQLite database connection string
    string connection = @"Data Source=D:\Application development dev\Money_United\Money_United\Components\Model\money_united.db;Version=3;";
    SQLiteConnection conn;

    // Constructor that opens a connection to the SQLite database
    public DebtManager()
    {
        conn = new SQLiteConnection(connection);
        conn.Open();
    }

    // Method to reduce debt based on a specified amount and user ID
    public void Debt_Collector(int amount, int userId)
    {
        // SQL queries for updating debt amount, clearing debt, and updating debt status
        string updateQuery = "UPDATE debt SET debt_amount = debt_amount - @amount WHERE debt_id = @id;";
        string updateQueryZero = "UPDATE debt SET debt_amount = 0 WHERE debt_id = @id;";
        string updateQueryType = "UPDATE debt SET status = 'Cleared' WHERE debt_id = @id;";
        string selectQuery = "SELECT debt_id, debt_amount FROM debt WHERE user_id = @userId;";

        // Retrieving debts for the specified user
        using (var cmd = new SQLiteCommand(selectQuery, conn))
        {
            cmd.Parameters.AddWithValue("@userId", userId);

            // Reading through each debt record
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int debtId = reader.GetInt32(reader.GetOrdinal("debt_id"));
                    int currentDebt = reader.GetInt32(reader.GetOrdinal("debt_amount"));
                    Debug.WriteLine(debtId);

                    if (currentDebt > 0)
                    {
                        if (currentDebt <= amount)
                        {
                            // Fully paid off the debt
                            using (var updateCmd = new SQLiteCommand(updateQueryZero, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@id", debtId);
                                updateCmd.ExecuteNonQuery();
                            }

                            // Mark the debt as cleared
                            using (var typeUpdateCmd = new SQLiteCommand(updateQueryType, conn))
                            {
                                typeUpdateCmd.Parameters.AddWithValue("@id", debtId);
                                typeUpdateCmd.ExecuteNonQuery();
                            }

                            // Deduct the paid amount from the total
                            amount -= currentDebt;
                        }
                        else
                        {
                            // Partially reduce the debt
                            using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@amount", amount);
                                updateCmd.Parameters.AddWithValue("@userId", userId);
                                updateCmd.Parameters.AddWithValue("@id", debtId);
                                updateCmd.ExecuteNonQuery();
                            }

                            break;
                        }

                        if (amount <= 0)
                        {
                            break;
                        }
                    }
                }
            }

            // Update the user's amount after debt reduction
            Console.WriteLine("Axa");
            DatabaseInsert insertList = new DatabaseInsert();
            insertList.IncrementAmount(1, amount);
        }
    }
}
