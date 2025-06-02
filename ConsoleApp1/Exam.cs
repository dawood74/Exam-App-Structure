using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    
    public enum ExamStatus
    
    {
        Started ,
        Queued,
        Finished 
    } 
    abstract class Exam
    {

        public event Action onStarted; 
        public int QuestionCount { get; set; }
        public string Time { get; set; }
        private ExamStatus status;

        public ExamStatus Status
        {
            get { return status; }

            set { 
                status = value;
                if (value ==ExamStatus.Started) 
                
                {
                    onStarted?.Invoke();

                }
            
            
            
            }
        }




        public Dictionary<Questinos, Answers> ExamData { get; set; } = new Dictionary<Questinos, Answers>();

        public abstract void ShowAnswer();
    }

    class FinalExam : Exam
    {
        public override void ShowAnswer()
        {
            Console.WriteLine("Final Exam");
            foreach (var item in ExamData)
            {
                item.Key.represent();
                Console.WriteLine();
            }
        }
    }

    class PracticeExam : Exam
    {
        public override void ShowAnswer()
        {
            Console.WriteLine("Practice Exam");
            foreach (var item in ExamData)
            {
                item.Key.represent();
                Console.WriteLine($"Correct Answer: {item.Value.Correct}");
                Console.WriteLine(); 

            }
        }

    }


    class Subject
    
    {

        public string  subject  { get; set; }   
        public int id { get; set; }

        public Exam subjectExam  { get; set; }


    }

    class Student 
    {


        public string name { get; set; }
        public int id { get; set; }   


    
    }



}
