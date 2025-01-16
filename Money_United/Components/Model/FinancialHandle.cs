using System.Data.SQLite;

public class FinancialHandle
{
    private SQLiteConnection _connection;
    string connection = @"Data Source=D:\Application development dev\Money_United\Money_United\Components\Model\money_united.db;Version=3;";

    public FinancialHandle()
    {
        _connection = new SQLiteConnection(connection);
        _connection.Open();
    }

}