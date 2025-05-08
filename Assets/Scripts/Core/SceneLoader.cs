using UnityEngine.SceneManagement;

namespace Core
{
    public static class SceneLoader
    {
        public static void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}