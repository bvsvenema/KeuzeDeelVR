using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreTableSingle : MonoBehaviour
{
    public ScoreManager SM;

    public Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        AddHighScoreEntry(SM.PlayerScore1, SM.playerSkeeOutput1.text);
        Debug.Log(SM.PlayerScore1);
        Debug.Log(SM.playerSkeeOutput1.text);

        string jsonString = PlayerPrefs.GetString("HSTSingle");
        Highscore highscore = JsonUtility.FromJson<Highscore>(jsonString);

        if (highscore == null)
        {
            AddHighScoreEntry(SM.PlayerScore1, SM.playerSkeeOutput1.text);

            jsonString = PlayerPrefs.GetString("HSTSingle");
            highscore = JsonUtility.FromJson<Highscore>(jsonString);
        }

        for (int i = 0; i < highscore.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscore.highscoreEntryList.Count; j++)
            {
                if (highscore.highscoreEntryList[j].score > highscore.highscoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscore.highscoreEntryList[i];
                    highscore.highscoreEntryList[i] = highscore.highscoreEntryList[j];
                    highscore.highscoreEntryList[j] = tmp;
                }
            }
        }

        if (highscore.highscoreEntryList.Count > 10)
        {
            for (int h = highscore.highscoreEntryList.Count; h > 10; h--)
            {
                highscore.highscoreEntryList.RemoveAt(10);
            }
        }

        Debug.Log(PlayerPrefs.GetString("HSTSingle"));


        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highscore.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highScoreEntry, entryContainer, highscoreEntryTransformList);

        }
    }

    private void CreateHighscoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transFormList)
    {
        float templateHeight = 25f;

        //p1
        Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transFormList.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = transFormList.Count + 1;
        string rankString;

        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highScoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        transFormList.Add(entryTransform);
    }

    private void AddHighScoreEntry(int score, string name)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("HSTSingle");
        Highscore highscore = JsonUtility.FromJson<Highscore>(jsonString);

        if (highscore == null)
        {
            // There's no stored table, initialize
            highscore = new Highscore()
            {
                highscoreEntryList = new List<HighScoreEntry>()
            };
        }

        highscore.highscoreEntryList.Add(highScoreEntry);

        //use this to reset scoreboard
        //if (highscore.highscoreEntryList.Count > 10)
        //{
        //    for (int h = highscore.highscoreEntryList.Count; h > 10; h--)
        //    {
        //        highscore.highscoreEntryList.RemoveAt(10);
        //    }
        //}

        string json = JsonUtility.ToJson(highscore);
        PlayerPrefs.SetString("HSTSingle", json);
        PlayerPrefs.Save();
    }

 

    private class Highscore
    {
        public List<HighScoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
