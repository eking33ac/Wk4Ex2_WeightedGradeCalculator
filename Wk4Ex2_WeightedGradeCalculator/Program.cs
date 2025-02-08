using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Wk4Ex2_WeightedGradeCalculator
{
    internal class Program
    {

        // a method to ensure double input is valid
        static double HandleDoubleInput(string aPrompt, string anErrorMessage = "Your input is invalid. Please enter a valid number input.")
        {
            // initialize return value
            double returnValue = Double.MaxValue;


            // processing


            // start of a do while loop
            do
            {
                // A try catch to ensure the user input is valid
                try
                {
                    // Ask user to input a number
                    Console.Write(aPrompt);
                    // Convert user input to a double, collect input from user and store it in the returnValue
                    returnValue = Convert.ToDouble(Console.ReadLine());
                }
                // if that doesn't work, output an error message
                catch (Exception e)
                {
                    // output an error message
                    Console.WriteLine(anErrorMessage);
                }
            }
            // loop until returnValue has a different value
            while (returnValue == Double.MaxValue);


            // return returnValue
            return returnValue;
        }



        // a method to average grades inputted by a user
        static double AverageGrades(string aPrompt = "Please enter a new grade: ", string gradeType = "assignment")
        {
            // initialize return value
            double returnValue = Double.MaxValue;

            // processing

            // Declare Variables
            double sum = 0;         // Declare double variable for the sum and initialize it to 0
            double average = Double.MaxValue;       // Declare double variable for the average and initialize it to the maximum double value
            double grade = Double.MaxValue;     // Declare double variable for the grade the user will input and initialize it to the maximum double value
            int counter = 0;        // Declare double variable for the counter and initialize it to 0. This will count how many total grades the user inputs.


            // user enters a grade before the loop begins, so the Double.MaxValue is not added to their grade sum
            grade = HandleDoubleInput(aPrompt);

            // use a while loop to have the user input a new grade which gets added to the grade sum.
            do
            {
                // add grade to the sum of grades
                sum += grade;
                // confirm with the user that their grade was input. Tell them to input another grade of -1 to move on.
                Console.WriteLine($"Your grade {grade} has been added to the {gradeType} grades.\nEnter another grade or -1 to move on.");
                // add 1 to the counter variable.
                counter += 1;
                // input new grade at the end of the loop to check the condition with
                grade = HandleDoubleInput(aPrompt);
            }
            // if the grade is -1, exit loop.
            while (grade != -1);


            // calculate the average by dividing the sum by the number of parts
            average = sum / counter;


            // asign the average to the return value
            returnValue = average;


            // return returnValue
            return returnValue;
        }



        // a method to calculate final grade based on weight of assignments, midterms, and finals
        static double CalculateFinalGrade(double assignments, double midterms, double finals)
        {
            // initialize return value
            double returnValue = Double.MaxValue;

            // processing

            // Declare Variables
            double finalGrade = Double.MaxValue;        // declare double variable for the finalGrade

            double assignmentWeight = 0.40;      // declare double variable containing assignment weight percentage
            double midtermWeight = 0.30;      // declare double variable containing assignment weight percentage
            double finalWeight = 0.30;      // declare double variable containing assignment weight percentage


            // calculate the final grade
            finalGrade = (assignments * assignmentWeight) + (midterms * midtermWeight) + (finals * finalWeight);

            // Set return value to the final grade
            returnValue = finalGrade;

            // return returnValue
            return returnValue;
        }

        static void Main(string[] args)
        {
            // Calculate Overall Assignment Grade
            double assignmentAverage = Double.MaxValue;       // declare double variable to hold the assignment average
            double midtermAverage = Double.MaxValue;        // declare double variable to hold the midterms average
            double finalAverage = Double.MaxValue;      // declare double variable to hold the finals average
            double finalGrade = Double.MaxValue;        // declare double variable to hold the final class grade


            // Display app title
            Console.WriteLine("Final Class Grade Calculator");
            // A gap between lines for ease of reading
            Console.WriteLine();


            // Calculate overall Assignments grade
            assignmentAverage = AverageGrades("Please enter a new assignment grade: ", "assignment");
            // A gap between lines for ease of reading
            Console.WriteLine();


            // Calculate Overall Midterm Grade
            midtermAverage = AverageGrades("Please enter a new midterm grade: ", "midterm");
            // A gap between lines for ease of reading
            Console.WriteLine();


            // Calculate Overall Final Exam Grade
            finalAverage = AverageGrades("Please enter a new final exam grade: ", "final");
            // A gap between lines for ease of reading
            Console.WriteLine();



            // Calculate Final Grade
            finalGrade = CalculateFinalGrade(assignmentAverage, midtermAverage, finalAverage);


            // Display final grade
            Console.WriteLine($"Your final class grade is {finalGrade:F}");
            // A gap between lines for ease of reading
            Console.WriteLine();



            // Thank the user
            Console.WriteLine("Thank you for using the final class grade calculator! Come again!");


            // Pause screen for user to read
            Console.ReadLine();
        }
    }
}
