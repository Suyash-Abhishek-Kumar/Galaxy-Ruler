using System.Net.Sockets;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerHealthUI healthUI;

    public int maxHealth;
    private int currentHealth;

    void Begin()
    {
        healthUI = FindObjectOfType<PlayerHealthUI>();
        Debug.Log(maxHealth + " " + currentHealth + " PlayerHealth.cs");
        healthUI.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Health: {currentHealth}");
        healthUI.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        SceneLoader.Instance.LoadGameOver();
    }


    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log($"Healed +{amount}. Health: {currentHealth}");
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHealth(int newMax)
    {
        maxHealth = newMax;
        currentHealth = newMax;
        Debug.Log(maxHealth + " " + currentHealth + "Just set");
        Begin();
    }
}
