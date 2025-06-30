using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        GameObject rocket = RocketSelector.Instance.GetSelectedRocket();

        if (rocket != null)
        {
            Instantiate(rocket, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("No rocket selected! Loading default.");
            // Optional fallback
        }
    }
}
