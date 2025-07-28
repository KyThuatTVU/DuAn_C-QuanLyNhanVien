// DatabaseConnection.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms; // Cần cho MessageBox

namespace QuanLyNhanSu
{
    public class DatabaseConnection
    {
        private static string connectionString = @"Server=LAPTOP-33ML5D4P\SQLEXPRESS;Database=LTUD_QLNV;Trusted_Connection=True;";
        // Bỏ biến conn toàn cục, mỗi phương thức nên tạo kết nối riêng với 'using'
        // private static SqlConnection conn = null;


        // Không cần phương thức GetConnection và CloseConnection nếu dùng 'using' trong mỗi phương thức
        /*
        public static SqlConnection GetConnection()
        {
            // ...
        }

        public static void CloseConnection()
        {
            // ...
        }
        */

        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    try
                    {
                        connection.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi thực thi CSDL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi không xác định khi thực thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = -1;
                    }
                }
            }
            return result;
        }

        public static DataTable GetData(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi không xác định khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return dt;
        }

        // *** SỬA PHƯƠNG THỨC NÀY ***
        // Phương thức thực thi lệnh và trả về một giá trị đơn (ví dụ: COUNT, MAX, giá trị một ô)
        public static object ExecuteScalar(string sql, SqlParameter[] parameters = null) // Đổi tên tham số cho nhất quán
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    // Thêm tham số nếu có
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    try
                    {
                        connection.Open(); // Mở kết nối
                        result = cmd.ExecuteScalar(); // Thực thi lệnh và lấy giá trị đơn
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi thực thi ExecuteScalar: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // result sẽ vẫn là null
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi không xác định khi thực thi ExecuteScalar: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // result sẽ vẫn là null
                    }
                    // Kết nối sẽ tự động đóng khi ra khỏi khối using
                }
            }
            return result; // Trả về đối tượng kết quả (có thể là null nếu lỗi hoặc không có kết quả)
        }
    }
}