using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Transactions;
class Program
{
    // Menu
    static string JTPMenuMethod(){
        Console.WriteLine("Welcome to your electronic Journal!");
        Console.WriteLine("Enter 1 to Write");
        Console.WriteLine("Enter 2 to Display (Save First)");
        Console.WriteLine("Enter 3 to Save");
        Console.WriteLine("Enter 4 to Load");
        Console.WriteLine("Enter 5 to Exit");
        string prompt = "";
        do{
        int number=Convert.ToInt32(Console.ReadLine());
        if (number == 1){
           prompt = "New Entry";
        }
        else if (number == 2){
            prompt = "Select an entry";
        }
        else if (number == 3){
            prompt = "Save your Journal";
        }
        else if (number == 4){
            prompt = "Load a file";
        }
        else if (number == 5){
            prompt = "Exit this program";
        }
        }
        while (prompt == "");
        return prompt;
    }
    // New Entry (The Return should be in the form of a dictionary 0 being date 1 being the entry Adam S.)
 
    // Select an Entry (A list of Dates should be created and prompted to the user. After they should be able to select the desired date Lisa H.)
class LhSelectEntry 
{
    static void Main()
    {
        //get dat from super
        Console.Write("Enter the date you want to select (MM/DD/YYYY): ");
        string lhDateInput = Console.ReadLine();
        //check if input is valid 
        if (!lhDateInput.Contains("/") || lhDateInput.Length != 10)
        {
            Console.WriteLine("Invalid Date Format.");
            return;
        }
        //look for file
        string lhFilePath = "journal.csv";
        //check to see if file exists
        if (!File.Exists(lhFilePath))
        {
            Console.WriteLine("The journal.csv file does not exist.");
            return;
        }
        //read the jounral.csv file and look for the date the user gave
        var LhLines = File.ReadLines(lhFilePath);
        var LhEntry = LhLines.FirstOrDefault(line => line.StartsWith(lhDateInput));
        //if entry found display date, prompt, entry
        if (LhEntry != null)
        {
            var LhFeilds = LhEntry.Split(',');
            Console.WriteLine("Date: {0}", LhFeilds[0]);
            Console.WriteLine("Prompt: {0}", LhFeilds[1]);
            Console.WriteLine("Journal entry: {0}", LhFeilds[2]);
        }
        else
        {
            //if no date found
            Console.WriteLine("No Jounral Entry found for the date {0}.", lhDateInput);
        }
    }
}
 
    // Save Journal (Save the current journal into a CSV file Emma S.)
 
    // Load a File (It should return a list of entries in their given dictionaries from a CSV file in the same format that a saved file would be inserted. Olivia S.)
 
    // Exit this program (Done)
    static void Main(string[] args)
    {
        string menuPrompt = "";
        do{
        menuPrompt = JTPMenuMethod();
        Console.WriteLine("you have chosen to " + menuPrompt);
        Console.WriteLine("");}
        while(menuPrompt != "Exit this program");
    }
}