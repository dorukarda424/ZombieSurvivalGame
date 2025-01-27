using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    GameObject levelUpPanel;
    protected int playerLevel=0;
    protected float playerExperience=0f;
    protected float maxExperience;
    protected UITextUpdate scoreText;
    void Start()
    {
        scoreText = Object.FindAnyObjectByType<UITextUpdate>();
        maxExperience = ConfigurationData.MaxExperience;
    }
    public void AddExperience(int experience)
    {
        playerExperience += experience;
        if (playerExperience >= maxExperience) {
            playerExperience-=maxExperience;
            playerLevel += 1;
            ConfigurationData.BulletDamage += ConfigurationData.BulletDamageIncreaseAfterLevel;
            //levelUpPanel.SetActive(true);
            //Time.timeScale = 0;
        }
        float fillAmount=playerExperience/maxExperience;

        scoreText.UpdateExperience(fillAmount, playerLevel);
        

    }
}
