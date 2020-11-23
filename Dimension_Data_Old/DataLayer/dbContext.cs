using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Dimension_Data.Models;

namespace Dimension_Data.Context
{
    public class dbContext
    {
        string connString = "Server=den1.mysql5.gear.host;Port=3306;User=test321;Password=password.123;Database=test321";
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;

        /// <summary>
        /// READ ALL
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAllEmployee()
        {
            var employeeList = new List<Employee>();
            using(conn = new MySqlConnection(connString))
            {
                cmd = new MySqlCommand("Read", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var employee = new Employee();
                    employee.Id = Convert.ToInt32(reader["Id"].ToString());
                    employee.Name = reader["Name"].ToString();
                }

            }
            return employeeList;
        }

        /// <summary>
        /// CREATE
        /// </summary>
        /// <param name="employee"></param>
        public void CreateEmployee(Employee employee)
        {
            using(conn = new MySqlConnection(connString))
            {
                cmd = new MySqlCommand("Create", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Surname", employee.Surname);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="employee"></param>
        public void UpdateEmployee(Employee employee)
        {
            using (conn = new MySqlConnection(connString))
            {
                cmd = new MySqlCommand("Update", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Employee_ID", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Surname", employee.Surname);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteEmployee(int? Id)
        {
            using (conn = new MySqlConnection(connString))
            {
                cmd = new MySqlCommand("Delete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Employee_ID", Id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        /// <summary>
        /// READ 1EMPLOYEE
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Employee GetEmployeeId(int? Id)
        {
            var employee = new Employee();

            using (conn = new MySqlConnection(connString))
            {
                cmd = new MySqlCommand("GetEmpID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Employee_ID", Id);

                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee.Id = Convert.ToInt32(reader["Employee_ID"].ToString());
                    employee.Name = reader["Name"].ToString();
                    employee.Surname = reader["Surname"].ToString();
                }
                conn.Close();
            }
            return employee;
        }
    }
}