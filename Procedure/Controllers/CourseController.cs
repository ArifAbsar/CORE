using Crud.DTO;
using Crud.EF;
using Crud.EF.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using System.Xml.Linq;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Crud.Controllers
{
    
    public class CourseController : ControllerBase
    {
        private readonly CourseContext _db;
        private readonly IConfiguration _configuration;
        public CourseController(CourseContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("api/Insert/{id}/{Name}")]
        public ActionResult<IEnumerable<Course>> Create(int id,string name)
        {
            string connectionString = _configuration.GetConnectionString("Post");
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string commandText = $"CALL insert_course({id}, '{name}')";
            
            using var command = new NpgsqlCommand(commandText, connection);
            command.Parameters.AddWithValue("coursename", name);
            command.ExecuteNonQuery();



            return Ok();
        }

        [HttpPost]
        [Route("api/Delete/{id}")]
        public ActionResult<IEnumerable<Course>>Delete(int id)
        {
            string connectionString = _configuration.GetConnectionString("Post");
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string commandText = $"CALL delete_course({id})";

            using var command = new NpgsqlCommand(commandText, connection);
            command.ExecuteNonQuery();

            return Ok();
        }

        [HttpPost]
        [Route("api/Update/{id}/{newname}")]

        public ActionResult<IEnumerable<Course>>Update(int id,string newname)
        {
            string connectionString = _configuration.GetConnectionString("Post");
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string commandText = $"CALL update_course({id},'{newname}')";

            using var command = new NpgsqlCommand(commandText, connection);
            command.Parameters.AddWithValue("coursename", newname);
            command.ExecuteNonQuery();

            return Ok();
        }
        [HttpGet]
        [Route("api/Read/all")]
        public ActionResult<IEnumerable<Course>> Reading()
        {
            var data = _db.courseset.ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(config);
            var retdata = mapper.Map<List<CourseDTO>>(data);
            return Ok(retdata);
        }
    }
}
