using Homework3Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3Pagination.Services
{

    internal class TestServices
    {
        private static readonly List<Student> students;



        private static readonly List<TestScore> testScores;

        static TestServices()
        {
            students = new List<Student>();
            testScores = new List<TestScore>();

            const int NUM_STUDENTS = 100;
            var random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                students.Add(new Student { Id = i, Name = $"Student {i}" });

                testScores.Add(new TestScore { StudentId = i, Subject = "Maths", Marks = random.Next(0, 100) });
                testScores.Add(new TestScore { StudentId = i, Subject = "Science", Marks = random.Next(0, 100) });
                testScores.Add(new TestScore { StudentId = i, Subject = "Social Science", Marks = random.Next(0, 100) });
            }
        }





        public PaginatedDataViewModel<TotalScoreModel> GetTotalScore(int startRow, int noOfRows)
        {
            var records_to_skip = (startRow / noOfRows) * noOfRows;
            var count_of_students = students
                        .Join(testScores, sr => sr.Id, s => s.StudentId, (sr, s)
                        => new
                        {
                            s.StudentId,
                            StudentName = sr.Name,
                            s.Marks
                        })
                        .GroupBy(e => new { e.StudentId, e.StudentName })
                        .Select(g => new TotalScoreModel
                        {
                            Id = g.Key.StudentId,
                            StudentName = g.Key.StudentName,
                            TotalMarks = g.Sum(a => a.Marks)
                        }).Count();
            var output_rows = students
                        .Join(testScores, sr => sr.Id, s => s.StudentId, (sr, s)
                        => new
                        {
                            s.StudentId,
                            StudentName = sr.Name,
                            s.Marks
                        })
                        .GroupBy(e => new { e.StudentId, e.StudentName })
                        .Select(g => new TotalScoreModel
                        {
                            Id = g.Key.StudentId,
                            StudentName = g.Key.StudentName,
                            TotalMarks = g.Sum(a => a.Marks)
                        })
                        .Skip(records_to_skip)
                        .Take(noOfRows).ToList();



            return new PaginatedDataViewModel<TotalScoreModel> { TotalRows = count_of_students, Rows = output_rows };


        }
    }
}
