using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebApplication1.Common;
using WebApplication1.DataAcces.Contracts;

namespace WebApplication1.DataAcces
{
    public class StudentDao : IStudentDao<Student>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<Student> GetAll()
        {
            using (var connection = new SqlConnection(Resources.connectionString))
            {
                try
                {
                    return SqlMapper.Query<Student>(connection, "SELECT * FROM Student").ToList();
                }
                catch (ArgumentNullException ex)
                {
                    log.Error(ex);
                    throw;
                }
            }
        }

        public Student Create(Student model)
        {
            using (var connection = new SqlConnection(Resources.connectionString))
            {
                try
                {
                    var id = SqlMapper.Query<int>(connection, "INSERT INTO Student VALUES (@Name, @Lastname, @Birthday);SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        new { @Name = model.Name, @Lastname = model.Lastname, @Birthday = model.BirthDate }).Single();

                    return SqlMapper.Query<Student>(connection, "SELECT * FROM Student WHERE Id = @Id", new { @Id = id }).Single();
                }
                catch (InvalidOperationException e)
                {
                    log.Error(e);
                    throw;
                }
                catch (ArgumentNullException e)
                {
                    log.Error(e);
                    throw;
                }
            }
        }

        public Student Update(Student model)
        {
            using (var connection = new SqlConnection(Resources.connectionString))
            {
                connection.Query<Student>("UPDATE Student SET Name = @Name, Lastname = @Lastname, Birthday = @BirthDate WHERE Id = @Id;",
                        new { @Name = model.Name, @Lastname = model.Lastname, @BirthDate = model.BirthDate, @Id = model.Id });
                try
                {
                    var updatedStudent = SqlMapper.Query<Student>(connection, "SELECT * FROM Student WHERE Id = @Id", new { @Id = model.Id }).Single();

                    return updatedStudent;
                }
                catch (ArgumentNullException e)
                {
                    log.Error(e);
                    throw;
                }
                catch (InvalidOperationException e)
                {
                    log.Error(e);
                    throw;
                }
            }
        }

        public bool DeleteById(int id)
        {
            using (var connection = new SqlConnection(Resources.connectionString))
            {
                SqlMapper.Query<bool>(connection, "DELETE FROM Student WHERE Id = @Id", new { @Id = id });

                return true;
            }
        }
    }
}
