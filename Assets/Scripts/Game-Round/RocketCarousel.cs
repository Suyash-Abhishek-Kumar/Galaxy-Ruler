using UnityEngine;
using UnityEngine.UI;

public class RocketCarousel : MonoBehaviour
{
    [System.Serializable]
    public class HeroDisplay
    {
        public string heroName;
        public HeroStats stats;
        public Sprite previewSprite;
    }

    public HeroDisplay[] heroCards;

    [Header("UI References")]
    public Image previewImage;
    public Text nameText;
    public Text statsText;

    private int currentIndex = 0;

    void Start()
    {
        ShowHero(currentIndex);
    }

    public void Next()
    {
        currentIndex = (currentIndex + 1) % heroCards.Length;
        ShowHero(currentIndex);
    }

    public void Previous()
    {
        currentIndex = (currentIndex - 1 + heroCards.Length) % heroCards.Length;
        ShowHero(currentIndex);
    }

    void ShowHero(int index)
    {
        var hero = heroCards[index];

        if (previewImage) previewImage.sprite = hero.previewSprite;
        if (nameText) nameText.text = hero.heroName;
        if (statsText)
        {
            statsText.text =
                $"Health: {hero.stats.health}\n" +
                $"Bullet Damage: {hero.stats.bulletDamage}\n" +
                $"Missiles: {hero.stats.missileCount}\n";
        }
    }

    public void ConfirmSelection()
    {
        RocketSelector.Instance.SelectRocket(currentIndex);
        SceneLoader.Instance.LoadGameplay(); // Or go to loading screen
    }
}
