using NLog;
using SchoolAppBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAppBackend.Database
{
    public class LessonHelper
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static Lesson convertToLesson(LessonTable table)
        {
            return new Lesson
            {
                Id = table.Id.ToString(),
                Title = table.Title
            };
        }

        public static LessonTable convertToLessonTable(Lesson lesson)
        {
            return new LessonTable
            {
                Id = GetId(lesson.Id),
                Title = lesson.Title
            };
        }

        private static int GetId(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return -1;
            }
        }

    }
}
