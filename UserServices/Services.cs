using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace Web_Double.Services
{
    public class Services
    {
        private readonly string _connectionString;

        public Services(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Đăng ký người dùng mới
        public async Task<bool> RegisterUserAsync(string username, string email, string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("INSERT INTO Users (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                try
                {
                    await command.ExecuteNonQueryAsync();
                    return true;
                }
                catch (SqlException ex) when (ex.Number == 2627) // Lỗi trùng lặp khóa
                {
                    return false;
                }
            }
        }

        // Đăng nhập người dùng
        public async Task<int?> LoginUserAsync(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT Id, PasswordHash FROM Users WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var userId = reader.GetInt32(0); // Lấy userId từ cột đầu tiên
                        var passwordHash = reader.GetString(1);

                        if (BCrypt.Net.BCrypt.Verify(password, passwordHash))
                        {
                            return (int)reader["Id"]; // Trả về userId nếu mật khẩu đúng
                        }
                    }
                }
            }
            return null; // Trả về null nếu không tìm thấy
        }

    }
}