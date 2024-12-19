using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonController : MonoBehaviour
{
    public AudioManager audioManager; // AudioManager referansı
    public Text buttonText; // Buton üzerindeki Text referansı
    public MuteStateManager muteStateManager; // MuteStateManager referansı

    // Başlangıçta buton metnini doğru şekilde güncelle
    void Start()
    {
        UpdateButtonText();
    }

    // Mute butonuna tıklandığında mute durumu değişir
    public void ToggleMute()
    {
        audioManager.ToggleMute(); // Sesleri aç/kapat

        // Metni güncelle
        UpdateButtonText();

        // Mute durumu değiştiğinde kaydet
        muteStateManager.SaveMuteState();
    }

    // Mute durumu güncellemesi
    private void UpdateButtonText()
    {
        // AudioManager'daki mute durumuna göre metni güncelle
        if (audioManager.audioSource.mute)
        {
            buttonText.text = "Unmute";
        }
        else
        {
            buttonText.text = "Mute";
        }
    }
}
