﻿using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public  RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("There must be more than 5 students for ranked grading.");
            }

            var x = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[x - 1])
            {
                return 'A';
            }
            if (averageGrade >= grades[(x * 2) - 1])
            {
                return 'B';
            }
            if (averageGrade >= grades[(x * 3) - 1])
            {
                return 'C';
            }
            if (averageGrade >= grades[(x * 4) - 1])
            {
                return 'D';
            }

            return 'F';
        }
    }
}
