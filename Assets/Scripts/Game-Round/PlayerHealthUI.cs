using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image fillImage;       // Drag your 'Fill' image here
    public Image backgroundImage; // Optional: Drag the 'Background' image here
    public Text healthText;

    private int maxHealth;
    private int currentHealth;
    private int truecurhealth;

    public void SetMaxHealth(int max)
    {
        maxHealth = max;
        currentHealth = max;
        truecurhealth = max;
        UpdateBar();
    }

    public void SetHealth(int health)
    {
        truecurhealth = health;
        currentHealth = Mathf.Clamp(health, 0, maxHealth);
        UpdateBar();
    }

    private void UpdateBar()
    {
        if (fillImage != null)
        {
            float fillAmount = (float)currentHealth / maxHealth;
            fillImage.rectTransform.localScale = new Vector3(fillAmount, 1f, 1f);
        }
        if (healthText != null)
        {
            healthText.text = $"Health: {truecurhealth} / {maxHealth}";
        }
    }
}
