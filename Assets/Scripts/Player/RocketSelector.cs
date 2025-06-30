using UnityEngine;

public class RocketSelector : MonoBehaviour
{
    public static RocketSelector Instance;

    [Header("Assign 4 Rocket Variants Here")]
    public GameObject[] heroPrefabs;

    private GameObject selectedHero;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectRocket(int index)
    {
        selectedHero = heroPrefabs[index];
    }

    public GameObject GetSelectedRocket()
    {
        return selectedHero;
    }
}
