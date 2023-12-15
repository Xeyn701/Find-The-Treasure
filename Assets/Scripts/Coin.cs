using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinID;
    private bool isTaken = false;

    private void Update()
    {
        if (!isTaken)
            transform.Rotate(0, 90 * Time.deltaTime, 0); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTaken)
        {
            Debug.Log("Coin Diambil");

            gameObject.SetActive(false);
            isTaken = true;
        }
    }
}
