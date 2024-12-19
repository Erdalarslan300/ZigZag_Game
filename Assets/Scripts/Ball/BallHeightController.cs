using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHeightController : MonoBehaviour
{
    public float minHeight = 10f; // Topun erişebileceği minimum yükseklik
    public GameOverManager gameOverManager; // Game Over işlemleri için referans

    void Update()
    {
        // Eğer topun yüksekliği belirlenen değerin altına düşerse
        if (transform.position.y < minHeight)
        {
            gameOverManager.TriggerGameOver(); // Oyunu bitir
        }
    }
}
