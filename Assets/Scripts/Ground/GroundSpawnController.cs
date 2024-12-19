using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnController : MonoBehaviour
{
    public GameObject lastGroundobject;

    [SerializeField] private GameObject groundprefab;

    private GameObject newGroundobject;

    private int groundDirection;

    



    void Start()
    {
        GenerateRandomNewGrounds();
    }

    public void GenerateRandomNewGrounds()
    {
        for (int i = 0; i < 75; i++)
        {
            CreateNewGround();
        }

    }


    private void CreateNewGround()
    {
        groundDirection = Random.Range(0, 2);

        if (groundDirection == 0)
        {
            newGroundobject = Instantiate(groundprefab, new Vector3(lastGroundobject.transform.position.x - 1f, lastGroundobject.transform.position.y, lastGroundobject.transform.position.z), Quaternion.identity);
            lastGroundobject = newGroundobject;
        }
        else
        {
            newGroundobject = Instantiate(groundprefab, new Vector3(lastGroundobject.transform.position.x, lastGroundobject.transform.position.y, lastGroundobject.transform.position.z + 1f), Quaternion.identity);
            lastGroundobject = newGroundobject;
        }

        CoinSpawner coinSpawner = newGroundobject.GetComponent<CoinSpawner>();
        if (coinSpawner != null)
        {
            coinSpawner.SpawnCoin();
        }
    }
}
