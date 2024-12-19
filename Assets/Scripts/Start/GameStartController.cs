using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameStartController : MonoBehaviour
{
    public Text startText; // Başlama yazısı
    public GameObject ball; // Top referansı
    private bool gameStarted = false;

    void Start()
    {
        Time.timeScale = 0; // Oyunu durdur
        ball.GetComponent<Rigidbody>().isKinematic = true; // Topu sabitle
        startText.gameObject.SetActive(true); // Yazıyı göster
    }

    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1; // Oyunu başlat
        ball.GetComponent<Rigidbody>().isKinematic = false; // Topu serbest bırak
        startText.gameObject.SetActive(false); // Yazıyı gizle
    }
}