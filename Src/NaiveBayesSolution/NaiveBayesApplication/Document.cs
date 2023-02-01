using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBayesApplication
{
    public class Document
    {
        private int label;
        private string rawData;
        private List<string> tokenList;
        private int inferredLabel = -1;
        private List<double> classLogProbabilityList;

        public Document()
        {
            tokenList = new List<string>();
            inferredLabel = -1;
            classLogProbabilityList = new List<double>();
        }

        public static Document Merge(List<Document> documentList)
        {
            Document mergedDocument = new Document();
            mergedDocument.Label = documentList[0].Label;
            for (int ii = 0; ii<  documentList.Count; ii++)
            {
                for (int jj = 0; jj < documentList[ii].TokenList.Count;jj++)
                {
                    mergedDocument.TokenList.Add(documentList[ii].TokenList[jj]);
                }
            }
            return mergedDocument;
        }

        // To do: Write this method.
        public void Clean()
        {
            // Step 1: Convert the raw data string to lower-case. Hint: use ToLower()


            // Step 2: Clean the raw data strings by
            // (a) removing special characters, e.g. " , ( , ) , { , } , [ , ] , <, >, -, ... and so on.
            //     Hint: Repeatedly use the Replace() method (taking two strings as input)
            //           Do not worry about performance - the data set is small in this case.
            //
            //     Notes: (1) remove also the ' character *when it is used as a quote*, e.g.
            //                as in: 'worst restaurant ever'. However, make sure to *keep*
            //                the ' character in contractions such as don't, won't, can't etc.
            //
            //            (2) be careful when removing the - character, replacing it by a space instead of
            //                of an empty string, to avoid turning sequences such as best-restaurant-ever
            //                into a single word.
            //
            //            ... and so on: There might be more things to do - you have to figure it out.
        }

        // To do: Write this method.
        public void Tokenize()
        {
            Char[] splitList = new char[] { ' ', ',', ';', '.', '!', '?' };

            // Tokenize the raw data string into words,
            // removing ' ' and any interpunction characters characters, e.g. , . ! ? ...
            // Hint: Use the Split() command and the split list defined above.
            // Make sure to remove empty strings (using StringSplitOptions ...).
        }

        // To do: Write this method.
        public void RemoveStopWords(List<string> stopWordList)
        {
            // Write a method for removing stop words
            // Hint: Apply the Contains() method to the stopWordList,
            // with the current token as input

        }


        // This method returns the document as a single string (used for visualization in the MainForm)
        // If the document has not been tokenized, the method simply returns the raw data,
        // otherwise is returns the concatenated list of tokens.
        public string AsString()
        {
            if (tokenList.Count == 0)
            {
                return  label.ToString() + " " + rawData;
            }
            else
            {
                string documentAsString = label.ToString() + " ";
                foreach (string token in tokenList) { documentAsString += token + " "; };
                documentAsString = documentAsString.TrimEnd(' ');
                return documentAsString;
            }
        }
        
        public int Label
        {
            get { return label; }
            set { label = value; }
        }

        public string RawData
        {
            get { return rawData; }
            set { rawData = value; }
        }

        public int InferredLabel
        {
            get { return inferredLabel; }
            set { inferredLabel = value; }
        }

        public List<string> TokenList
        {
            get { return tokenList; }
            set { tokenList = value; }
        }

        public List<double> ClassLogProbabilityList
        {
            get { return classLogProbabilityList; }
            set { classLogProbabilityList = value; }
        }
    }
}
