using UnityEngine;

public class HeroController : MonoBehaviour
{
    public HeroStats stats;

    private PlayerHealth health;
    private PlayerShooting shooter;
    private PlayerController movement;

    void Start()
    {
        health = GetComponent<PlayerHealth>();
        shooter = GetComponent<PlayerShooting>();
        movement = GetComponent<PlayerController>();

        health.SetMaxHealth(stats.health);
        shooter.SetDamage(stats.bulletDamage, stats.missileCount);
        movement.SetMovement(stats.moveSpeed, stats.rotationSpeed);
    }
}
