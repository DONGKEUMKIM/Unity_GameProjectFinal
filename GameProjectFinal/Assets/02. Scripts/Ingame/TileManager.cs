using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public Bridge[] BridgePrefabs;

    public GameObject HousePrefab;


    public Transform playerTransform;

    public Text timerText;

    private float spawnZ = 0.0f;
    private float tileLength = 7.0f;
    private float safeZone = 15.0f;
    private int amnTilesOnScreen = 7;

    private List<Bridge> activeTiles;

    private bool isGoal;


    //Goal 알림
    public delegate void InformGameisGoalHandler();
    public static event InformGameisGoalHandler informGoal;

    private void Start()
    {
        activeTiles = new List<Bridge>();


        for (int i = 0; i < amnTilesOnScreen; i++)
        {

            SpawnTile();
        }
    }
    private void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength) &&
            float.Parse(timerText.text) > 3.0f)
        {
            SpawnTile();
            DeleteTile();
        }
        else if (float.Parse(timerText.text) < 3.0f && isGoal == false)
        {
            isGoal = true;
            SpawnHouse();
        }

    }

    private void SpawnTile(int prefabIndex = -1)
    {
        Bridge go;
        go = Instantiate(BridgePrefabs[0]) as Bridge;
        go.transform.SetParent(this.transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;

        go.ObjectRandomSpawn();

        activeTiles.Add(go);
    }

    private void SpawnHouse()
    {
        GameObject randomObject;
        randomObject = Instantiate(HousePrefab) as GameObject;

        randomObject.transform.SetParent(this.transform);
        randomObject.transform.position = Vector3.forward * (spawnZ - 3.5f);


    }


    private void DeleteTile()
    {
        activeTiles[0].Deleteallobejcts();

        Destroy(activeTiles[0].gameObject);
        activeTiles.RemoveAt(0);
    }
}
