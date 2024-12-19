using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Coin Prefab referansı
    public float spawnChance = 0.6f; // %40 spawn şansı
    public float coinSpawnDelay = 15f; // Gecikme süresi (saniye)

    void Start()
    {
        // İlk kez coin spawnlama
        StartCoroutine(SpawnCoin());
    }

    public IEnumerator SpawnCoin()
    {
        // Önce varsa eski coin'leri sil (yeniden spawn için gerekli)
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Coin")) // Coin Prefab'ine "Coin" tag'ı eklediğinizi varsayıyorum
            {
                Destroy(child.gameObject);
            }
        }

        // Gecikme
        yield return new WaitForSeconds(coinSpawnDelay);

        // Rastgele şansa göre yeni coin oluştur
        if (Random.value < spawnChance)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * 1.0f;
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
