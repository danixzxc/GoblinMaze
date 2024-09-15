using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ItemSpawner : MonoBehaviour
{
    public GameObject item;
    [InspectorName("Possible Spawn Positions")]
    public List<Transform> positions = new List<Transform>();
    [InspectorName("Amount of Item to spawn")]
    public int spawnAmount = 0;

    private void Start()
    {
        Assert.IsNotNull(item);
        Assert.IsTrue(spawnAmount <= positions.Count);
        
        Shuffle(positions);
        for(int i = 0; i < spawnAmount; i++)
        {
            GameObject instance = Instantiate(item, positions[i]);
        }
    }

    void Shuffle(List<Transform> transforms)
    {
        for (int i = 0; i < transforms.Count; i++)
        {
            Transform temp = transforms[i];
            int randomIndex = Random.Range(i, transforms.Count);
            transforms[i] = transforms[randomIndex];
            transforms[randomIndex] = temp;
        }
    }
}
