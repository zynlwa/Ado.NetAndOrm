using Ado.NetAndOrm.Models;
using Ado.NetAndOrm.Service;

namespace Ado.NetAndOrm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentRepository studentRepository = new StudentRepository();

            studentRepository.Add(new Student { Name = "Shefa", Surname = "Zeynalova", Email = "zeyn@gmail.com" });
            studentRepository.Add(new Student { Name = "aa", Surname = "nnn", Email = "test@gmail.com" });

            var students = studentRepository.GetAllStudents();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Surname}-{s.Email}");
            }
            var firstStudent = students[0];
            firstStudent.Name = "Şəfaa";
            studentRepository.Update(firstStudent);

            //Delete
            studentRepository.Delete(firstStudent.Id);
        }

    }
}