using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject audioPrefab;  // Add this line
    public float spawnRadius = 1.2f;

    void Update()
    {
        Vector3 mousePositionScreen = Input.mousePosition;
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(
            new Vector3(mousePositionScreen.x, mousePositionScreen.y, 10)
        );

        Vector2 dir = (mousePositionWorld - transform.position).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPos = transform.position + (Vector3)dir * spawnRadius;
            GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            bullet.GetComponent<Bullet>().Init(dir);
            
            // Instantiate the audio prefab and play the sound
            GameObject audioInstance = Instantiate(audioPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = audioInstance.GetComponent<AudioSource>();
            audioSource.Play();

            // Destroy the audio prefab after it finishes playing
            Destroy(audioInstance, audioSource.clip.length);
        }
    }
}
