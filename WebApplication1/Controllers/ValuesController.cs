using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Common;
using WebApplication1.DataAcces;
using WebApplication1.DataAcces.Contracts;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        readonly IStudentDao<Student> studentDao = null;

        public ValuesController(IStudentDao<Student> studentDao)
        {
            this.studentDao = studentDao;
        }

        [Route("api/students")]
        public List<Student> GetAll()
        {
            var repository = new StudentDao();
            var students = repository.GetAll();
            return students;
        }

        [Route("api/add")]
        public void Post()
        {
            var repository = new StudentDao();
            var studentToAdd = new Student { Name = "raul", Lastname = "segui", BirthDate = DateTime.Parse("12-05-1993") };
            repository.Create(studentToAdd);
        }

        [Route("api/update")]
        public void Put([FromBody]Student student)
        {
            var repository = new StudentDao();
            repository.Update(student);
        }

        [Route("api/delete/{id}")]
        public void Delete(int id)
        {
            var repository = new StudentDao();
            repository.DeleteById(id);
        }
    }
}
