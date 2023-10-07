//Name: My Journal
//Purpose: The purpose of this program is to allow the user to record journal entries according to certain prompts, 
//the user may load and display journal entries later, as well as save and exit the program.
//Team: Lisa Heinhold, Kaden Hansen, Joshua Pyle, Emma Shurtliff, Adam Schwartz, and Olivia Smart.
//Date: 10/7/2023

using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Transactions;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
class Program
{
    // Menu
    static string JTPMenuMethod(EesJournal eesMyJournal){
        
        Console.WriteLine("Welcome to your electronic Journal!");
        Console.WriteLine();
        Console.WriteLine("             Actions:            ");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Enter 1 to Write");
        Console.WriteLine("Enter 2 to Display");
        Console.WriteLine("Enter 3 to Save");
        Console.WriteLine("Enter 4 to Load");
        Console.WriteLine("Enter 5 to Exit");
        Console.WriteLine("----------------------------------");
        string prompt = "";
        do{
            Console.Write("Enter action: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number == 1){
            prompt = "You chose to create a new entry.";
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine("Please answer the following question:");
            EesEntry eesEntry1 = new EesEntry();
            int eesPromptNumber = eesEntry1.EesChoosePrompt();
             eesEntry1._eesPrompt = eesEntry1.EesPrompts[eesPromptNumber];
                
            eesEntry1.EesFormatEntry();
            eesMyJournal._eesEntry.Add(eesEntry1);
            Console.WriteLine();
            Console.WriteLine("Your entry has been submitted.");
            Console.Write("Press enter to continue: ");
            string _ = Console.ReadLine();

        }
        else if (number == 2){
             prompt = "Select an entry";
                        eesMyJournal.DisplayJournal();
        }
        else if (number == 3){
            prompt = "You chose to save your journal entry.";
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine("To save your journal, type the name of your file in the next line. If the file already exists, your Journal Entries will be added to the bottom of the file. If the file down not exist, it will be created and the entries will be put in it.");
            Boolean eesSaved = false;
            do{
            Console.WriteLine("Which file would you like to save your Journal to? (Should end in .txt or .csv) ");
            string eesUserFile = Console.ReadLine();
            if (eesUserFile.EndsWith(".txt") || eesUserFile.EndsWith(".csv")){
            EesSaveFile(eesUserFile, eesMyJournal);
            Console.WriteLine();
            Console.Write("Your Journal has been saved");
            Console.Write("Press enter to continue: ");
            string _ = Console.ReadLine();
            eesSaved = true;
            }
            else{
                Console.WriteLine("Your chosen file was not a text or csv file. Please try again.");
            }
            }while (eesSaved == false);
        }
        else if (number == 4){
            prompt = "You chose to load a file";
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine("Please follow these instructions:");
            Console.Write("Which file do you wish to load entries from? (include file extension): ");
            string khFileName = Console.ReadLine();
            var (khQuestions, khAnswers, khDates) = khReadFile(khFileName);
            for (int i = 0; i < khQuestions.Count; i++) {
                EesEntry khEesEntryLoaded = new EesEntry();
                khEesEntryLoaded._eesDate = khDates[i];
                khEesEntryLoaded._eesPrompt = khQuestions[i];
                khEesEntryLoaded._eesText = khAnswers[i];
                eesMyJournal._eesEntry.Add(khEesEntryLoaded);
            }
            Console.WriteLine();
            Console.WriteLine($"Your entries from {khFileName} have been loaded successfully.");
            Console.Write("Press enter to continue: ");
            string _ = Console.ReadLine();

        }
        else if (number == 5){
            prompt = "Exit this program";
        }
        }
        while (prompt == "");
        return prompt;
    }
   
    static void LhSelectEntry()
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
 
    // Save Journal (Save the current journal into a CSV file Emma S.)
 static void EesSaveFile(string fileName, EesJournal eesMyJournal){

        using (StreamWriter writer = new StreamWriter(fileName, true)){
            writer.Write(eesMyJournal.FormatJournal());
        }
    }

    // Load a File (Kaden Hansen)
    static (List<string>, List<string>, List<string>) khReadFile(string khFilename)
    {
        List<string> khLines = new List<string>();

        try
        {
            // Read the file and store each line in the list
            using (StreamReader reader = new StreamReader(khFilename))
            {
                string khLine;
                while ((khLine = reader.ReadLine()) != null)
                {
                    khLine = khLine.TrimStart();
                    if (khLine.StartsWith('D')) {
                        khLine = khLine.Replace("Date: ", "").Replace("Prompt: ", "");
                    }
                    if (!string.IsNullOrWhiteSpace(khLine))
                        {
                        khLines.Add(khLine);
                        }
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            // Handle file not found error
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
        
        List<string> khQuestionsList = new List<string>();
        List<string> khAnswersList = new List<string>();
        List<string> khDatesList = new List<string>();
        foreach (string khEntryLine in khLines)
        {
            string khLine = khEntryLine.Trim();
            if (char.IsDigit(khLine[0])) {
                string[] khSplitQuestionLine = khEntryLine.Split('-');
                foreach (string khSplitQuestionString in khSplitQuestionLine) {
                    string khSplitString = khSplitQuestionString.Trim(); 
                    if (char.IsDigit(khSplitString[0])) {
                        string khDate = khSplitString;
                        khDatesList.Add(khDate);
                }
            else if (khSplitString.EndsWith("?")) {
                string khQuestion = khSplitString;
                khQuestionsList.Add(khQuestion);
            }
              }
            }
            else if (khLine.StartsWith('>')) {
                khLine = khLine.Remove(0, 1);
                string khAnswer = khLine.Trim();
                khAnswersList.Add(khAnswer);
                }
            else if (khLine == "") {
                continue;
            }
            else {
                Console.WriteLine("The file you gave contains text that is not in the journal format.");
                Console.Write("Press enter to continue: ");
                string _  = Console.ReadLine();
                break;
            }

        }
            
        return (khQuestionsList, khAnswersList, khDatesList);
    }
 
    // Exit this program (Done)
    static void Main(string[] args)
    {
        EesJournal eesMyJournal = new EesJournal();
        string menuPrompt = "";
        do{
        menuPrompt = JTPMenuMethod(eesMyJournal);
        Console.WriteLine("");
        }
        while(menuPrompt != "Exit this program");
    }
}
