using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    public ScoreManager scoreManager; // Skor yöneticisini referans al

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            scoreManager.AddScore(2); // Coin skora +2 ekler
            scoreManager.PlayCoinSound(); // Coin çarpma sesi çal
            Destroy(collision.gameObject); // Coin yok edilir
        }
        else if (collision.gameObject.CompareTag("Bonus"))
        {
            scoreManager.AddScore(5); // Bonus skora +5 ekler
            scoreManager.PlayBonusSound(); // Bonus çarpma sesi çal
            Destroy(collision.gameObject); // Bonus yok edilir
        }
    }
}
