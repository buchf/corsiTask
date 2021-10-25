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
    int amountOfFullCorsiTaskClicks =  9;

    public static string filePath = Path.Combine(Application.persistentDataPath, "corsi.csv");

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



        //  File.WriteAllText(filePath, "Corsi");

        z1.Append("Corsi\n" + ",Sequenzes correct:," + rightTask + " of " + Player.currentSequenzCounter + "\n");
        z1.Append(",Clicks Accuracy:," + accuracyPercentage.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "%\n" + ",total Time: ," + totalTime.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +"ms\n");
        z1.Append("\n,Trial no., Full Sequenz correct,Reaction Time,First click,Second click,Third click,Fourth click\n");
        results.Add(z1);
        results.Add(z2);
        File.WriteAllText(filePath, listToString(results));

    }

    private string listToString(List<StringBuilder> results)
    {
        string x = "";
        foreach (var element in results)
        {
            x = x + element.ToString();
        }
        
        return x;
    }


    //measuere writing functions and adding to the List results
    public static void MeasureSequenzOne(int id,bool fullSequenz, double reaction, int click1, int click2)
    {
        z2.AppendFormat(",sequenz{0},{1},{2}ms,{3},{4}\n", id , fullSequenz, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), click1 ,click2 );
        //results.Add(z2);
    }
    public static void MeasureSequenzTwo(int id, bool fullSequenz, double reaction, int click1, int click2, int click3)
    {
        z2.AppendFormat(",sequenz{0},{1},{2}ms,{3},{4},{5}\n", id, fullSequenz, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3);
        //results.Add(z2);
    }
    public static void MeasureSequenzThree(int id, bool fullSequenz, double reaction, int click1, int click2, int click3, int click4)
    {
        z2.AppendFormat(",sequenz{0},{1},{2}ms,{3},{4},{5},{6}\n", id, fullSequenz, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3, click4); ;
        //results.Add(z2);
    }
}
