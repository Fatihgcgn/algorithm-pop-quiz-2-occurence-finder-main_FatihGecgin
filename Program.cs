/*
Problem:
t and z are strings consist of lowercase English letters.
Find all substrings for t, and return the maximum value of [ len(substring) x [how many times the substring occurs in z] ]
Example:
t = acldm1labcdhsnd
z = shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa
Solution:
abcd is a substring of t, and it occurs 5 times in Z, abcd.Length x 5 = 20 is the solution
*/
internal class Program
{
    private static void Main(string[] args)
    {
        var t = "acldm1labcdhsnd"; //1 sayısını çıkarmadım dizi altkume sayısını denkleştirmek için konulmuş olabilir diye.
        var z = "shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa";
        static int FindOccurance(string mainString_, string substring_)
        {
            //TODO: Complete method body.
            Dictionary<string, int> altkumeBul = new Dictionary<string, int>(); //anahtar kelimeli küme oluşturuyoruz
            List<string> resultKume = new List<string>();
            for (int i = 0; i < mainString_.Length; i++)
            {
                for (int j = i + 1; j <= mainString_.Length; j++)
                {
                    string altDize = mainString_.Substring(i, j - i);
                    resultKume.Add(mainString_.Substring(i, j - i));
                    int altkumeSayim = SayAltKume(substring_, altDize);
                    altkumeBul[altDize] = altkumeSayim;
                }
            }
            Console.WriteLine("\nTüm alt kümeler aşağıdaki gibidir \n");
            Console.WriteLine(string.Join(", ", resultKume));
            int max = 0;
            foreach (var e in altkumeBul)
            {
                int value = e.Key.Length * e.Value;
                max = Math.Max(max, value);
            }
            return max;
        }

        static int SayAltKume(string mainstr, string substr)
        {
            int sayac = 0;
            int index = 0;
            while ((index = mainstr.IndexOf(substr, index)) != -1)
            {
                sayac++;
                index += substr.Length;
            }
            return sayac;
        }
        int result = FindOccurance(t, z);
        Console.WriteLine("\nMaksimum olusabilecek deger: " + result);
    }
}