using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject bonusPrefab; // Bonus Prefab referansı
    public float spawnChance = 0.6f; // %40 spawn şansı
    public float bonusSpawnDelay = 15f; // Gecikme süresi (saniye)

    void Start()
    {
        // İlk kez bonus spawnlama
        StartCoroutine(SpawnBonus());
    }

    public IEnumerator SpawnBonus()
    {
        // Önce varsa eski bonus'ları sil (yeniden spawn için gerekli)
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Bonus")) // Bonus Prefab'ine "Bonus" tag'ı eklediğinizi varsayıyorum
            {
                Destroy(child.gameObject);
            }
        }

        // Gecikme
        yield return new WaitForSeconds(bonusSpawnDelay);

        // Rastgele şansa göre yeni bonus oluştur
        if (Random.value < spawnChance)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * 1.0f;
            Instantiate(bonusPrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
