using SizeDirectory;


Console.WriteLine("В какой директории необходимо посчитать размер?");
var path = Console.ReadLine();
DirectoryInfo dir = new DirectoryInfo(path);


if (dir.Exists)
{
    try
    {
        Console.WriteLine($"Размер папки {path} : {DirectoryExtension.DirSize(dir)}");
    }
    catch (Exception e)
    {
        Console.WriteLine("Не удалось посчитать размер папки" + e.ToString());
    }
}

Console.ReadLine();

