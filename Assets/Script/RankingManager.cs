using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;
public class RankingManager : MonoBehaviour
{
    public TMP_Text[] rankTexts;
    public Color normalColor = Color.white;
    public Color currentColor = Color.yellow;

    static string path => Application.dataPath + "/../ranking.txt";
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   public static void SaveScore(int score)
    {
        List<int> scores = LoadScores();
        scores.Add(score);
        scores.Sort((a, b) => b.CompareTo(a));

        if (scores.Count > 6)
            scores.RemoveRange(6, scores.Count - 6);

        File.WriteAllLines(path,scores.ConvertAll(x => x.ToString()));
    }
    static List<int> LoadScores()
    {
        List<int> scores = new List<int>();

        if (!File.Exists(path))
            return scores;

        foreach (string line in File.ReadAllLines(path))
        {
            if (int.TryParse(line, out int score))
                scores.Add(score);
        }

        return scores;
    }

    private void Start()
    {
        List<int> scores = LoadScores();
        bool currentMarked = false;

        for (int i = 0; i < rankTexts.Length; i++)
        {
            if (i < scores.Count)
            {
                // SHOW
                rankTexts[i].text = (i + 1) + ") " + scores[i].ToString("###,###,###,###,##0");

                if (!currentMarked &&
                    scores[i] == PlayerManager.ScoreToGo)
                {
                    rankTexts[i].color = currentColor;
                    currentMarked = true;
                }
                else
                {
                    rankTexts[i].color = normalColor;
                }
            }
            else
            {
                rankTexts[i].text = " ";
                rankTexts[i].color = normalColor;
            }
        }
        //gameObject.SetActive(true);
    }
}
