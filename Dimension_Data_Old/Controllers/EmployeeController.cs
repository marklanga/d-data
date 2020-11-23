using System;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dimension_Data.Models;

namespace Test_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(""))
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("ViewAll", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            return View(dt);
        }

        // GET: Employee/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
            Employee empViewModel = new Employee();
            if (id > 0)
            {
                empViewModel = GetEmpByID(id);
            }
            return View(empViewModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bing to, for
        // more details, see http://go.microsoft.com/fwlink
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(int id, [Bind("Id,Age,Married")] Employee employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                using (MySqlConnection conn = new MySqlConnection(""))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("AddOrEdir", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id", employeeViewModel.Id);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(employeeViewModel);
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            return View();
        }

        [NonAction]
        public Employee GetEmpByID(int? id)
        {
            Employee emp = new Employee();
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(""))
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("ViewByID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("Id", id);
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    emp.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                }
            }
            return emp;
        }


    }
}
