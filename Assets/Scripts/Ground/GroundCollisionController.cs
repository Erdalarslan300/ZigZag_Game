using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionController : MonoBehaviour
{
    [SerializeField] private GroundDataTransmitter groundDataTransmitter;

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            groundDataTransmitter.SetGroundRigidbodyValues();

            // CoinSpawner'ı gecikmeli tetikleme
            CoinSpawner coinSpawner = GetComponent<CoinSpawner>();
            if (coinSpawner != null)
            {
                StartCoroutine(coinSpawner.SpawnCoin());
            }
        }
    }
}
