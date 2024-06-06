using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeAndCollect : MonoBehaviour
{
    int collected;
    public float timeLeft = 180f; // 3 dakika

    public TMP_Text collectedText;
    public TMP_Text timerText;
    public AudioSource audioSource;
    public GameObject winPanel; // Win panel
    public GameObject losePanel; // Lose panel

    bool isGameOver = false;

    void Start()
    {
        collected = 0;
        UpdateCollectedText();
        UpdateTimerText();

        if (winPanel != null)
        {
            winPanel.SetActive(false); // Ensure the win panel is hidden at the start
        }

        if (losePanel != null)
        {
            losePanel.SetActive(false); // Ensure the lose panel is hidden at the start
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            // Zamaný azalt
            timeLeft -= Time.deltaTime;

            // Zamaný güncelle
            UpdateTimerText();

            // Eðer zaman biterse oyunu kaybettir
            if (timeLeft <= 0)
            {
                GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGameOver)
        {
            if (other.gameObject.CompareTag("CollectThing"))
            {
                collected++;
                UpdateCollectedText();
                Destroy(other.gameObject);

                if (audioSource != null && audioSource.clip != null)
                {
                    audioSource.Play();
                }
                else
                {
                    Debug.LogWarning("AudioSource veya Audio Clip eksik!");
                }

                if (collected == 17)
                {
                    WinGame();
                }
            }
        }
    }

    void UpdateCollectedText()
    {
        if (collectedText != null)
        {
            collectedText.text = "Rings: " + collected.ToString();
        }
        else
        {
            Debug.LogWarning("CollectedText bileþeni eksik!");
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            // Saniye cinsinden zamaný göster
            int seconds = Mathf.RoundToInt(timeLeft) % 60;
            int minutes = Mathf.RoundToInt(timeLeft) / 60;

            timerText.text = "Time Left: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
        else
        {
            Debug.LogWarning("TimerText bileþeni eksik!");
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");

        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }

        DisableAudioListener();
        Time.timeScale = 0f;
    }

    void WinGame()
    {
        isGameOver = true;
        Debug.Log("You Win!");

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        DisableAudioListener();
        Time.timeScale = 0f;
    }

    void DisableAudioListener()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            AudioListener audioListener = mainCamera.GetComponent<AudioListener>();
            if (audioListener != null)
            {
                audioListener.enabled = false;
            }
            else
            {
                Debug.LogWarning("Main Camera does not have an AudioListener component!");
            }
        }
        else
        {
            Debug.LogWarning("Main Camera not found!");
        }
    }
}
