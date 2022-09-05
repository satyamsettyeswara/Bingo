using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

    public int whoTurn;//0=1 and 1=2
    public int turncount;
    public GameObject[] turnIcons;
    public Sprite[] playerIcons;
    public Sprite[] playerMark;
    public Button[] bingospaces;
    public Button[] markSpaces;
    public int[] markedSpaces;
    public Image grid1;
    public Image grid2;
    public Text winnerText;
    public GameObject[] winningLine;
    public Button start;
    public Button quit;
    int i = 0;
    string b = "BINGO";
	// Use this for initialization
	void Start () {
        GameSetup();
	}
	void GameSetup()
    {
        grid2.gameObject.SetActive(false);
        whoTurn = 0;
        turncount = 0;
        for(int i=0;i<bingospaces.Length;i++)
        {
            bingospaces[i].interactable = true;
            bingospaces[i].GetComponent<Image>().sprite = null;
        }
        
        for (int i=0;i<markedSpaces.Length;i++)
        {
            markedSpaces[i] = -10; 
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void Startgame()
    {
        grid2.gameObject.SetActive(true);
        Debug.Log("Started");
        for (int i = 0; i < markSpaces.Length; i++)
        {
            markSpaces[i].interactable = true;
            markSpaces[i].GetComponent<Image>().sprite = null;
        }
        start.gameObject.SetActive(false);
        quit.gameObject.SetActive(true);
    }
    public void doQuit()
    {        
        Application.Quit();
    }
    public void BingoButton(int fillbox)
    {
        whoTurn = i;
        bingospaces[fillbox].image.sprite = playerIcons[whoTurn];
        bingospaces[fillbox].interactable = false;         
        i++;
        
    }
    /*
    public void BingoButton(int fillbox)
    {
        whoTurn = i;
        bingospaces[fillbox].image.sprite = playerIcons[whoTurn];        
        bingospaces[fillbox].interactable= false;
        
        markedSpaces[fillbox] = 1;
        if(turncount >=4)
        {
            WinnerCheck();
        }
        turncount++;
        
        i++;
    }
    */
    public void MarkNumber(int fillbox)
    {
        markSpaces[fillbox].image.sprite = playerMark[0];
        markSpaces[fillbox].interactable = false;
        markedSpaces[fillbox] = 1;
        if (turncount >= 4)
        {
            WinnerCheck();
        }
        turncount++;
    }

    void WinnerCheck()
    {
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2] + markedSpaces[3] + markedSpaces[4];
        int s2 = markedSpaces[5] + markedSpaces[6] + markedSpaces[7] + markedSpaces[8] + markedSpaces[9];
        int s3 = markedSpaces[10] + markedSpaces[11] + markedSpaces[12] + markedSpaces[13] + markedSpaces[14];
        int s4 = markedSpaces[15] + markedSpaces[16] + markedSpaces[17] + markedSpaces[18] + markedSpaces[19];
        int s5 = markedSpaces[20] + markedSpaces[21] + markedSpaces[22] + markedSpaces[23] + markedSpaces[24];
        int s6 = markedSpaces[4] + markedSpaces[9] + markedSpaces[14] + markedSpaces[19] + markedSpaces[24]; 
        int s7 = markedSpaces[3] + markedSpaces[8] + markedSpaces[13] + markedSpaces[18] + markedSpaces[23]; 
        int s8 = markedSpaces[2] + markedSpaces[7] + markedSpaces[12] + markedSpaces[17] + markedSpaces[22];
        int s9 = markedSpaces[1] + markedSpaces[6] + markedSpaces[11] + markedSpaces[16] + markedSpaces[21];
        int s10 = markedSpaces[0] + markedSpaces[5] + markedSpaces[10] + markedSpaces[15] + markedSpaces[20];
        int s11 = markedSpaces[0] + markedSpaces[6] + markedSpaces[12] + markedSpaces[18] + markedSpaces[24];
        int s12 = markedSpaces[4] + markedSpaces[8] + markedSpaces[12] + markedSpaces[16] + markedSpaces[20];
        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12 };
        int j = 0;
        
        for (int i = 0; i < solutions.Length; i++)
        {            
            if(solutions[i]==5)
            {
                j += solutions[i];               
                LineDisplay(i);
                Debug.Log(i);
            }
                                                                
        }
        //single match
        if (j == 5 && b[0] == 'B')
        {
            b = b.Substring(1, b.Length - 1);
            Debug.Log(b);
            WinnerDisplay("B",j);
        }
        else if (j == 10 && b[0] == 'I')
        {
            b = b.Substring(1, b.Length - 1);
            Debug.Log(b);
            WinnerDisplay("I",j);
        }
        else if (j == 15 && b[0] == 'N')
        {
            b = b.Substring(1, b.Length - 1);
            Debug.Log(b);
            WinnerDisplay("N",j);
        }
        else if (j == 20 && b[0] == 'G')
        {
            b = b.Substring(1, b.Length - 1);
            Debug.Log(b);
            WinnerDisplay("G",j);
        }
        else if (j == 25 && b[0] == 'O')
        {
            b = b.Substring(1, b.Length - 1);
            Debug.Log(b);
            WinnerDisplay("O",j);
        }
        //double match
        else if (j == 10 && b[0] == 'B' && b[1] == 'I')
        {
            if (b.Length >= 2)
            {
                b = b.Substring(2, b.Length - 2);
                Debug.Log(b);
                WinnerDisplay("B\nI",j);
            }
        }
        else if (j == 15 && b[0] == 'I' && b[1] == 'N')
        {
            if (b.Length >= 2)
            {
                b = b.Substring(2, b.Length - 2);
                Debug.Log(b);
                WinnerDisplay("I\nN",j);
            }
        }
        else if (j == 20 && b[0] == 'N' && b[1] == 'G')
        {
            if (b.Length >= 2)
            {
                b = b.Substring(2, b.Length - 2);
                Debug.Log(b);
                WinnerDisplay("N\nG",j);
            }
        }
        else if (j == 25 && b[0] == 'G' && b[1] == 'O')
        {
            if (b.Length >= 2)
            {
                b = b.Substring(2, b.Length - 2);
                Debug.Log(b);
                WinnerDisplay("G\nO",j);
            }
        }
        //triple  match
        else if (j == 15 && b[0] == 'B' && b[1] == 'I' && b[2] == 'N')
        {
            if (b.Length >= 3)
            {
                b = b.Substring(3, b.Length - 3);
                Debug.Log(b);
                WinnerDisplay("B\nI\nN",j);
            }
        }
        else if (j == 20 && b[0] == 'I' && b[1] == 'N' && b[2] == 'G')
        {
            if (b.Length >= 3)
            {
                b = b.Substring(3, b.Length - 3);
                Debug.Log(b);
                WinnerDisplay("I\nN\nG",j);
            }
        }
        else if (j == 25 && b[0] == 'N' && b[1] == 'G' && b[2] == 'O')
        {
            if (b.Length >= 3)
            {
                b = b.Substring(3, b.Length - 3);
                Debug.Log(b);
                WinnerDisplay("N\nG\nO",j);
            }
        }
        //squad match
        else if (j == 20 && b[0] == 'B' && b[1] == 'I' && b[2] == 'N' && b[3] == 'G')
        {
            if (b.Length >= 4)
            {
                b = b.Substring(4, b.Length - 4);
                Debug.Log(b);
                WinnerDisplay("B\nI\nN\nG",j);
            }
        }
        else if (j == 25 && b[0] == 'I' && b[1] == 'N' && b[2] == 'G' && b[3] == 'O')
        {
            if (b.Length >= 4)
            {
                b = b.Substring(4, b.Length - 4);
                Debug.Log(b);
                WinnerDisplay("I\nN\nG\nO",j);
            }
        }
        //end prb with 2match at a time
        else if (j == 30 && b[0] == 'O')
        {
            b = b.Substring(1, b.Length - 1);
            Debug.Log(b);
            WinnerDisplay("O",j);
        }
        //end prb with 3match at atime
        else if(j == 30 && b[0]=='G' && b[1]=='O')
        {
            b = b.Substring(2, b.Length - 2);
            Debug.Log(b);
            WinnerDisplay("G\nO",j);
        }
        else if (j == 35 && b[0] == 'O')
        {
            b = b.Substring(1, b.Length - 1);
            Debug.Log(b);
            WinnerDisplay("O",j);
        }
        //rnd prob with 4 at time but solution end up near 3at a time prob            
        else
            // Debug.Log(j);

        return;
    }
    void WinnerDisplay(string o,int stop)
    {        
               
        winnerText.text += o+"\n";
        Debug.Log(winnerText.ToString());
        if(stop >=25)
        {
            for(int i=0;i<25;i++)
            {
                markSpaces[i].interactable = false;
            }
            
        }
    }
    void LineDisplay(int indexin)
    {
        winnerText.gameObject.SetActive(true);
        winningLine[indexin].SetActive(true);
        
    }
    
}
