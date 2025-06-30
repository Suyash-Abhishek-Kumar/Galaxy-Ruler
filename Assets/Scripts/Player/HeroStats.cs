using UnityEngine;

[CreateAssetMenu(fileName = "HeroStats", menuName = "ScriptableObjects/HeroStats", order = 1)]
public class HeroStats : ScriptableObject
{
    public string heroName;
    public int health;
    public int bulletDamage;
    public int missileCount;
    public float moveSpeed;
    public float rotationSpeed;
    public Sprite previewImage;
}
