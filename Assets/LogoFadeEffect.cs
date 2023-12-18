using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoFadeEffect : MonoBehaviour
{
    public Image logoImage;
    public float fadeDuration = 2.0f;
    private float timer = 0.0f;
    private bool fadeIn = true;

    void Start()
    {
        logoImage.color = new Color(1f, 1f, 1f, 0f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (fadeIn)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            logoImage.color = new Color(1f, 1f, 1f, alpha);

            if (timer > fadeDuration)
            {
                timer = 0.0f;
                fadeIn = false;
            }
        }
        else
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            logoImage.color = new Color(1f, 1f, 1f, alpha);

            if (timer > fadeDuration)
            {
                LoadNextScene();
            }
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Cutscene_1");
    }
}
