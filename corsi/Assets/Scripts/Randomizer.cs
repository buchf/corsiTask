using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Randomizer : MonoBehaviour
{

    [SerializeField] List<Transform> blocks = new List<Transform>();
    public GameObject fairy;
    public int randomBlock;
    private Player player;
    float speed = 1f;
    private List<int> randomNumbers = new List<int>();
    int count1, count2 = 0;
    

    [SerializeField] Button button;
    
    private void Start()
    {
        player = FindObjectOfType<Player>();
        fairy.transform.position = new Vector3(-7f, 3f, -1);
        StartCoroutine(SequenzOne(5,1));
        count1++;
    }
  
    public void StartSequenz()
    {
        Debug.Log(DataSaver.filePath.ToString());
        fairy.SetActive(true);
        fairy.transform.position = new Vector3(-7f, 3f, -1);
        randomNumbers.Clear();
        
        if (count1 == 3 && count2 != 0)
        {
            count1 = 0;
            count2++;
        } 

        // 3 7 richtig
        if(count1 == 3 && count2 == 0)
        {
            //Finish the whole Sequenz so the OutroScene is loaded
            Debug.Log("FINISH");
            DataSaver.falseTask = player.falseTaskCounter.ToString();
            DataSaver.rightTask = player.rightTaskCounter.ToString();
            DataSaver.totalClicks = player.totalClicksCounter.ToString();
            DataSaver.accuracy = player.accuracyCounter.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        

        //Zahlen fuer die verschiedenen Trials wurden mithilfe der GetRandom Funktion erstellt
        //Trial 1 
        if (count1 == 0 && count2 == 0) StartCoroutine(SequenzOne(5,1));  
        if (count1 == 1 && count2 == 0) StartCoroutine(SequenzTwo(1,5,9));
        if (count1 == 2 && count2 == 0) StartCoroutine(SequenzThree(8,4,9,6));

        //Trial 2
        if (count1 == 0 && count2 == 1) StartCoroutine(SequenzOne(8,1));
        if (count1 == 1 && count2 == 1) StartCoroutine(SequenzTwo(1,4,9));
        if (count1 == 2 && count2 == 1) StartCoroutine(SequenzThree(5,6,9,2));

        //Trial 3
        if (count1 == 0 && count2 == 2) StartCoroutine(SequenzOne(5,3));
        if (count1 == 1 && count2 == 2) StartCoroutine(SequenzTwo(2,8,6));
        if (count1 == 2 && count2 == 2) StartCoroutine(SequenzThree(1,9,3,6));

        //Trial 4
        if (count1 == 0 && count2 == 3) StartCoroutine(SequenzOne(9,8));
        if (count1 == 1 && count2 == 3) StartCoroutine(SequenzTwo(5,2,9));
        if (count1 == 2 && count2 == 3) StartCoroutine(SequenzThree(9,1,7,6));

        //Trial 5
        if (count1 == 0 && count2 == 4) StartCoroutine(SequenzOne(7,2));
        if (count1 == 1 && count2 == 4) StartCoroutine(SequenzTwo(7,8,2));
        if (count1 == 2 && count2 == 4) StartCoroutine(SequenzThree(1,2,7,5));

        //Trial 6
        if (count1 == 0 && count2 == 5) StartCoroutine(SequenzOne(7,8));
        if (count1 == 1 && count2 == 5) StartCoroutine(SequenzTwo(5,2,8));
        if (count1 == 2 && count2 == 5) StartCoroutine(SequenzThree(1,9,3,8));

        //Trial 7
        if (count1 == 0 && count2 == 6) StartCoroutine(SequenzOne(7,6));
        if (count1 == 1 && count2 == 6) StartCoroutine(SequenzTwo(9,4,3));
        if (count1 == 2 && count2 == 6) StartCoroutine(SequenzThree(9,7,3,8));

        //Trial 8
        if (count1 == 0 && count2 == 7) StartCoroutine(SequenzOne(7,9));
        if (count1 == 1 && count2 == 7) StartCoroutine(SequenzTwo(9,2,7));
        if (count1 == 2 && count2 == 7) StartCoroutine(SequenzThree(9,2,6,8));

        count1++;

    }

    /*
    void GetRandomBlock()
    {

        randomBlock = Random.Range(1, 10);

        if (CheckRandomNumber(randomBlock))
        {
            SpawnFairyInBlock();
        }
        else
        {
            GetRandomBlock();
        }
        randomNumbers.Add(randomBlock);
    }

    void SpawnFairyInBlock()
    {
        switch (randomBlock)
        {
            case 1:
                fairy.transform.position = new Vector3(blocks[0].transform.position.x, blocks[0].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[0].transform.gameObject);
                break;
            case 2:
                fairy.transform.position = new Vector3(blocks[1].transform.position.x, blocks[1].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[1].transform.gameObject);
                break;
            case 3:
                fairy.transform.position = new Vector3(blocks[2].transform.position.x, blocks[2].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[2].transform.gameObject);
                break;
            case 4:
                fairy.transform.position = new Vector3(blocks[3].transform.position.x, blocks[3].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[3].transform.gameObject);
                break;
            case 5:
                fairy.transform.position = new Vector3(blocks[4].transform.position.x, blocks[4].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[4].transform.gameObject);
                break;
            case 6:
                fairy.transform.position = new Vector3(blocks[5].transform.position.x, blocks[5].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[5].transform.gameObject);
                break;
            case 7:
                fairy.transform.position = new Vector3(blocks[6].transform.position.x, blocks[6].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[6].transform.gameObject);
                break;
            case 8:
                fairy.transform.position = new Vector3(blocks[7].transform.position.x, blocks[7].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[7].transform.gameObject);
                break;
            case 9:
                fairy.transform.position = new Vector3(blocks[8].transform.position.x, blocks[8].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[8].transform.gameObject);
                break;
        }
    }

    bool CheckRandomNumber(int i)
    {
        foreach (int x in randomNumbers)
        {
            if (x == i)
            {
                return false;
            }
        }
        return true;
    }
    */
    
    void SpawnFairyInBlock(int blockNumber)
    {
        switch (blockNumber)
        {
            case 1:
                fairy.transform.position = new Vector3(blocks[0].transform.position.x, blocks[0].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[0].transform.gameObject);
                break;
            case 2:
                fairy.transform.position = new Vector3(blocks[1].transform.position.x, blocks[1].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[1].transform.gameObject);
                break;
            case 3:
                fairy.transform.position = new Vector3(blocks[2].transform.position.x, blocks[2].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[2].transform.gameObject);
                break;
            case 4:
                fairy.transform.position = new Vector3(blocks[3].transform.position.x, blocks[3].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[3].transform.gameObject);
                break;
            case 5:
                fairy.transform.position = new Vector3(blocks[4].transform.position.x, blocks[4].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[4].transform.gameObject);
                break;
            case 6:
                fairy.transform.position = new Vector3(blocks[5].transform.position.x, blocks[5].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[5].transform.gameObject);
                break;
            case 7:
                fairy.transform.position = new Vector3(blocks[6].transform.position.x, blocks[6].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[6].transform.gameObject);
                break;
            case 8:
                fairy.transform.position = new Vector3(blocks[7].transform.position.x, blocks[7].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[7].transform.gameObject);
                break;
            case 9:
                fairy.transform.position = new Vector3(blocks[8].transform.position.x, blocks[8].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[8].transform.gameObject);
                break;
        }
    }

    //Trial 1
    IEnumerator SequenzOne(int a, int b)
    {
        disabeleField();
        
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(a);
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(b);
        yield return new WaitForSeconds(speed);
        fairy.SetActive(false);
        enableField();
        Player.timer.Start();
    }

    IEnumerator SequenzTwo(int a, int b, int c)
    {
        disabeleField();
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(a);
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(b);
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(c);
        yield return new WaitForSeconds(speed);
        fairy.SetActive(false);
        Player.timer.Start();
        enableField();
    }

    IEnumerator SequenzThree(int a, int b, int c , int d)
    {
        disabeleField();
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(a);
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(b);
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(c);
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(d);
        yield return new WaitForSeconds(speed);
        fairy.SetActive(false);
        enableField();
        Player.timer.Start();
    }

    void enableField()
    {
        for(int i = 0; i< blocks.Count;i++)
        {
            blocks[i].GetComponent<Collider2D>().enabled = true;
        }
        button.interactable = true;
        
    }
    public void disabeleField()
    {
        
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<Collider2D>().enabled = false;
        }
        button.interactable = false;
    }
}

