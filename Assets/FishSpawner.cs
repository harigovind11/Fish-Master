using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] Fish fishPrefab;
    [SerializeField] Fish.FishType[] fishTypes;

    private void Awake()
    {
        for (int i = 0; i < fishTypes.Length; i++)
        {
            int num = 0;
            while (num < fishTypes[i].fishCount)
            {
                Fish fish = UnityEngine.Object.Instantiate(fishPrefab);
                fish.Type = fishTypes[i];
                fish.ResetFish();
                num++;
            }
        }
    }
}
