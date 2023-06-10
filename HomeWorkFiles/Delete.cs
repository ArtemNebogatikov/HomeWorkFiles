namespace DeleteFromFolder
{
    public static class DeleteFromDir
    {
        /// <summary>
        /// Удаление файлов и папок которые не используются более 30 минут
        /// </summary>
        /// <param name="dir"></param>
        public static void Delete(DirectoryInfo dir)
        {
            if (dir.Exists)
            {
                foreach (var subdir in dir.GetDirectories())
                {
                    if (subdir.LastAccessTime <= DateTime.Now.AddMinutes(-30))
                    {
                        try
                        {
                            subdir.Delete(true);
                            Console.WriteLine($"Папка {subdir.FullName} удалена");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Нет доступа к папке {subdir} \n {e}");
                        }

                    }
                }
                foreach (var file in dir.GetFiles())
                {
                    if (file.LastAccessTime <= DateTime.Now.AddMinutes(-30))
                    {
                        try
                        {
                            file.Delete();
                            Console.WriteLine($"Файл {file.FullName} удален");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Передан некорректный путь");
            }
        }
    }

}
