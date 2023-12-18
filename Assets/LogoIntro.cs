using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoIntro : MonoBehaviour
{
    public float fadeDuration = 2.0f;
    private float timer = 0.0f;
    private bool fadeIn = true;

    void Update()
    {
        timer += Time.deltaTime;

        if (fadeIn)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            SetQuadAlpha(alpha);

            if (timer > fadeDuration)
            {
                timer = 0.0f;
                fadeIn = false;
            }
        }
        else
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            SetQuadAlpha(alpha);

            if (timer > fadeDuration)
            {
                LoadNextScene();
            }
        }
    }

    void SetQuadAlpha(float alpha)
    {
        Color color = Color.black;
        color.a = alpha;
        GetComponent<Renderer>().material.color = color;
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("NamaSceneBerikutnya");
        // Ganti "NamaSceneBerikutnya" dengan nama scene yang ingin dimuat
    }
}
