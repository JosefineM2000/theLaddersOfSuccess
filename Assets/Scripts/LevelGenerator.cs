using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    /*[SerializeField] private Transform pfTestingPlatform;*/
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPart_list;
    [SerializeField] private GameObject player;

    private Vector3 lastEndPosition;
    private int levelPartSpawned;
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;
    private static LevelGenerator instance;

    private void Awake()
    {
        instance = this;
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        /*if (pfTestingPlatform != null)
        {
            Debug.Log("using Debug testing paltform");
        }
*/
        int startingSpawnLevelPart = 5;
        for (int i = 0; i < startingSpawnLevelPart; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPart_list[Random.Range(0, levelPart_list.Count)];

       /* if (pfTestingPlatform != null)
        {
            chosenLevelPart = pfTestingPlatform;
        }*/

        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        levelPartSpawned++;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    public static int GetLevelPartsSpawned()
    {
        return instance.levelPartSpawned;
    }
}
