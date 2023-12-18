using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer cutsceneVideoPlayer; // Video player untuk cutscene
    [SerializeField] private string nextSceneName; // Nama scene yang akan dilanjutkan setelah cutscene

    private void Start()
    {
        // Mendaftarkan event handler untuk event loopPointReached dari VideoPlayer
        cutsceneVideoPlayer.loopPointReached += OnCutsceneFinished;
    }

    // Ketika cutscene selesai diputar
    private void OnCutsceneFinished(VideoPlayer vp)
    {
        LoadNextScene(); // Memuat scene berikutnya setelah cutscene selesai
    }

    // Memuat scene berikutnya
    private void LoadNextScene()
    {
        // Pastikan nextSceneName sudah diisi dengan nama scene yang akan dilanjutkan
        SceneManager.LoadScene(nextSceneName);
    }
}
