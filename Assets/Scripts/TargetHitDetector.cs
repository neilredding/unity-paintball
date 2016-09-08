using UnityEngine;
using System.Collections;

public class TargetHitDetector : MonoBehaviour
{
    public GameObject paintballSplatPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Paintball"))
        {
            GameObject paintSplat = (GameObject)Instantiate(paintballSplatPrefab, collision.transform.position, collision.transform.rotation);
            GameManager.IncrementScore();
            Destroy(paintSplat, 2.0f);
            Destroy(collision.gameObject);
        }
    }
}
