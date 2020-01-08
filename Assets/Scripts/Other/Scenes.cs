using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public static Scenes Instance = null;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	public void Quit()
	{
		Application.Quit();
	}
}
