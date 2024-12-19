using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteStateManager : MonoBehaviour
{
    private const string MuteStateKey = "MuteState"; // PlayerPrefs anahtarı

    public AudioManager audioManager; // AudioManager referansı

    private void Start()
    {
        // Oyun başladığında mute durumunu yükle
        bool isMuted = PlayerPrefs.GetInt(MuteStateKey, 1) == 1; // Varsayılan: 1 (mute)
        if (audioManager != null && audioManager.audioSource != null)
        {
            audioManager.audioSource.mute = isMuted;
        }
    }

    public void SaveMuteState()
    {
        // Mute durumunu kaydet
        if (audioManager != null && audioManager.audioSource != null)
        {
            PlayerPrefs.SetInt(MuteStateKey, audioManager.audioSource.mute ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
