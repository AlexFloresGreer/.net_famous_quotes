using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DapperApp.Models;

namespace DapperApp.Repository {
    public class UserRepository : IRepository<User> {
        private string connectionString;
        public UserRepository() {
            connectionString = "server=localhost;userid=root;password=root;port=3307;database=csharp_quotes;SslMode=None";
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(User item){
            using (IDbConnection dbConnection = Connection) {
                string query = "INSERT INTO users (first_name, quote, created_at) VALUES (@first_name, @quote, NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }
        public User FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}