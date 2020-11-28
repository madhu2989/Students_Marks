using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentMarks.Controllers
{
    public class StudentController : Controller
    {
        ServiceClass _service;
        public StudentController()
        {
            _service = new ServiceClass();
        }

        [HttpGet]
        public ActionResult AllStudents(string Result, string graceResult)
        {
            List<StudentData> studentsList = _service.RetreiveStudentsList();

            if (Result != null)
            {
                ViewBag.Result = "viewPassOrFail";
            }

            if (graceResult != null)
            {
                ViewBag.Result = "viewPassOrFail";

                List<StudentData> AddedGraceMarkList = GraceMarksLogic(studentsList);

                AddedGraceMarkList = studentsList;

                ViewBag.StudentsList = AddedGraceMarkList;
            }

            ViewBag.StudentsList = studentsList;

            return View();
        }

        private List<StudentData> GraceMarksLogic(List<StudentData> studentsList)
        {
            foreach (var obj in studentsList)
            {
                int? GraceMarks = 6;
                int? ReqMarks = 0;
                if (obj.EC1 < 30)
                {
                    ReqMarks = 30 - obj.EC1;
                    if (ReqMarks > 0 && ReqMarks <= 6)
                    {
                        obj.EC1 = ReqMarks + obj.EC1;
                        GraceMarks = GraceMarks - ReqMarks;
                        ReqMarks = 0;
                    }
                }

                if (obj.EC2 < 30)
                {
                    ReqMarks = 30 - obj.EC2;
                    if (ReqMarks > 0 && ReqMarks <= 6)
                    {
                        obj.EC2 = ReqMarks + obj.EC2;
                        GraceMarks = GraceMarks - ReqMarks;
                        ReqMarks = 0;
                    }
                }

                if (obj.EC3 < 30)
                {
                    ReqMarks = 30 - obj.EC3;
                    if (ReqMarks > 0 && ReqMarks <= 6)
                    {
                        obj.EC3 = ReqMarks + obj.EC3;
                        GraceMarks = GraceMarks - ReqMarks;
                        ReqMarks = 0;
                    }
                }

                if (obj.EC4 < 30)
                {
                    ReqMarks = 30 - obj.EC4;
                    if (ReqMarks > 0 && ReqMarks <= 6)
                    {
                        obj.EC4 = ReqMarks + obj.EC4;
                        GraceMarks = GraceMarks - ReqMarks;
                        ReqMarks = 0;
                    }
                }

                if (obj.EC5 < 30)
                {
                    ReqMarks = 30 - obj.EC5;
                    if (ReqMarks > 0 && ReqMarks <= 6)
                    {
                        obj.EC5 = ReqMarks + obj.EC5;
                        GraceMarks = GraceMarks - ReqMarks;
                        ReqMarks = 0;
                    }
                }
            }
            return studentsList;
        }
    }
}