using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Game Over Panel referansı
    public Text scoreText; // Skor yazısı için referans
    private bool isGameOver = false;
    public AudioSource audioSource; // Ses çalacak olan AudioSource
    public AudioClip gameOverSound; // Game Over ses efekti
    public ScoreManager scoreManager; // ScoreManager referansı

    public void TriggerGameOver()
    {
        if (isGameOver) return; // Oyunun birden fazla kez bitmesini engelle

        isGameOver = true;
        Time.timeScale = 0; // Oyunu durdur
        scoreText.text = "Score:" + FindObjectOfType<ScoreManager>().GetScore(); // Skoru göster
        gameOverPanel.SetActive(true); // Game Over panelini aktif et

        // Game Over sesi çal
        audioSource.PlayOneShot(gameOverSound);

        // GameOver durumu ScoreManager'a bildir
        scoreManager.SetGameOverState(true); // Oyun bittiği için ses çalmaması için GameOver durumunu set et
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Zamanı normale döndür
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden yükle

        // Oyunun yeniden başlama işlemi sonrası oyun bitiş durumu sıfırlansın
        scoreManager.SetGameOverState(false); // Oyun başladı, ses çalmaya devam etsin
    }
}
