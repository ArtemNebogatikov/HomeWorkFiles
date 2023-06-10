using DeleteFromFolder;

///Получаем директорию для очистки
Console.WriteLine("Введите путь папки для удаления файлов, которые не использовались больше 30 минут");
var path = Console.ReadLine();
DirectoryInfo dir = new DirectoryInfo(path);

///Получаем объем до очистки
long beforeDelete = DirectoryExtension.DirSize(dir);
Console.WriteLine($"Размер папки до очистки: {beforeDelete}");

///Очищаем папку
DeleteFromDir.Delete(dir);

///Получаем размер после очистки
long afterDelete = DirectoryExtension.DirSize(dir);
Console.WriteLine($"Размер папки после очистки: {afterDelete}");

Console.WriteLine("Было очищено: {0}", beforeDelete - afterDelete);

Console.ReadLine();
