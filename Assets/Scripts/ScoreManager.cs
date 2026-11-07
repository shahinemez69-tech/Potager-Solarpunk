using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    public int targetScore = 10;

    public static int finalScore;
    public static bool newRecord;

    bool ended = false;
    float elapsed = 0f;

    void Start()
    {
        UpdateText();
    }

    void Update()
    {
        if (!ended)
            elapsed += Time.deltaTime;
    }

    public void AddPoint()
    {
        score = score + 1;
        UpdateText();

        if (score >= targetScore && !ended)
        {
            ended = true;
            SaveScore();
            Invoke("GoToEnd", 1f);
        }
    }

    void SaveScore()
    {
        int timeBonus = Mathf.Max(0, 180 - Mathf.RoundToInt(elapsed)) * 5;
        finalScore = score * 100 + timeBonus;

        int best = PlayerPrefs.GetInt("BestScore", 0);
        newRecord = finalScore > best;
        if (newRecord)
        {
            PlayerPrefs.SetInt("BestScore", finalScore);
            PlayerPrefs.Save();
        }
    }

    void GoToEnd()
    {
        SceneManager.LoadScene("End");
    }

    void UpdateText()
    {
        scoreText.text = "Score : " + score + " / " + targetScore;
    }
}