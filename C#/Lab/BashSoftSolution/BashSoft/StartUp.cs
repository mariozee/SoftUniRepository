namespace BashSoft
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //IOManager.TraverseFolder(0);
            //Data.InitializeData();
            //Data.GetStudenScoresFromCourse("Unity", "Ivan");
            //IOManager.CreateDirectoryInCurrentFolder("WOOOOW");
            string actualOutput_Path = @"D:\SoftUni\SoftUniRepository\C#\Exercises\Advanced-C#\FilesAbdDurectories\01.OddLines\01_OddLinesOut.txt";
            string currentOutput_Path = @"D:\SoftUni\SoftUniRepository\C#\Exercises\Advanced-C#\FilesAbdDurectories\01.OddLines\01_Output.txt";
            Tester.CompareContent(actualOutput_Path, currentOutput_Path);
        }
    }
}
