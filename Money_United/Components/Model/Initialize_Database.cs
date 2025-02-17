﻿using System.Data.SQLite;

public class Initialize_Database
{
    string connection = @"Data Source=D:\Application development dev\Money_United\Money_United\Components\Model\money_united.db;Version=3;";

    // Checks if the database file exists, if not, creates a new database and adds an admin user
    public void DatabaseChecker()
    {
        if (File.Exists("D:\\Application development dev\\Money_United\\Money_United\\Components\\Model\\money_united.db"))
        {
            Console.WriteLine("Database file exists.");
        }
        else
        {
            Console.WriteLine("Database file does not exist.");
            CreateDatabase(); // Calls method to create a new database
            DatabaseInsert il = new DatabaseInsert();
            il.AddUser("admin", "admin", 0); // Adds admin user to the new database
        }
    }

    // Creates the SQLite database file if it does not exist
    private void CreateDatabase()
    {
        SQLiteConnection.CreateFile("money_united.db");
        Console.WriteLine("Database created successfully.");
        CreateTables(); // Calls method to create the required tables in the database
    }

    // Creates tables: users, inflows, outflows, debt, and tags in the database
    public void CreateTables()
    {
        string createUserQuery = @"
        CREATE TABLE users(
            user_id INTEGER PRIMARY KEY AUTOINCREMENT,
            userName TEXT NOT NULL,
            password TEXT NOT NULL,
            amount INTEGER
        );";

        string createInflowsQuery = @"
        CREATE TABLE inflows(
            inflows_id INTEGER PRIMARY KEY AUTOINCREMENT,
            user_id INTEGER,
            inflow_amount INTEGER,
            inflow_source,
            date TEXT,
            type TEXT,
            tags TEXT,
            note Text,
            FOREIGN KEY (user_id) REFERENCES users(user_id)
        );";

        string createOutflowsQuery = @"
        CREATE TABLE outflows(
            outflows_id INTEGER PRIMARY KEY AUTOINCREMENT,
            user_id INTEGER,
            outflow_amount INTEGER ,
            outflow_source,
            date TEXT,
            type TEXT,
            tags TEXT,
            note Text,
            FOREIGN KEY (user_id) REFERENCES users(user_id)
        );";

        string createDebtQuery = @"
        CREATE TABLE debt(
            debt_id INTEGER PRIMARY KEY AUTOINCREMENT,
            user_id INTEGER,
            debt_amount INTEGER,
            debt_source,
            date TEXT,
            status TEXT,
            tags TEXT,
            note Text,
            FOREIGN KEY (user_id) REFERENCES users(user_id)
        );";

        string createTagsQuery = @"
        CREATE TABLE tags(
            tags_id INTEGER PRIMARY KEY AUTOINCREMENT,
            user_id,
            tags_content TEXT,
            FOREIGN KEY (user_id) REFERENCES users(user_id)
        );";


        using (SQLiteConnection connex = new SQLiteConnection(connection))
        {
            connex.Open();
            using (SQLiteCommand sc = new SQLiteCommand(createUserQuery, connex))
            {
                sc.ExecuteNonQuery();
            }
            using (SQLiteCommand sc = new SQLiteCommand(createInflowsQuery, connex))
            {
                sc.ExecuteNonQuery();
            }
            using (SQLiteCommand sc = new SQLiteCommand(createOutflowsQuery, connex))
            {
                sc.ExecuteNonQuery();
            }
            using (SQLiteCommand sc = new SQLiteCommand(createDebtQuery, connex))
            {
                sc.ExecuteNonQuery();
            }
            using (SQLiteCommand sc = new SQLiteCommand(createTagsQuery, connex))
            {
                sc.ExecuteNonQuery();
            }
        }
    }
}