using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class RestartGame : MonoBehaviour
{
    // Butona t�klan�nca �a�r�lacak fonksiyon
    public void Restart()
    {
        // Ge�erli sahneyi yeniden y�kler
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1f;
    }
}