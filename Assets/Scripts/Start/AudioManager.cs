using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource referansı
    public MuteStateManager muteStateManager; // MuteStateManager referansı

    // Sesleri aç/kapat
    public void ToggleMute()
    {
        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute; // mute özelliğini tersine çevir
        }

        // Mute durumu değiştiğinde kaydet
        if (muteStateManager != null)
        {
            muteStateManager.SaveMuteState(); // Mute durumunu kaydet
        }
    }

    void Start()
    {
        // Başlangıçta mute durumu yüklensin
        if (muteStateManager != null)
        {
            muteStateManager.SaveMuteState(); // Mute durumunu kaydedelim
        }
    }
}
