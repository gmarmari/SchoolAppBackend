using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAppBackend.Models
{
    public class Lessons
    {

        private Lessons() { }

        public static Lessons NewInstance() {
            var mLessons = new Lessons();
            if (_lessonList == null)
            {
                _lessonList = new List<Lesson>();
                _lessonList.Add(new Lesson {
                    Id = "2019.05.29_20:07:01",
                   Title = "Maths",});
                _lessonList.Add(new Lesson
                {
                    Id = "2019.05.29_20:07:11",
                    Title = "Physics",
                });
            
            }
            return mLessons;
        }

        private static IList<Lesson> _lessonList;


        public IList<Lesson> GetLessons() {
            return _lessonList;
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
                else if (string.IsNullOrEmpty(lesson?.Id))
                {
                    mResponce.Warning = "Cannot add a lesson with no id.";
                    return mResponce;
                }
                var oldLesson = _lessonList.FirstOrDefault(ls => ls.Id == lesson.Id);
                if (oldLesson != null)
                {
                    mResponce.Warning = $"A lesson with the id {lesson.Id} exists already. Add cannot be completed. Try deleting the old lessonn first and retry.";
                    return mResponce;
                }
                _lessonList.Add(lesson);
                mResponce.Success = true;
            }
            catch (Exception e) {
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
                    mResponce.Warning = "Cannot update a Lesson with no id.";
                    return mResponce;
                }
                var oldLesson = _lessonList.FirstOrDefault(ls => ls.Id == lesson.Id);
                if (oldLesson == null)
                {
                    mResponce.Warning = $"No Lesson found with id: {lesson.Id}.";
                    return mResponce;
                }
                var index = _lessonList.IndexOf(oldLesson);
                _lessonList[index] = lesson;
                mResponce.Success = true;
            }
            catch (Exception e)
            {
                mResponce.Error = e;
            }
            return mResponce;
        }

        public Responce Delete(string lessonId)
        {
            var mResponce = new Responce();
            try
            {
                if (string.IsNullOrEmpty(lessonId))
                {
                    mResponce.Warning = "Cannot delete a Lesson with no id.";
                    return mResponce;
                }
                var mLesson = _lessonList.FirstOrDefault(ls => ls.Id == lessonId);
                if (mLesson == null)
                {
                    mResponce.Warning = $"No Lesson found with id: {lessonId}.";
                    return mResponce;
                }
                _lessonList.Remove(mLesson);
                mResponce.Success = true;
            }
            catch (Exception e)
            {
                mResponce.Error = e;
            }
            return mResponce;
        }


    }
}
