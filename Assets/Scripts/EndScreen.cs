using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TMP_Text finalScoreText;
    public TMP_Text bestScoreText;

    void Start()
    {
        finalScoreText.text = "Score final : " + ScoreManager.finalScore;

        int best = PlayerPrefs.GetInt("BestScore", 0);
        if (ScoreManager.newRecord)
            bestScoreText.text = "Nouveau record : " + best + " !";
        else
            bestScoreText.text = "Meilleur score : " + best;
    }
}