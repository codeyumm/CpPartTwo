using CpPartOne.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CpPartOne.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/list
        public ActionResult List()
        {
            TeachersDataController dataController = new TeachersDataController();
            IEnumerable<Teacher> teachersList = dataController.ListTeachers();

            // Retrieve data from TempData
            string result = TempData["result"] as string;
            Debug.WriteLine("HEllo");
            Debug.WriteLine(result);

            
            if (result != null)
            {
                // passing result to view with viewbag
                ViewBag.result = result;
            }
            

            return View(teachersList);
        }

        // GET: Teacher/show/{id}
        public ActionResult Show(int id)
        {
           
            TeachersDataController dataController = new TeachersDataController();
            Teacher teacher = dataController.FindTeacher(id);

            return View(teacher);
        }

        // GET: Teacher/new
        public ActionResult New()
        {
            return View();
        }


        // POST: Teacher/add
        public ActionResult Add(String teacherFirstName, String teacherLastName, String employeeNumber, DateTime teacherHireDate, decimal teacherSalary)
        {
            // for testing
            // Debug.WriteLine(teacherFirstName);


            // Capturing data from request 
            String newTeacherFristName = teacherFirstName;
            String newTeacherLastName = teacherLastName;
            String newTeacherEmployeeNumber = employeeNumber;
            DateTime newTeacherHireDate = teacherHireDate;
            decimal newTeacherSalary = teacherSalary;

            // creating object of teacher to add the data 
            Teacher newTeacher = new Teacher();

            // adding captured data to teacher's object
            newTeacher.TeacherFname = newTeacherFristName;
            newTeacher.TeacherLname = newTeacherLastName;
            newTeacher.EmployeeNumber = newTeacherEmployeeNumber;
            newTeacher.HireDate = newTeacherHireDate;
            newTeacher.Salary = newTeacherSalary;

            // TeachersDataController object to use add method
            TeachersDataController contoller = new TeachersDataController();

            int result = contoller.Add(newTeacher);

            // passing result variable to view
            // first I tried with viewbag then viewdata but it was not working
            // then I found about TempData  to pass data when you call RedirectToAction
            TempData["result"] = result.ToString();

            // to go back to list of teachers after inserting the data
            return RedirectToAction("List");
        }

        
        // POST: Teacher/Remove/{id}        
        public ActionResult Remove(int id)
        {

            // TeachersDataController object to use remove method
            TeachersDataController contoller = new TeachersDataController();

            int result =  contoller.Remove(id);

            return RedirectToAction("List");
        }
    }
}