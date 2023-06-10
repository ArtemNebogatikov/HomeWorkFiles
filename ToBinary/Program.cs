using FinalTask;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

BinaryFormatter BinaryFormatter = new BinaryFormatter();
using (var fileStream = new FileStream(@"D:\Обучение\С#\Students.dat", FileMode.Open))
{
    Student[] newStudents;
    newStudents = (Student[])BinaryFormatter.Deserialize(fileStream);
    string path = @"C:\test";
    DirectoryInfo students = new DirectoryInfo(path);
    if (!students.Exists)
    {
        students.Create();
    }
    AddFile(newStudents, path);
    Thread.Sleep(100000);
    WriteFile(newStudents, path);

}

Console.ReadLine();
static void WriteFile(Student[] students, string path)
{
    
    foreach (Student student in students)
    {
        Console.WriteLine($"{student.Name}, {student.DateOfBirth}, {student.Group}");
        string newPath = path + @"\" + student.Group + ".txt";
        try
        {
            using(StreamWriter writer = new StreamWriter(newPath))
            {
                writer.WriteLine($"Имя: {student.Name}, Дата рождения: {student.DateOfBirth}");
                writer.Close();
            }
        }
        catch( Exception e )
        {
            Console.WriteLine("Студент не записан {0} {1}", student.Name, e.ToString() );
        }
    }
}
static void AddFile(Student[] students, string path)
{
    foreach(Student student in students)
    {
        string newPath = path + @"\" + student.Group + ".txt";
        if(!File.Exists(newPath))
        {
            File.Create(newPath);
        }
    }
}
