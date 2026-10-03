using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    public void Quit() => Application.Quit();
    public void Restart() => LoadScene(GetActiveScene().name);
}
