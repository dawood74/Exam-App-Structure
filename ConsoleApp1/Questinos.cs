using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

     abstract class    Questinos
    {
        public int Mark  { get; set; }
        public string Header { get; set; }
         
        public string body { get; set; }

       public Questinos(int _marker, string _header , string  _body ) 
        {
            Mark = _marker;
            Header = _header;
            body = _body;
            
        
        }

        public  abstract void represent(); 
    }

    class Trueorflase:Questinos
        
    {

        public Trueorflase(int _marker, string _header, string  _body): base( _marker,  _header, _body)
        {
        
        }
        public override void represent() 
        
        {
            Console.WriteLine($"[True/False Question] {Header}\n{body}\nMarks: {Mark}");

        }




    }

    class Chooseone:Questinos 
    
    {
        public Chooseone(int _marker, string _header, string _body) : base(_marker, _header, _body)

        { 
        
        }


        public override void represent()

        {
            Console.WriteLine($"[Choose One Question] {Header}\n{body}\nMarks: {Mark}");

        }


    }

    class Chooseall:Questinos
    
    {
        public  Chooseall(int _marker, string _header, string _body) : base(_marker, _header, _body) 
        
        { 
        
        
        } 
        public override void represent()
        {
            Console.WriteLine($"[Choose All Question] {Header}\n{body}\nMarks: {Mark}");

        }

    }

    class Qestionlist:List<Questinos> 
    { 
        public void AddQuestion(Questinos q) 
       
        {
            this.Add(q); 
        
        }
    
    }

    class Answers 
    {
        public string Correct { get; set; } 

    } 
    class Answerslist:List<Answers>
    
    {

        public void AddAnswer(Answers ans) 
        
        {
            this.Add(ans);

        }
       
    }

}
 
 
