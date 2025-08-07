namespace HurdleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentID = "105565520"; //Student ID
            string lastfourdigits = studentID.Substring(studentID.Length - 4); //Takes last 4 digits

            int[] arrayA = { 2, 3, 5, 7, 9, 11, 13, 17, 19, 23, 29 };
            int[] B = { 11, 11, 5, 2 };

            FileSystem FiSys = new FileSystem();


            for (int i = 0; i < B[0]; i++)
            {
                FiSys.Add(new File($"105508444-{i:D2}", "txt", 098));
            }

            Folder folder1 = new Folder("First Folder");
            for (int i = 0; i < B[1]; i++)
            {
                folder1.Add(new File($"105508444-{i:D2}", "txt", 520));
            }
            FiSys.Add(folder1);

            Folder innerFolder = new Folder("Small Folder");
            for (int i = 0; i < B[2]; i++)
            {
                innerFolder.Add(new File($"105508444-{i:D2}", "txt", 240));
            }

            Folder outerFolder = new Folder("Parent Folder");
            outerFolder.Add(innerFolder);
            FiSys.Add(outerFolder);

            for (int i = 0; i < B[3]; i++)
            {
                FiSys.Add(new Folder($"Empty Folder {i + 1}"));
            }
            FiSys.PrintCounters(); 


        }
    }
}