using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace TechMWebAPp.Models
{
    public class StudentRepository : IStudentRepository
    {
        SqlConnection con = new SqlConnection("server=(localdb)\\MSSQLLocalDB;Integrated security=true;initial catalog=LibraryDB");
        List<Book> books = new List<Book>();

        public List<Book> bookdet()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from book", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Book book = new Book();
                book.BookId = Convert.ToInt32(rdr[0]);
                book.booknm = Convert.ToString(rdr[1]);
                book.bookcategory = Convert.ToString(rdr[2]);
                book.bookprice = Convert.ToInt32(rdr[3]);
                book.pur_date = Convert.ToDateTime(rdr[4]);
                book.bookauthor = Convert.ToString(rdr[5]);
                books.Add(book);
            }
            rdr.Close();
            con.Close();
            return books;
        } 

        

        public List<Student> DataSource()
        {
            return new List<Student>()
            {
                new Student() { StudentId = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
                new Student() { StudentId = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
                new Student() { StudentId = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
            };
        }
        public Book GetBookById(int id)
        {
            return bookdet().FirstOrDefault(e => e.BookId == id);
        }
        public Student GetStudentById(int StudentId)
        {
            return DataSource().FirstOrDefault(e => e.StudentId == StudentId) ;
        }
    }
}