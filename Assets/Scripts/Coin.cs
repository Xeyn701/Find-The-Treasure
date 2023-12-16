using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1; // Nilai koin yang akan ditambahkan
    private bool isTaken = false; // Menandai apakah koin telah diambil atau belum

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTaken && collision.CompareTag("Player"))
        {
            Debug.Log("Coin Diambil");

            // Memanggil GameManager untuk menambah jumlah koin
            if (GameManager.instance != null)
            {
                GameManager.instance.AddCoin(coinValue);
            }

            // Contoh: memanggil AudioPlayer untuk efek suara saat mengambil koin
            AudioPlayer.instance.PlaySFX(1);

            isTaken = true; // Menandai bahwa koin telah diambil

            Destroy(gameObject);
        }
    }
}
