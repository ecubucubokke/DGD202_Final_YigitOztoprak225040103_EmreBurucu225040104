using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class RestartGame : MonoBehaviour
{
    // Butona týklanýnca çaðrýlacak fonksiyon
    public void Restart()
    {
        // Geçerli sahneyi yeniden yükler
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1f;
    }
}