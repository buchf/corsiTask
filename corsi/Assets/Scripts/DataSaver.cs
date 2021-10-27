using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;





public class DataSaver : MonoBehaviour
{


    public static string rightTask, falseTask, totalClicks, accuracy;
    public static double totalTime;
   // public static string accuracy, totalClicks;
    public Text amountRightTask;
    public Text amountFalseTask;
    public Text totalClicksCounter;
    public Text totalAccuracyCounter;
    public float accuracyPercentage = 0.0f;

    //Number for full programm for e.g.  (2 + 3 + 4) * 8 Trials = 72
    int amountOfFullCorsiTaskClicks =  72;


    //VPN nummer soll im gesamten project den Input vom Textfeld VPN bekommen sodass die datei auf diejenige Versuchsperson sich bezieht
    public static int VPN; 
    static string fileName = "VPN"+ VPN + "_corsi.csv";
    
    public static string filePath = Path.Combine(Application.persistentDataPath, fileName);

    public static List<StringBuilder> results = new List<StringBuilder>();
    public static StringBuilder z2 = new StringBuilder();
    public StringBuilder z1 = new StringBuilder();

   

    private void Start()
    {

        
        
        accuracyPercentage = float.Parse(accuracy) / amountOfFullCorsiTaskClicks * 100;
        amountRightTask.text = "Richtige Sequenzen: " + rightTask;
        amountFalseTask.text = "Falsche Sequenzen: " + falseTask;
        totalClicksCounter.text = "Anzahl Klicks: " + totalClicks;
        totalAccuracyCounter.text = "Accuracy: " + accuracyPercentage.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "%";



        /*
         * z1 ist die Struktur fuer die "overall" - Results
         * z1 ist zustaendig fuer die gesamten richtigen Sequenzen, die Genauigkeit 
         * der erzielten Klicks, die Gesamte benoetigte Zeit fuer die Sequenz in ms
         *
         * anschliessend wird z2 angehaengt, welche jeden input ueber die drei MeasuereSequenz Funktionen 
         * bekommt (siehe unten)
         * 
         * 
         */

        z1.Append("Corsi\n" + ",Sequenzes correct:," + rightTask + " of " + Player.currentSequenzCounter + "\n");
        z1.Append(",Clicks Accuracy:," + accuracyPercentage.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "%\n" + ",total Time: ," + totalTime.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +"ms\n");
        z1.Append("\n,Trial no., Full Sequenz correct,Reaction Time,First click,Second click,Third click,Fourth click\n");
        results.Add(z1);
        results.Add(z2);
        File.WriteAllText(filePath, listToString(results));

    }


    /*
     * Notwendige funktion um die Liste results in einen String umzuwandeln,
     * da die Funktion File.WriteAllText() einen String benoetigt
     */
    private string listToString(List<StringBuilder> results)
    {
        string x = "";
        foreach (var element in results)
        {
            x = x + element.ToString();
        }
        
        return x;
    }


    /* 
     * measuere writing functions and adding to the List results 
     * 
     * Drei verschieden, da es drei verschieden lange Sequenzen gibt 
     * die Funktionen werden in der Klasse Player aufgerufen mit Hilfe
     * der WriteInDatasaver() Funktion
     * 
     * Die Daten weden im Stringbuilder z2 abgespeichert und anschliessend
     * in der obigen Start() Funktion in die Liste results hinzugefuegt
     */
    public static void MeasureSequenzOne(int id,bool fullSequenz, double reaction, int click1, int click2)
    {
        z2.AppendFormat(",sequenz{0},{1},{2}ms,{3},{4}\n", id , fullSequenz, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), click1 ,click2 );
    }
    public static void MeasureSequenzTwo(int id, bool fullSequenz, double reaction, int click1, int click2, int click3)
    {
        z2.AppendFormat(",sequenz{0},{1},{2}ms,{3},{4},{5}\n", id, fullSequenz, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3);
    }
    public static void MeasureSequenzThree(int id, bool fullSequenz, double reaction, int click1, int click2, int click3, int click4)
    {
        z2.AppendFormat(",sequenz{0},{1},{2}ms,{3},{4},{5},{6}\n", id, fullSequenz, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3, click4); ;
    }
}
