using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Skor yazısı
    public Text bestScoreText; // Best Skor yazısı
    private int score = 0;
    private int bestScore = 0; // En yüksek skor
    public AudioSource audioSource; // Ses efektini çalacak olan AudioSource
    public AudioClip clickSound; // Yüklediğiniz ses efektinin referansı
    public AudioClip coinSound; // Coin için ses efekti ekleyin
    public AudioClip bonusSound; // Bonus için ses efekti ekleyin
    private bool isGameOver = false; // Oyun bitti mi kontrolü

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0); // En yüksek skoru PlayerPrefs'ten al
        UpdateScoreUI(); // Başlangıçta UI'yi güncelle
        UpdateBestScoreUI(); // Best Skoru UI'ye yansıt
    }

    void Update()
    {
        if (!isGameOver) // Oyun bittiğinde ses çalmaması için
        {
            // Ekrana dokunma kontrolü
            if (Input.GetMouseButtonDown(0)) // Mouse sol tuşuna basıldığında veya dokunulduğunda
            {
                IncreaseScore();
                PlayClickSound(); // Ses çal
            }
        }
    }

    void IncreaseScore()
    {
        score++; // Skoru artır
        if (score > bestScore) // Eğer skor en yüksek skordan büyükse
        {
            bestScore = score; // Best skoru güncelle
            PlayerPrefs.SetInt("BestScore", bestScore); // Best skoru PlayerPrefs'e kaydet
            UpdateBestScoreUI(); // Best Skor UI'sini güncelle
        }
        UpdateScoreUI(); // Skor yazısını güncelle
    }

    public void AddScore(int amount)
    {
        score += amount; // Skora belirli bir miktar ekle
        UpdateScoreUI(); // UI'yi güncelle
    }

    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString(); // Skor yazısını güncelle
    }

    private void UpdateBestScoreUI()
    {
        bestScoreText.text = "Best Skor: " + bestScore.ToString(); // Best Skoru güncelle
    }

    public int GetScore()
    {
        return score;
    }

    // Coin çarptığında ses efekti çalma fonksiyonu
    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound); // Coin için ses çal
    }

    // Bonus çarptığında ses efekti çalma fonksiyonu
    public void PlayBonusSound()
    {
        audioSource.PlayOneShot(bonusSound); // Bonus için ses çal
    }

    // Ses efekti çalma fonksiyonu (tıklama için)
    private void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound); // Tıklama sesini çal
    }

    // Oyun bitişi için GameOver kontrolü ekleyin
    public void SetGameOverState(bool isGameOver)
    {
        this.isGameOver = isGameOver;
    }

    
}
