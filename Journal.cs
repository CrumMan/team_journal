public class EesJournal{
    public List<EesEntry> _eesEntry = new List<EesEntry>();

    public void DisplayJournal(){
        Console.WriteLine();
        foreach (EesEntry eesSingleEntry in _eesEntry){
            eesSingleEntry.EesDisplayCompleteEntry();
            Console.WriteLine();
        }
    }

    public string FormatJournal(){
        string fullJournal = "";
        foreach (EesEntry eesSingleEntry in _eesEntry){
            fullJournal = $"{fullJournal} \n {eesSingleEntry.EesCompleteEntry()}";
        }
            fullJournal = $"{fullJournal} \n";
            return fullJournal;


         
    }
}
