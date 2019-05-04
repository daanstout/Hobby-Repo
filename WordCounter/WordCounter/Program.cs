using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCounter {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            string text = File.ReadAllText(@"C:\Users\Beheerder\Downloads\Notulen ALV 01-03-2019.txt");

            string[] wordsSplit = text.Split(new char[] { ' ', '\n', '.', ',', '!', '?', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (string word in wordsSplit) {
                string trimWord = word.Trim(new char[] { '.', ',', '!', '?' });
                if (words.ContainsKey(trimWord))
                    words[trimWord]++;
                else
                    words.Add(trimWord, 1);
            }

            List<KeyValuePair<string, int>> list = words.ToList();

            //list.Sort(
            //    delegate (KeyValuePair<string, int> pair1,
            //    KeyValuePair<string, int> pair2) {
            //        return pair1.Value.CompareTo(pair2.Value) * -1;
            //    }
            //);

            list.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value) * -1);

            string output = "";

            foreach (KeyValuePair<string, int> pair in list)
                output += $"Word \"{pair.Key}\" occurs {pair.Value} times\n";

            File.WriteAllBytes(@"C:\Users\Beheerder\Desktop\ALV de-worded.txt", Encoding.ASCII.GetBytes(output));

            Console.ReadKey();
        }
    }
}
