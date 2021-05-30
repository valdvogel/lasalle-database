using MySql.Data.MySqlClient;
class Database
{
  private MySqlConnection con;
  public Database()
  {
    // database credentials
    string server = "lasalle2021.cgac2eh2inwd.us-east-2.rds.amazonaws.com";
    string user = "admin";
    string password = "Admin123!";
    string database = "jose";

    // database connection string
    string cs = $@"server={server};userid={user};password={password};database={database}";
    this.con = new MySqlConnection(cs);
    this.con.Open();
  }
  public string checkVersion()
  {
    var stm = "SELECT VERSION()";
    var cmd = new MySqlCommand(stm, this.con);

    var version = cmd.ExecuteScalar().ToString();
    // Console.WriteLine($"MySQL version: {version}");
    return $"MySQL version: {version}";
  }

  public void createTable()
  {
    using var cmd = new MySqlCommand();
    cmd.Connection = con;

    cmd.CommandText = "DROP TABLE IF EXISTS cars";
    cmd.ExecuteNonQuery();

    cmd.CommandText = @"CREATE TABLE cars(id INTEGER PRIMARY KEY AUTO_INCREMENT,
                    name TEXT, price INT)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Mercedes',57127)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Skoda',9000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volvo',29000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Bentley',350000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Citroen',21000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Hummer',41400)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volkswagen',21600)";
    cmd.ExecuteNonQuery();
  }

  public string dataReader()
  {
    string response = string.Empty;
    string sql = "SELECT * FROM cars";
    using var cmd = new MySqlCommand(sql, this.con);

    using MySqlDataReader rdr = cmd.ExecuteReader();

    response = ($"{rdr.GetName(0)} - {rdr.GetName(1)} - {rdr.GetName(2)} \n\r");

    while (rdr.Read())
    {
      response += rdr.GetInt32(0) + " - " + rdr.GetString(1) + " - " + rdr.GetString(2) + "\n\r";
    }
    return response;
  }

}