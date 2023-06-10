namespace DeleteFromFolder
{
    public static class DirectoryExtension
    {
        /// <summary>
        /// Получение размера директории
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            var fs = d.GetFiles();
            foreach (var fi in fs)
            {
                size += fi.Length;
            }

            DirectoryInfo[] fs2 = d.GetDirectories();
            foreach (var fi2 in fs2)
            {
                size += DirSize(fi2);
            }
            return size;
        }
    }
}
