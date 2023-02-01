using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBayesApplication
{
    public class PerformanceMeasure
    {
        public double Accuracy { get; set; }
        public double Precision { get; set; }
        public double Recall { get; set; }
        public double F1 { get; set; }

        // To do: Write this method.
        public void Compute(List<Document> documentList)
        {
            int truePositiveCount = 0;
            int falsePositiveCount = 0;
            int trueNegativeCount = 0;
            int falseNegativeCount = 0;

            // Write code here for counting TP, FP, TN, and FN (using the
            // fields define just above), and then computing accuracy, precision, 
            // recall, and F1.
            // 
            // Here, you should assume that the classification is binary, with
            // the two labels 0 (negative) and 1 (positive).
            //
            // Note: Since you will be dividing integers, make sure
            // typecast the denominator as (double), otherwise C# will
            // use integer division => 0 (or, in rare cases, 1).
            // If you're unsure what "typecasting" means just search for
            // "typecast C#" or something like that ...

            foreach (Document doc in documentList)
            {
                if (doc.Label == 0)
                {
                    if (doc.InferredLabel == 0)
                    {
                        trueNegativeCount++;
                    }
                    else
                    {
                        falsePositiveCount++;
                    }
                }
                else
                {
                    if (doc.InferredLabel == 0)
                    {
                        falseNegativeCount++;
                    }
                    else
                    {
                        truePositiveCount++;
                    }
                }
            }

            this.Accuracy = (double)(truePositiveCount + trueNegativeCount) / (documentList.Count);
            this.Precision = (double)truePositiveCount / (truePositiveCount + falsePositiveCount);
            this.Recall = (double)truePositiveCount / (truePositiveCount + falseNegativeCount);
            this.F1 = 2 / (1 / this.Recall + 1 / this.Precision);
        }
    }
}
