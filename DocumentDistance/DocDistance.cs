using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DocumentDistance
{
    /*{أَلَّا تَزِرُ وَازِرَةٌ وِزْرَ أُخْرَى ۝ وَأَنْ لَيْسَ لِلإِنسَانِ إِلَّا مَا سَعَى ۝ وَأَنَّ سَعْيَهُ سَوْفَ يُرَى ۝ ثُمَّ يُجْزَاهُ الْجَزَاءَ الأَوْفَى}

    اللهم صلي و سلم  وبارك علي سيدنا محمد
           لا اله الا الله محمد رسول الله
   -: It's hard to beat a person who never gives up and extinct
   -: Life is a race, if you don't beat it ,don't cry 
   -: Don't worry about people's plots against you, for the most they can
      do to you is carrying out Allah's will
   -: I have not failed, I have just found 1000 WAYS that won't work.
   */
    class DocDistance
    {
        
        

        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {
            // Split each document into words and count word frequencies
            var doc1Freq = GetWordFrequencies(doc1FilePath); // ** Read Document1 and Calculate the Frequency  
            var doc2Freq = GetWordFrequencies(doc2FilePath); // ** Read Document2 and Calculate the Frequency  

            // Calculate the dot product of the document vectors
            var dotProduct = 0.0;
            foreach (var word in doc1Freq.Keys.Intersect(doc2Freq.Keys)) // ** Mult the common words frequency 
            {
                dotProduct += doc1Freq[word] * doc2Freq[word];
            }

            // Compute the magnitudes of the document vectors
            var doc1Magnitude = Math.Sqrt(doc1Freq.Values.Sum(x => x * x));
            var doc2Magnitude = Math.Sqrt(doc2Freq.Values.Sum(x => x * x));

            var result = 0.0;
            if (dotProduct == 0) //** To avoid the NaN or Division by zero 
            {
                result = 0;
            }
            else
            {
                result = dotProduct / (doc1Magnitude * doc2Magnitude);
            }

            // Compute the angle between the document vectors in degrees
            var angle = Math.Acos(Math.Max(-1, Math.Min(result, 1))) * 180 / Math.PI; //** To make the result between the 1 : -1
            return angle;
        }

        /// <summary>
        /// /Helper method to split a document into words and count word frequencies/
        /// </summary>
        /// <param name="filePath"></param>

        private static Dictionary<string, long> GetWordFrequencies(string filePath)
        {
            // Create a new dictionary to hold the word frequencies
            var freq = new Dictionary<string, long>();

            // Define a regular expression to split each line into words
            var regex = new Regex(@"[\W_]+|(?<=\w)'(?=\w)|(?<=\w)'(?!\w)", RegexOptions.Compiled);

            // Open the file for reading using a stream reader
            using (var streamReader = new StreamReader(filePath))
            {
                // Read the file line by line until the end of the stream is reached
                while (!streamReader.EndOfStream)
                {
                    // Read the next line from the file
                    var line = streamReader.ReadLine();

                    // Split the line into words using the regular expression
                    foreach (var word in regex.Split(line))
                    {
                        // Skip over any whitespace or empty words
                        if (string.IsNullOrWhiteSpace(word))
                        {
                            continue;
                        }

                        // Convert the word to lowercase for case-insensitive comparison
                        var wordLower = word.ToLower();

                        // If the word is already in the dictionary, increment its count
                        if (freq.ContainsKey(wordLower))
                        {
                            freq[wordLower]++;
                        }
                        // Otherwise, add the word to the dictionary with a count of 1
                        else
                        {
                            freq[wordLower] = 1;
                        }
                    }
                }
            }

            // Return the dictionary of word frequencies
            return freq;
        }

    }
}
