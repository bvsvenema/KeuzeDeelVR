using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    public Transform entryContainerP1;
    private Transform entryTemplateP1;
    public Transform entryContainerP2;
    private Transform entryTemplateP2;
    //private List<HighScoreEntryP1> highScoreEntryListP1;
    //private List<HighScoreEntryP2> highScoreEntryListP2;
    private List<Transform> highscoreEntryTransformListP1;
    private List<Transform> highscoreEntryTransformListP2;

    private void Awake()
    {
        //entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplateP1 = entryContainerP1.Find("highscoreEntryTemplateP1");
        entryTemplateP2 = entryContainerP2.Find("highscoreEntryTemplateP2");

        entryTemplateP1.gameObject.SetActive(false);
        entryTemplateP2.gameObject.SetActive(false);

        //AddHighScoreEntryP1(2, "Schatje");
        //AddHighScoreEntryP2(1, "Benji");

        /*highScoreEntryListP1 = new List<HighScoreEntryP1>()
        {
            new HighScoreEntryP1{scoreP1 = 0, nameP1 = "Player1"},
            new HighScoreEntryP1{scoreP1 = 0, nameP1 = "Player1"},
            new HighScoreEntryP1{scoreP1 = 0, nameP1 = "Player1"},
            new HighScoreEntryP1{scoreP1 = 0, nameP1 = "Player1"},
            new HighScoreEntryP1{scoreP1 = 0, nameP1 = "Player1"},
            new HighScoreEntryP1{scoreP1 = 0, nameP1 = "Player1"},
            new HighScoreEntryP1{scoreP1 = 0, nameP1 = "Player1"},
            new HighScoreEntryP1{scoreP1 = 0, nameP1 = "Player1"},
            new HighScoreEntryP1{scoreP1 = 0, nameP1 = "Player1"},
            new HighScoreEntryP1{scoreP1 = 0, nameP1 = "Player1"}
        };

        highScoreEntryListP2 = new List<HighScoreEntryP2>()
        {
            new HighScoreEntryP2{scoreP2 = 0, nameP2 = "Player2"},
            new HighScoreEntryP2{scoreP2 = 0, nameP2 = "Player2"},
            new HighScoreEntryP2{scoreP2 = 0, nameP2 = "Player2"},
            new HighScoreEntryP2{scoreP2 = 0, nameP2 = "Player2"},
            new HighScoreEntryP2{scoreP2 = 0, nameP2 = "Player2"},
            new HighScoreEntryP2{scoreP2 = 0, nameP2 = "Player2"},
            new HighScoreEntryP2{scoreP2 = 0, nameP2 = "Player2"},
            new HighScoreEntryP2{scoreP2 = 0, nameP2 = "Player2"},
            new HighScoreEntryP2{scoreP2 = 0, nameP2 = "Player2"},
            new HighScoreEntryP2{scoreP2 = 0, nameP2 = "Player2"}
        };*/

        string jsonStringP1 = PlayerPrefs.GetString("HSTMultiP1");
        HighscoreP1 highscoreP1 = JsonUtility.FromJson<HighscoreP1>(jsonStringP1);
        string jsonStringP2 = PlayerPrefs.GetString("HSTMultiP2");
        HighscoreP2 highscoreP2 = JsonUtility.FromJson<HighscoreP2>(jsonStringP2);

        for(int i = 0; i < highscoreP1.highscoreEntryListP1.Count; i++)
        {
            for(int j = i; j < highscoreP1.highscoreEntryListP1.Count; j++)
            {
                if(highscoreP1.highscoreEntryListP1[j].scoreP1 > highscoreP1.highscoreEntryListP1[i].scoreP1)
                {
                    HighScoreEntryP1 tmp = highscoreP1.highscoreEntryListP1[i];
                    highscoreP1.highscoreEntryListP1[i] = highscoreP1.highscoreEntryListP1[j];
                    highscoreP1.highscoreEntryListP1[j] = tmp;
                }
            }
        }

        for (int i = 0; i < highscoreP2.highscoreEntryListP2.Count; i++)
        {
            for(int j = i; j < highscoreP2.highscoreEntryListP2.Count; j++)
            {
                if(highscoreP2.highscoreEntryListP2[j].scoreP2 > highscoreP2.highscoreEntryListP2[i].scoreP2)
                {
                    HighScoreEntryP2 tmp = highscoreP2.highscoreEntryListP2[i];
                    highscoreP2.highscoreEntryListP2[i] = highscoreP2.highscoreEntryListP2[j];
                    highscoreP2.highscoreEntryListP2[j] = tmp;
                }
            }
        }
        /*
        //HST = HighScoreTable
        HighscoreP1 highscoreP1 = new HighscoreP1 { highscoreEntryListP1 = highScoreEntryListP1 };
        string jsonP1 = JsonUtility.ToJson(highscoreP1);
        PlayerPrefs.SetString("HSTMultiP1", jsonP1);
        //PlayerPrefs.Save();

        HighscoreP2 highscoreP2 = new HighscoreP2 { highscoreEntryListP2 = highScoreEntryListP2 };
        string jsonP2 = JsonUtility.ToJson(highscoreP2);
        PlayerPrefs.SetString("HSTMultiP2", jsonP2);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("HSTMultiP2"));
        Debug.Log(PlayerPrefs.GetString("HSTMultiP1"));
        */

        highscoreEntryTransformListP1 = new List<Transform>();
        foreach(HighScoreEntryP1 highScoreEntryP1 in highscoreP1.highscoreEntryListP1)
        {
            CreateHighscoreEntryTransformP1(highScoreEntryP1, entryContainerP1, highscoreEntryTransformListP1);
        }

        highscoreEntryTransformListP2 = new List<Transform>();
        foreach(HighScoreEntryP2 highScoreEntryP2 in highscoreP2.highscoreEntryListP2)
        {
            CreateHighscoreEntryTransformP2(highScoreEntryP2, entryContainerP2, highscoreEntryTransformListP2);
        }


    }

    private void CreateHighscoreEntryTransformP1(HighScoreEntryP1 highScoreEntryP1, Transform containerP1, List<Transform> transFormListP1)
    {
        float templateHeight = 25f;

        //p1
        Transform entryTransformP1 = Instantiate(entryTemplateP1, entryContainerP1);
        RectTransform entryRectTransformP1 = entryTransformP1.GetComponent<RectTransform>();
        entryRectTransformP1.anchoredPosition = new Vector2(0, -templateHeight * transFormListP1.Count);
        entryTransformP1.gameObject.SetActive(true);


        int rank = transFormListP1.Count + 1;
        string rankString;

        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransformP1.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int scoreP1 = highScoreEntryP1.scoreP1;
        entryTransformP1.Find("scoreText").GetComponent<TextMeshProUGUI>().text = scoreP1.ToString();

        string nameP1 = highScoreEntryP1.nameP1;
        entryTransformP1.Find("nameText").GetComponent<TextMeshProUGUI>().text = nameP1;

        transFormListP1.Add(entryTransformP1);
    }

    private void CreateHighscoreEntryTransformP2(HighScoreEntryP2 highScoreEntryP2, Transform containerP2, List<Transform> transFormListP2)
    {
        float templateHeight = 25f;

        //p2
        Transform entryTransformP2 = Instantiate(entryTemplateP2, entryContainerP2);
        RectTransform entryRectTransformp2 = entryTransformP2.GetComponent<RectTransform>();
        entryRectTransformp2.anchoredPosition = new Vector2(0, -templateHeight * transFormListP2.Count);
        entryTransformP2.gameObject.SetActive(true);

        int rank = transFormListP2.Count + 1;
        string rankString;

        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransformP2.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int scoreP2 = highScoreEntryP2.scoreP2;
        entryTransformP2.Find("scoreText").GetComponent<TextMeshProUGUI>().text = scoreP2.ToString();

        string nameP2 = highScoreEntryP2.nameP2;
        entryTransformP2.Find("nameText").GetComponent<TextMeshProUGUI>().text = nameP2;

        transFormListP2.Add(entryTransformP2);

    }

    private void AddHighScoreEntryP1(int scoreP1, string nameP1)
    {
        HighScoreEntryP1 highScoreEntryP1 = new HighScoreEntryP1 { scoreP1 = scoreP1, nameP1 = nameP1 };

        string jsonStringP1 = PlayerPrefs.GetString("HSTMultiP1");
        HighscoreP1 highscoreP1 = JsonUtility.FromJson<HighscoreP1>(jsonStringP1);

        highscoreP1.highscoreEntryListP1.Add(highScoreEntryP1);

        string jsonP1 = JsonUtility.ToJson(highscoreP1);
        PlayerPrefs.SetString("HSTMultiP1", jsonP1);
        PlayerPrefs.Save();
    }

    private void AddHighScoreEntryP2(int scoreP2, string nameP2)
    {
        HighScoreEntryP2 highScoreEntryP2 = new HighScoreEntryP2 { scoreP2 = scoreP2, nameP2 = nameP2 };

        string jsonStringP2 = PlayerPrefs.GetString("HSTMultiP2");
        HighscoreP2 highscoreP2 = JsonUtility.FromJson<HighscoreP2>(jsonStringP2);

        highscoreP2.highscoreEntryListP2.Add(highScoreEntryP2);

        string jsonP2 = JsonUtility.ToJson(highscoreP2);
        PlayerPrefs.SetString("HSTMultiP2", jsonP2);
        PlayerPrefs.Save();
    }
    
    private class HighscoreP1
    {
        public List<HighScoreEntryP1> highscoreEntryListP1;
    }
    
    private class HighscoreP2
    {
        public List<HighScoreEntryP2> highscoreEntryListP2;
    }

    [System.Serializable]
    private class HighScoreEntryP1
    {
        public int scoreP1;
        public string nameP1;
    }

    [System.Serializable]
    private class HighScoreEntryP2
    {
        public int scoreP2;
        public string nameP2;
    }
}
