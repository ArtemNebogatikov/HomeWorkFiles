using FinalTask;
using System.Runtime.Serialization.Formatters.Binary;

BinaryFormatter BinaryFormatter = new BinaryFormatter();
Student[] newStudents;
string path = @"C:\test";
DirectoryInfo students = new DirectoryInfo(path);
if (!students.Exists)
{
    students.Create();
}
using (var fileStream = new FileStream(@"D:\Обучение\С#\Students.dat", FileMode.Open))
{
    newStudents = (Student[])BinaryFormatter.Deserialize(fileStream);
    fileStream.Close();
}
AddFile(newStudents, path);
WriteFile(newStudents, path);
Console.ReadLine();
static void WriteFile(Student[] students, string path)
{

    foreach (Student student in students)
    {
        Console.WriteLine($"{student.Name}, {student.DateOfBirth}, {student.Group}");
        string newPath = path + @"\" + student.Group + ".txt";
        try
        {
            using (StreamWriter writer = new StreamWriter(newPath))
            {
                writer.Write($"Имя: {student.Name}, Дата рождения: {student.DateOfBirth}");
                writer.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Студент не записан {0} {1}", student.Name, e.ToString());
        }
    }
}
static void AddFile(Student[] students, string path)
{
    FileStream? fileStream = null;
    foreach (Student student in students)
    {
        string newPath = path + @"\" + student.Group + ".txt";
        try
        {
            fileStream = new FileStream(newPath, FileMode.Create);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            fileStream?.Close();
        }
        
    }
}
