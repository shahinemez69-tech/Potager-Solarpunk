using UnityEngine;
using TMPro;

public class BestScoreDisplay : MonoBehaviour
{
    public TMP_Text bestScoreText;

    void Start()
    {
        bestScoreText.text = "Meilleur score : " + PlayerPrefs.GetInt("BestScore", 0);
    }
}