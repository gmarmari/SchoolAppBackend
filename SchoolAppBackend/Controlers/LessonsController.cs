using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolAppBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAppBackend.Controlers
{
    [Route("api/[controller]")]
    public class LessonsController : Controller
    {

        // GET: api/<controller>
        [HttpGet("get")]
        public JsonResult GetLessons()
        {
            return Json(Lessons.NewInstance().GetLessons());
        }
        
        
        [HttpPost("add")]
        public JsonResult AddLesson([FromBody] Lesson value)
        {
            return Json(Lessons.NewInstance().Add(value));
        }
        
        [HttpPut("update")]
        public JsonResult UpdateLesson([FromBody] Lesson lesson)
        {
            return Json(Lessons.NewInstance().Update(lesson));
        }
        
        [HttpDelete("delete/{lessonId}")]
        public JsonResult DeleteLesson(string lessonId)
        {
            return Json(Lessons.NewInstance().Delete(lessonId));
        }
    }
}
