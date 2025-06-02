using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace ConsoleApp1
{
    internal class Program
    {
        static void LogQuestionsToFile(Qestionlist questionList, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true)) 
            {
                foreach (var question in questionList)
                {
                    writer.WriteLine("----- Question -----");
                    writer.WriteLine($"Type: {question.GetType().Name}");
                    writer.WriteLine($"Header: {question.Header}");
                    writer.WriteLine($"Body: {question.body}");
                    writer.WriteLine($"Marks: {question.Mark}");
                    writer.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Student s1 = new Student { id = 1, name = "Ali" };
            Student s2 = new Student { id = 2, name = "Sara" };

            Console.WriteLine("Choose Exam Type: 1- Practice  2- Final"); 
            int choice = int.Parse(Console.ReadLine());
            Exam exam; 

            if (choice == 1)
                exam = new PracticeExam();
            else
                exam = new FinalExam();

            exam.onStarted += () => Console.WriteLine($"{s1.name} has been notified: Exam started.");
            exam.onStarted += () => Console.WriteLine($"{s2.name} has been notified: Exam started.");

            var questionList = new Qestionlist();
            var answerList = new Answerslist();

            var q1 = new Trueorflase(5, "Math Basics", "Is 2+2=4?");
            var q2 = new Chooseone(10, "Science", "What is the boiling point of water?\nA) 50°C  B) 100°C  C) 150°C");
            var q3 = new Chooseall(15, "Programming", "Which of the following are OOP concepts?\nA) Encapsulation  B) Abstraction  C) Sorting");



            questionList.AddQuestion(q1);
            questionList.AddQuestion(q2);
            questionList.AddQuestion(q3);

            var a1 = new Answers { Correct = "True" };
            var a2 = new Answers { Correct = "B" };
            var a3 = new Answers { Correct = "A,B" };

            answerList.AddAnswer(a1);
            answerList.AddAnswer(a2);
            answerList.AddAnswer(a3);

            LogQuestionsToFile(questionList, "ExamQuestionsLog.txt");


            for (int i = 0; i < questionList.Count; i++)
            {
                exam.ExamData.Add(questionList[i], answerList[i]);
            }

            exam.Status = ExamStatus.Started;

            Console.WriteLine("\n--- Exam Content ---\n");
            exam.ShowAnswer();

            exam.Status = ExamStatus.Finished;

            Console.WriteLine("\nExam Finished.");
        }
    }
}
