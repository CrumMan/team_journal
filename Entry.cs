using System.Collections.Generic;

public class EesEntry{
    public string _eesDate = DateTime.Now.ToString("MM/dd/yyyy");
    public string _eesText;


    

    public List<string> EesPrompts =  new List<string> {
        "Who was the most interesting person I interacted with today? ", 
        "What was the best part of my day? ",
        "How did I see the hand of the Lord in my life today? ",
        "What was the strongest emotion I felt today? ", 
        "If I had one thing I could do over today, what would it be? ",
        "What was the most interesting thing I learned today? "
    };

    public string _eesPrompt;
    
    public int EesChoosePrompt(){
        Random eesRandomGenerator = new Random();
        int eesRandomNumber = eesRandomGenerator.Next(0,4);
        return eesRandomNumber;

        
    }
    

    public void EesFormatEntry(){
        Console.WriteLine($"Date: {_eesDate} - Prompt: {_eesPrompt}");
        Console.Write("> ");
        _eesText = Console.ReadLine();
    }

    public void EesDisplayCompleteEntry(){
        Console.WriteLine($"Date: {_eesDate} - Prompt: {_eesPrompt}");
        Console.WriteLine($"> {_eesText}");
        

    }

    public string EesCompleteEntry(){
        string fullEntry = $"Date: {_eesDate} - Prompt: {_eesPrompt} \n > {_eesText}";

}
