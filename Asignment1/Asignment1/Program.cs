
using System.Text.RegularExpressions;

public class Program
{
    static void Main()
    {
        string sourcePath = @"C:\Users\hieu0\OneDrive\Máy tính\c#";
        string targetPath = @"C:\Users\hieu0\OneDrive\Máy tính\c#2";
        List<double> list = new List<double>();

        
        Regex rg = new Regex(@"^[n|N][a-zA-z]{2,}[^n|^N]$");
        Regex rgNumber = new Regex(@"^-?\d+(\.?\d+)$");
        if (System.IO.Directory.Exists(sourcePath))
        {
            string[] files = System.IO.Directory.GetFiles(sourcePath);
            foreach (string s in files)
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                List<char> listWord = new List<char>();
                int countWord = 0;
                
                String fileName = System.IO.Path.GetFileName(s);
     
                //2
                StreamReader myfile;
                try
                {
                    myfile = File.OpenText(s);
                string line;
                do
                {
                    line = myfile.ReadLine();
                        if (line != null)
                            //  foreach (string str in line.Split(" "))
                            // {

                            //1
                            for (int i = 0; i < line.Split(" ").Length; i++)
                                {
                                string word = line.Split(" ")[i].ToLower();

                                if (word.Equals("việt") && line.Split(" ")[i + 1].ToLower().Equals("nam"))
                                {
                                    String destFile = System.IO.Path.Combine(targetPath, fileName);
                                    System.IO.File.Copy(s, destFile, true);
                                }

                                if (dict.ContainsKey(word))
                                {
                                    dict[word] = dict[word] + 1;
                                }
                                else
                                {
                                    dict.Add(word, 1);
                                }
                                foreach (char w in word)
                                {
                                    if (!listWord.Contains(w))
                                    
                                        listWord.Add(w);
                                    }
                                }
                      //  }
                }
                while (line != null);
                myfile.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("wrong when open file.");
                }
                foreach (KeyValuePair<string, int> sortFile in dict.OrderByDescending(key => key.Value))
                {
                    File.AppendAllText(s.Split(".txt")[0]+" 2"+".txt", sortFile.Key + " : " + sortFile.Value + "\n");
                    countWord += sortFile.Value;
                //    Console.WriteLine(sortFile.Key + " : " + sortFile.Value);
                }

                //3
             File.AppendAllText(@"C:\Users\hieu0\OneDrive\Máy tính\c#\việt nam3.txt", fileName + " : "+ countWord + "\n");

                //4
                Console.WriteLine(fileName + "\n");
                foreach (var item in dict)
                {
                    if (rg.IsMatch(item.Key.ToString()))
                    {
                        Console.WriteLine(item.Key);
                    }
                    if (rgNumber.IsMatch(item.Key.ToString()))
                    {
                        try
                        {
                            list.Add(double.Parse(item.Key));
                        }
                        catch { 
                        }
                    }
                }

                //6
                for (int i = 0; i < listWord.Count; i++)
                {
                    File.AppendAllText(s.Split(".txt")[0] + " bai 6" + ".txt", listWord[i] + "\n");
                }
            }

            //5
            for (int i = 0; i < list.Count; i++)
            {
                File.AppendAllText(@"C:\Users\hieu0\OneDrive\Máy tính\c#\Bai 5.txt", list[i] + "\n");
            }

        }
        else
        {
            Console.WriteLine("Source path does not exist!");
        }
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}