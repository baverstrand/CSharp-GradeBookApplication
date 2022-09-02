using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count <5)
            {
                throw new InvalidOperationException("Less than 5 students in class");
            }

            var studentsDesc = Students.OrderByDescending(x => x.AverageGrade).ToList();
            double studentsCount = Students.Count;
            var gradeJump = Convert.ToInt32(studentsCount / 5);

            if (averageGrade < studentsDesc[gradeJump].AverageGrade)
            {
                return 'A';
            }
            else if (averageGrade < studentsDesc[gradeJump * 2].AverageGrade)
            {
                return 'B';
            }
            else if (averageGrade < studentsDesc[gradeJump * 3].AverageGrade)
            {
                return 'C';
            }
            else if (averageGrade < studentsDesc[gradeJump * 4].AverageGrade)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
