using System;
using System.IO;

namespace laba2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ADMIN\Documents\sergey\KPO\laba2_4\text.txt";
            string line;
            string word;


            if(File.Exists(path)){
                StreamReader stread = new StreamReader(path, System.Text.Encoding.Default);
                
                try {
                    Console.WriteLine("\nФайл для поиска: {0}", Path.GetFileName(path));
                    Console.WriteLine();

                    line = stread.ReadToEnd();
                    Console.Write("Какое слово найти:");
                    word = Console.ReadLine();
                    SearchWord sercher = new SearchWord (word, line);
                    sercher.Search();
                    
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                    } finally {
                        try {
                            stread.Close();
                        } catch (Exception e) {
                            Console.WriteLine(e.Message);
                        }
                    }
            } else {
                Console.WriteLine("Файла {0} не существует.", Path.GetFileName(path));
            }    
        }
    }

    public class SearchWord{
        private string search_word;
        private string search_line;
        public SearchWord(string s_w, string s_l){
            search_word = s_w;
            search_line = s_l;
        }

        public void Search(){
            string result = "";
            string pathSearch = @"C:\Users\ADMIN\Documents\sergey\KPO\laba2_4\sercher.txt";
            if(!File.Exists(pathSearch)){
                File.WriteAllText(pathSearch, " ");
            }
            StreamWriter stwrit = new StreamWriter(pathSearch, false, System.Text.Encoding.Default);
            try {
                string[] words;
                words = search_line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in words) {
                    if(item == search_word) {
                        result += item + " ";
                    }
                }
                Console.WriteLine("\nРезультат в файле {0}", Path.GetFileName(pathSearch));
                stwrit.WriteLine(result);
                Console.WriteLine();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                try {
                    stwrit.Close();
                } catch (Exception e){
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
