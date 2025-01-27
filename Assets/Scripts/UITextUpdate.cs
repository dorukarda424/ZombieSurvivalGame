using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UITextUpdate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    protected Text scoreText;
    [SerializeField]
    protected Text levelText;
    [SerializeField]
    protected Image experienceBar;
    public int Score { get; private set; }
    // Update is called once per frame
    public void AddScore(int score)
    {
        Score += score;
        scoreText.text = "Score: " + Score.ToString();
    }
    public void UpdateExperience(float fillAmount, int playerLevel)
    {
        experienceBar.fillAmount=fillAmount;
        levelText.text= playerLevel.ToString();
    }
}
