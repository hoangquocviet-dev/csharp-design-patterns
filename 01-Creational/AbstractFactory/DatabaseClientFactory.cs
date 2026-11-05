namespace DesignPatterns.Creational.AbstractFactory;

public interface IDbConnection { string Connect(); }
public interface IDbCommand { string Execute(string sql); }

public class SqlConnection : IDbConnection { public string Connect() => "Connected to MSSQL"; }
public class SqlCommand : IDbCommand { public string Execute(string sql) => $"MSSQL Exec: {sql}"; }

public class MySqlConnection : IDbConnection { public string Connect() => "Connected to MySQL"; }
public class MySqlCommand : IDbCommand { public string Execute(string sql) => $"MySQL Exec: {sql}"; }

public interface IDatabaseFactory {
    IDbConnection CreateConnection();
    IDbCommand CreateCommand();
}

public class SqlServerFactory : IDatabaseFactory {
    public IDbConnection CreateConnection() => new SqlConnection();
    public IDbCommand CreateCommand() => new SqlCommand();
}

public class MySqlFactory : IDatabaseFactory {
    public IDbConnection CreateConnection() => new MySqlConnection();
    public IDbCommand CreateCommand() => new MySqlCommand();
}
