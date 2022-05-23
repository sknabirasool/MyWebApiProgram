using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
namespace WebApiDemo.Controllers
{
    public class EmployeeController : Controller
    {
     
        Employee[] employees = new Employee[]{
         new Employee { ID = 1, Name = "Mark", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 30 },
         new Employee { ID = 2, Name = "Allan", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 35 },
         new Employee { ID = 3, Name = "Johny", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 21 }
      };

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees;
        }


     

        public IHttpActionResult GetEmployee(int id){
         var employee = employees.FirstOrDefault((p) => p.ID == id);
         if (employee == null){
            return (IHttpActionResult)NotFound();
         }
         return (IHttpActionResult)Ok(employee);
      }
    }
}
