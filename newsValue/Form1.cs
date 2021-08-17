using Iveonik.Stemmers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace newsValue
{
    public partial class Form1 : Form
    {

        static Dictionary<string, bool> stopword = new Dictionary<string, bool>
    {
        { "a", true },
        { "about", true },
        { "above", true },
        { "across", true },
        { "after", true },
        { "afterwards", true },
        { "again", true },
        { "against", true },
        { "all", true },
        { "almost", true },
        { "alone", true },
        { "along", true },
        { "already", true },
        { "also", true },
        { "although", true },
        { "always", true },
        { "am", true },
        { "among", true },
        { "amongst", true },
        { "amount", true },
        { "an", true },
        { "and", true },
        { "another", true },
        { "any", true },
        { "anyhow", true },
        { "anyone", true },
        { "anything", true },
        { "anyway", true },
        { "anywhere", true },
        { "are", true },
        { "around", true },
        { "as", true },
        { "at", true },
        { "back", true },
        { "be", true },
        { "became", true },
        { "because", true },
        { "become", true },
        { "becomes", true },
        { "becoming", true },
        { "been", true },
        { "before", true },
        { "beforehand", true },
        { "behind", true },
        { "being", true },
        { "below", true },
        { "beside", true },
        { "besides", true },
        { "between", true },
        { "beyond", true },
        { "bill", true },
        { "both", true },
        { "bottom", true },
        { "but", true },
        { "by", true },
        { "call", true },
        { "can", true },
        { "cannot", true },
        { "cant", true },
        { "co", true },
        { "computer", true },
        { "con", true },
        { "could", true },
        { "couldnt", true },
        { "cry", true },
        { "de", true },
        { "describe", true },
        { "detail", true },
        { "do", true },
        {"does",true },
        { "done", true },
        { "down", true },
        { "due", true },
        { "during", true },
        { "each", true },
        { "eg", true },
        { "eight", true },
        { "either", true },
        { "eleven", true },
        { "else", true },
        { "elsewhere", true },
        { "empty", true },
        { "enough", true },
        { "etc", true },
        { "even", true },
        { "ever", true },
        { "every", true },
        { "everyone", true },
        { "everything", true },
        { "everywhere", true },
        { "except", true },
        { "few", true },
        { "fifteen", true },
        { "fify", true },
        { "fill", true },
        { "find", true },
        { "fire", true },
        { "first", true },
        { "five", true },
        { "for", true },
        { "former", true },
        { "formerly", true },
        { "forty", true },
        { "found", true },
        { "four", true },
        { "from", true },
        { "front", true },
        { "full", true },
        { "further", true },
        { "get", true },
        { "give", true },
        { "go", true },
        { "had", true },
        { "has", true },
        { "have", true },
        { "he", true },
        { "hence", true },
        { "her", true },
        { "here", true },
        { "hereafter", true },
        { "hereby", true },
        { "herein", true },
        { "hereupon", true },
        { "hers", true },
        { "herself", true },
        { "him", true },
        { "himself", true },
        { "his", true },
        { "how", true },
        { "however", true },
        { "hundred", true },
        { "i", true },
        { "ie", true },
        { "if", true },
        { "in", true },
        { "inc", true },
        { "indeed", true },
        { "interest", true },
        { "into", true },
        { "is", true },
        { "it", true },
        { "its", true },
        { "itself", true },
        { "keep", true },
        { "last", true },
        { "latter", true },
        { "latterly", true },
        { "least", true },
        { "less", true },
        { "ltd", true },
        { "made", true },
        { "many", true },
        { "may", true },
        { "me", true },
        { "meanwhile", true },
        { "might", true },
        { "mill", true },
        { "mine", true },
        { "more", true },
        { "moreover", true },
        { "most", true },
        { "mostly", true },
        { "move", true },
        { "much", true },
        { "must", true },
        { "my", true },
        { "myself", true },
        { "name", true },
        { "namely", true },
        { "neither", true },
        { "never", true },
        { "nevertheless", true },
        { "next", true },
        { "nine", true },
        { "no", true },
        { "nobody", true },
        { "none", true },
        { "nor", true },
        { "not", true },
        { "nothing", true },
        { "now", true },
        { "nowhere", true },
        { "of", true },
        { "off", true },
        { "often", true },
        { "on", true },
        { "once", true },
        { "one", true },
        { "only", true },
        { "onto", true },
        { "or", true },
        { "other", true },
        { "others", true },
        { "otherwise", true },
        { "our", true },
        { "ours", true },
        { "ourselves", true },
        { "out", true },
        { "over", true },
        { "own", true },
        { "part", true },
        { "per", true },
        { "perhaps", true },
        { "please", true },
        { "put", true },
        { "rather", true },
        { "re", true },
        { "same", true },
        { "see", true },
        { "seem", true },
        { "seemed", true },
        { "seeming", true },
        { "seems", true },
        { "serious", true },
        { "several", true },
        { "she", true },
        { "should", true },
        { "show", true },
        { "side", true },
        { "since", true },
        { "sincere", true },
        { "six", true },
        { "sixty", true },
        { "so", true },
        { "some", true },
        { "somehow", true },
        { "someone", true },
        { "something", true },
        { "sometime", true },
        { "sometimes", true },
        { "somewhere", true },
        { "still", true },
        { "such", true },
        { "system", true },
        { "take", true },
        { "ten", true },
        { "than", true },
        { "that", true },
        { "the", true },
        { "their", true },
        { "them", true },
        { "themselves", true },
        { "then", true },
        { "thence", true },
        { "there", true },
        { "thereafter", true },
        { "thereby", true },
        { "therefore", true },
        { "therein", true },
        { "thereupon", true },
        { "these", true },
        { "they", true },
        { "thick", true },
        { "thin", true },
        { "third", true },
        { "this", true },
        { "those", true },
        { "though", true },
        { "three", true },
        { "through", true },
        { "throughout", true },
        { "thru", true },
        { "thus", true },
        { "to", true },
        { "together", true },
        { "too", true },
        { "top", true },
        { "toward", true },
        { "towards", true },
        { "twelve", true },
        { "twenty", true },
        { "two", true },
        { "un", true },
        { "under", true },
        { "until", true },
        { "up", true },
        { "upon", true },
        { "us", true },
        { "very", true },
        { "via", true },
        { "was", true },
        { "we", true },
        { "well", true },
        { "were", true },
        { "what", true },
        { "whatever", true },
        { "when", true },
        { "whence", true },
        { "whenever", true },
        { "where", true },
        { "whereafter", true },
        { "whereas", true },
        { "whereby", true },
        { "wherein", true },
        { "whereupon", true },
        { "wherever", true },
        { "whether", true },
        { "which", true },
        { "while", true },
        { "whither", true },
        { "who", true },
        { "whoever", true },
        { "whole", true },
        { "whom", true },
        { "whose", true },
        { "why", true },
        { "will", true },
        { "with", true },
        { "within", true },
        { "without", true },
        { "would", true },
        { "yet", true },
        { "you", true },
        { "your", true },
        { "yours", true },
        { "yourself", true },
        { "yourselves", true }
    };
        Dictionary<string, int> encodeDict = new Dictionary<string, int>
        {
            {"car", 1 },
            {"soda", 2}
        };
        public Form1()
        {
            InitializeComponent();
          
        }

        List<string> rarityLevel = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            List<double> cosineScores = new List<double>();

            readFile("newsdata.txt");
            richTextBox1.Text = newsList[0];
            docClass[] doc = new docClass[newsList.Count];
            for(int i = 0; i < newsList.Count; i++)
            {
                doc[i] = new docClass();
                doc[i].articleCode = i;   
                string preprocess = newsList[i].ToString();
                TextPreprocess(preprocess);
                doc[i].keywords = TextPreprocess(preprocess);
               
            }
            for (int i = 0; i < newsList.Count; i++)
            {
                for (int x = 0; x < newsList.Count; x++)
                {
                    if (x != i)
                    {

                      
                        double cs = encodeKeyWord(doc[i].keywords, doc[x].keywords);
                        cosineScores.Add(cs);
                      
                    }
                }
               doc[i].rarityLevel = rarityCal(cosineScores, i);
                richTextBox2.Text = doc[i].rarityLevel;
                Console.WriteLine("rarity level for doc{0} = {1}", i, doc[i].rarityLevel);

                rarityLevel.Add(doc[i].rarityLevel);

            }

            






        }
        List<string> newsList = new List<string>();
        private void readFile(string filename)
        {
          
            newsList = File.ReadAllLines(filename).ToList();
            showData(newsList);

        }

        private void showData(List<string> List)
        {
            for(int i = 0; i < List.Count; i++)
            {
                Console.WriteLine(i + ")" + List[i]);
            }
        }

        private void showdoubleData(List<double> List)
        {
            for (int i = 0; i < List.Count; i++)
            {
                Console.WriteLine(i + ")" + List[i]);
            }
        }

        //private void readAllFiles()
        //{
        //    string path = @"C:\Users\leele\Documents\NewsDataset";
        //    string searchPattern = "*.txt";
        //    string fileName;
        //    string[] MyFiles = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);
        //    foreach(string filePath in MyFiles)
        //    {
        //        fileName = Path.GetFileName(filePath);
        //        FileProcessMethod(filePath);       
        //    }



        //} 

        //private void FileProcessMethod(string filePath)
        //{
        //    StreamReader sr = new StreamReader(filePath);
        //    string text = sr.ReadToEnd();
        //    //TextPreprocess(text);
        //    richTextBox1.Text = text.ToString();
        //    sr.Close();
        //}

        private string[] TextPreprocess(string text)
        {
           
            //trim punctuation marks
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (!char.IsPunctuation(c) && c != '+')
                    sb.Append(c);
            }
            //convert text to all small letters
            string removedPunc = (sb.ToString()).ToLower();

            //trim stop-words
            string[] words = removedPunc.Split(' ');
            StringBuilder builder = new StringBuilder();


            foreach (var word in words)
            {

                if (!stopword.ContainsKey(word))

                {
                    builder.Append(word).Append(' ');
                }

            }

            string afterProcess = builder.ToString().Trim();


            string[] keyword = afterProcess.Split(' ');

    
            string[] afterStem = this.stemmer(new EnglishStemmer(), keyword);


            return keyword;
        }

        private string[] stemmer(IStemmer stemmer, params string[] words)
        {
            List<string> after = new List<string>();
            foreach (string word in words)
            {

                Console.WriteLine(word + " --> " + stemmer.Stem(word));
                for (int i = 0; i < words.Length; i++)
                {
                   after.Add(stemmer.Stem(word));
                    
                }
            }
            return after.ToArray();

        }

        private static void findSysnonym(string[] keywords)
        {
            List<string> sysWord = new List<string>();
            foreach(string word in keywords)
            {
                
            }
        }
        private double encodeKeyWord(string[] keywords, string[] keyword2)
        {
            List<int> matchValue = new List<int>();
            List<int> afterEncode = new List<int>();
            List<int> PrimeDoc = new List<int>();
            
           
            foreach (string keyword in keywords)
            {
                int index = encodeDict.Values.Last() + 1;
              
                
               
                if (!encodeDict.ContainsKey(keyword))
                {

                    encodeDict.Add(keyword, index);
                    
                }

                if (encodeDict.ContainsKey(keyword))
                {
                   
                    int matchVal = encodeDict[keyword];
                   
                    matchValue.Add(matchVal);


                }
                PrimeDoc.Add(1);
              
            }

            int[] prime = PrimeDoc.ToArray();
           

            foreach (string kw2 in keyword2)
            {
                int index1 = encodeDict.Values.Last() + 1;
                if (!encodeDict.ContainsKey(kw2))
                {

                    encodeDict.Add(kw2, index1);

                }


         
                int match2 = encodeDict[kw2];
             
                if (matchValue.Contains(match2) == true)
                    {
                       
                        afterEncode.Add(1);

                    }
                else
                   {
                       
                        afterEncode.Add(0);

                   }

            }

            int[] doc2 = afterEncode.ToArray();
            
            double coScore = cosineSimilarity(PrimeDoc,afterEncode);

          
            return coScore;
        }

        public static float cosineSimilarity(List<int> doc1, List<int> doc2)
        {
         
            if (doc1.Count > doc2.Count)
            {
                do
                {
                    doc2.Add(0);
                }
                while (doc1.Count > doc2.Count);
            }
            else if (doc2.Count > doc1.Count)
            {
                do
                {
                    doc1.Add(0);
                }
                while (doc2.Count > doc1.Count);
            }

            
                int[] d1 = doc1.ToArray();
                int[] d2 = doc2.ToArray();

                float denom = (VectorLength(d1) * VectorLength(d2));
                if (denom == 0F)
                    return 0F;
                else
                return (InnerProduct(d1, d2) / denom);


            
        }

        public static float InnerProduct(int[] vector1, int[] vector2)
        {

            float result = 0F;
            for (int i = 0; i < vector1.Length; i++)
                result += vector1[i] * vector2[i];

            return result;
        }

            public static float VectorLength(int[] vector)
        {
            float sum = 0.0F;
            for (int i = 0; i < vector.Length; i++)
                sum = sum + (vector[i] * vector[i]);

            return (float)Math.Sqrt(sum);
        }

        //rarity calculation
        public string rarityCal(List<double> scoreList, int i)
        {
            Console.WriteLine("-------------doc + {0}-------------------", i);
            
            //showdoubleData(scoreList);
          
            double stdDv = 0;
            double sum = 0;
            int count = 0;
            double mean = 0;
            double distanceMean = 0;
            double sumDisMean = 0;
            double devidesumDisMean = 0;
            string level;
    

            // 1: find the mean

            foreach (double fs in scoreList)
            {
                sum += fs;
                count++;
                //Console.WriteLine("sum = {0}", sum);

            }
            mean = sum / count;
            Console.WriteLine("mean = {0}", mean);

            //2. find the sum of square of each data point distance to the mean
            foreach (double fs in scoreList)
            {
                distanceMean = Math.Pow(fs - mean, 2);
                //Console.WriteLine("DM = {0}", distanceMean);
                sumDisMean += distanceMean;
            }
            Console.WriteLine("DM = {0}", sumDisMean);

            // 3. divide by the number of count 
            devidesumDisMean = sumDisMean / count;

            //4. take the square roote
            stdDv = Math.Sqrt(devidesumDisMean);
            Console.WriteLine("standard deviation = {0}", stdDv);



            // determine the
            double lowbound = mean - stdDv;
            double highbound = mean + stdDv;
            int rare = 0;
            int normal = 0;
            int popular = 0;

            foreach(double sc in scoreList)
            {
                if (sc > highbound)
                {
                    popular++;
                }
                else if (sc < lowbound)
                {
                    rare++;
                }
                else{
                    normal++;
                }
            }

            Console.WriteLine("rare = {0} , normal = {1}, popular = {2}", rare, normal, popular);

            if (rare  > normal && rare > popular)
            {
             
                level = "rare news";
                richTextBox2.Text = level;
                
              
            }
            else if(normal > rare && normal > popular)
            {
                
                level = "normal news";
                richTextBox2.Text = level;
            }
            else
            {
              
                level = "popular news";
            }
            scoreList.Clear();
            
            return level;
        }
    


    private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
           
            
        }
        int newsCount = -1;
        
        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (newsCount < newsList.Count)
            {
                newsCount++;
            }
            
            richTextBox1.Text = newsList[newsCount];
            richTextBox2.Text = rarityLevel[newsCount];
            
           

            
              

        }

 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void prevBtn_Click_1(object sender, EventArgs e)
        {
            if (newsCount > 0)
            {
                newsCount--;
            }
            richTextBox1.Text = newsList[newsCount];
            richTextBox2.Text = rarityLevel[newsCount];


        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
