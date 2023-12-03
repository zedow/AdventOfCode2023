namespace Kernel
{
    public class MyFileReader
    {
        public string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}