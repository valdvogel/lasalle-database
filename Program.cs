using System;
using MySql.Data.MySqlClient;

namespace Version
{
  class Program
  {
    static void Main(string[] args)
    {
      Database objDb = new Database();

      string response = objDb.checkVersion();
      Console.WriteLine(response);

      objDb.createTable();
      string data = objDb.dataReader();
      Console.WriteLine(data);

    }
  }
}