using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Player : MonoBehaviour
{
    public List<GameObject> clickedBlocks = new List<GameObject>();
    public List<GameObject> sequenzBlocks = new List<GameObject>();
    public GameObject circle;

    public int rightTaskCounter;
    public int falseTaskCounter;
    public int accuracyCounter;
    public int totalClicksCounter;
    public static int currentSequenzCounter;

    public static Stopwatch timer = new Stopwatch();

    bool listCompareVar;
    private Randomizer randomizer;

    

    //public DataSaver datasaver;
    void Start()
    {
        DataSaver.totalTime = 0.0d;
        currentSequenzCounter = 0;
        falseTaskCounter = 0;
        rightTaskCounter = 0;
        totalClicksCounter = 0;
        accuracyCounter = 0;
        clickedBlocks.Clear();
    }

    private void Update()
    {
        if(clickedBlocks.Count > sequenzBlocks.Count)
        {
            clickedBlocks.RemoveAt(clickedBlocks.Count - 1);
            totalClicksCounter--;
            //randomizer.disabeleField();
        }
    }


    public void CleanLists()
    {
        CompareLists();
        clickedBlocks.Clear();
        sequenzBlocks.Clear();
    }

    public void increaseClick()
    {
        totalClicksCounter++;
    }


    //public bool CompareLists()
    //{
    //    int x = clickedBlocks.Count;
    //    int y = sequenzBlocks.Count;
    //    if (x != y)
    //    {
    //        circle.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
    //        falseTaskCounter++;
    //        return false;
    //    }
    //    for (int i = 0; i<x; i++)
    //    {
    //        if(clickedBlocks[i] != sequenzBlocks[i])
    //        {
    //            circle.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
    //            falseTaskCounter++;
    //           return false;
    //        }
    //    }
    //    circle.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
    //    rightTaskCounter++;
    //    return true;
    //}

    public bool CompareLists()
    {
        
        timer.Stop();
        DataSaver.totalTime += timer.Elapsed.TotalMilliseconds;
        currentSequenzCounter++;
        int x = clickedBlocks.Count;
        int y = sequenzBlocks.Count;

        //int click1 = 0, click2 = 0, click3 = 0, click4 = 0 ;
        int[] clicks = {-1,-1,-1,-1};
        listCompareVar = true;

        if (x != y)
        {
            circle.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            listCompareVar = false;
        }
        if(x > y)
        {
            x = x - (x - y);
        }
        for (int i = 0; i < x; i++)
        {
            if (clickedBlocks[i] == sequenzBlocks[i])
            {
                clicks[i] = 1;
                accuracyCounter++;                
            }
            

            if (clickedBlocks[i] != sequenzBlocks[i])
            {
                clicks[i] = 0;
                listCompareVar = false;
            }
        }

        if (listCompareVar)
        {
            rightTaskCounter++;
            circle.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
            WriteInDatasaver(currentSequenzCounter, clicks[0], clicks[1], clicks[2], clicks[3], y);
            timer.Reset();
            return listCompareVar;
        }

        falseTaskCounter++;
        circle.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);

        WriteInDatasaver(currentSequenzCounter, clicks[0], clicks[1], clicks[2], clicks[3], y);
        timer.Reset();
        return listCompareVar;
    }


    private void WriteInDatasaver(int count, int click1, int click2, int click3, int click4, int sequenzLength)
    {

        //Debug.Log("open");
        if (sequenzLength == 2) DataSaver.MeasureSequenzOne(count, listCompareVar, timer.Elapsed.TotalMilliseconds,click1,click2);
        if (sequenzLength == 3) DataSaver.MeasureSequenzTwo(count, listCompareVar,timer.Elapsed.TotalMilliseconds, click1,click2,click3);
        if (sequenzLength == 4) DataSaver.MeasureSequenzThree(count, listCompareVar, timer.Elapsed.TotalMilliseconds, click1, click2, click3,click4); ;
    }
}
