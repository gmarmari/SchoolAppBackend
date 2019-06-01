using NLog;
using SchoolAppBackend.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAppBackend.Models
{
    public class Lessons
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();


        #region Construction

        public Lessons(SchoolAppDBContext dbContext) {
            _dbContext = dbContext;
        }

        public static Lessons NewInstance() {
            return new Lessons(new SchoolAppDBContext());
        }

        #endregion


        private SchoolAppDBContext _dbContext;


        public IList<Lesson> GetLessons() {
            var mList = new List<Lesson>();
            foreach (LessonTable table in _dbContext.LessonTable)
            {
                mList.Add(LessonHelper.convertToLesson(table));
            }
            return mList;
        }

        public Responce Add(Lesson lesson)
        {
            var mResponce = new Responce();
            try
            {
                if (lesson == null)
                {
                    mResponce.Warning = "Cannot add a null lesson.";
                    return mResponce;
                }
                _dbContext.LessonTable.Add(new LessonTable
                {
                    Title = lesson.Title
                });
                _dbContext.SaveChanges();
                mResponce.Success = true;
            }
            catch (Exception e) {
                logger.Error(e);
                mResponce.Error = e;
            }
            return mResponce;
        }

        public Responce Update(Lesson lesson)
        {
            var mResponce = new Responce();
            try
            {
                if (string.IsNullOrEmpty(lesson?.Id))
                {
                    mResponce.Warning = "Cannot update a ILessonModel with no id.";
                    return mResponce;
                }
                _dbContext.LessonTable.Update(new LessonTable
                {
                    Title = lesson.Title
                });
                _dbContext.SaveChanges();
                mResponce.Success = true;
            }
            catch (Exception e)
            {
                logger.Error(e);
                mResponce.Error = e;
            }
            return mResponce;
        }

        public Responce Delete(string lessonId)
        {
            // TODO: delete in DB
            var mResponce = new Responce();
            try
            {
                if (string.IsNullOrEmpty(lessonId))
                {
                    mResponce.Warning = "Cannot delete a ILessonModel with no id.";
                    return mResponce;
                }
                var mLesson = _dbContext.LessonTable.First(tb => tb.Id == short.Parse(lessonId));

                if (mLesson == null)
                {
                    mResponce.Warning = $"No ILessonModel found with id: {lessonId}.";
                    return mResponce;
                }
                _dbContext.LessonTable.Remove(mLesson);
                _dbContext.SaveChanges();
                mResponce.Success = true;
            }
            catch (Exception e)
            {
                logger.Error(e);
                mResponce.Error = e;
            }
            return mResponce;
        }


    }
}
