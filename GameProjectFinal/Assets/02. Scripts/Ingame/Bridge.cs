using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject[] objects;

    public List<Transform> SpawnsPoint;

    public List<GameObject> objectlist;

    public void ObjectRandomSpawn()
    {
        //생성할 오브젝트의 개수
        int randomIndex = Random.Range(2, 2);

        //생성할 오브젝트의 개수 - 테스트
        //randomIndex = 0;

        for (int iCnt = 0; iCnt < randomIndex; iCnt++)
        {
            int positionIndex = Random.Range(0, SpawnsPoint.Count);

            SpawnObject(SpawnsPoint[positionIndex].position);

            SpawnsPoint.Remove(SpawnsPoint[positionIndex]);
        }
    }

    public void SpawnObject(Vector3 position)
    {
        int randomIndex = Random.Range(0,objects.Length);

        GameObject randomObject;
        randomObject = Instantiate(objects[randomIndex]) as GameObject;

        randomObject.transform.SetParent(this.transform);
        randomObject.transform.position = position;
        objectlist.Add(randomObject);
    }

    public void Deleteallobejcts()
    {
        for (int iCnt = 0; iCnt < SpawnsPoint.Count; iCnt++)
        {
            Destroy(SpawnsPoint[iCnt]);
        }
        SpawnsPoint.RemoveRange(0, SpawnsPoint.Count) ;

        for (int iCnt = 0; iCnt < objectlist.Count; iCnt++)
        {
            Destroy(objectlist[iCnt]);
        }
        objectlist.RemoveRange(0, SpawnsPoint.Count);
    }
}
