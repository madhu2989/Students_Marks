using StudentMarks.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentMarks
{
    public class ServiceClass
    {
        StudentsDb db = new StudentsDb();

        public List<StudentData> RetreiveStudentsList()
        {
            List<StudentData> studentNames = db.students.Select(x => new StudentData
            {
                StudentId = x.StudentID,
                StudentName = x.StudentName
            }).Distinct().ToList();

            List<StudentData> studentsMarks = db.students.Select(x => new StudentData
            {
                StudentId = x.StudentID,
                StudentName = x.StudentName,
                SubjectName = x.SubjectName,
                StudentMarks = x.Marks
            }).ToList();

            List<StudentData> listOfStudents = new List<StudentData>();

            int? ec1 = 0;
            int? ec2 = 0;
            int? ec3 = 0;
            int? ec4 = 0;
            int? ec5 = 0;
            int? TotalMarks = 0;
            string StudentName = null;

            foreach (var objStd in studentNames)
            {
                foreach (var objStdMarks in studentsMarks)
                {
                    if (objStd.StudentId == objStdMarks.StudentId)
                    {
                        StudentName = objStd.StudentName;
                        TotalMarks = TotalMarks + objStdMarks.StudentMarks;
                        if (objStdMarks.SubjectName == "EC1") ec1 = objStdMarks.StudentMarks;
                        if (objStdMarks.SubjectName == "EC2") ec2 = objStdMarks.StudentMarks;
                        if (objStdMarks.SubjectName == "EC3") ec3 = objStdMarks.StudentMarks;
                        if (objStdMarks.SubjectName == "EC4") ec4 = objStdMarks.StudentMarks;
                        if (objStdMarks.SubjectName == "EC5") ec5 = objStdMarks.StudentMarks;
                    }
                }
                listOfStudents.Add(new StudentData { StudentId = objStd.StudentId, StudentName = StudentName, EC1 = ec1, EC2 = ec2, EC3 = ec3, EC4 = ec4, EC5 = ec5, TotalMarks = TotalMarks });
                TotalMarks = 0;
            }

            List<StudentData> studentListSorted = listOfStudents.OrderByDescending(x => x.TotalMarks).ToList();

            return studentListSorted;
        }      
    }
}