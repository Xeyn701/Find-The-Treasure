using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinID;
    private bool isTaken = false;

    private void Update()
    {
        if (!isTaken)
            transform.Rotate(0, 90 * Time.deltaTime, 0); // Animasi rotasi sederhana, ubah nilai rotasi sesuai kebutuhan
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTaken)
        {
            Debug.Log("Coin Diambil");

            // Animasi menghilang
            gameObject.SetActive(false);
            isTaken = true;

            // Tambahkan logika lain yang diperlukan seperti penambahan skor atau logika permainan lainnya
        }
    }
}
