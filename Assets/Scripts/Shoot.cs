using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Shooting References")]
    public GameObject bulletPrefab;
    public Transform firePoint; // point from where the bullet will be instantiated

    private void Update()
    {
        // Check if the shoot button is pressed
        if (InputManager.Instance.ShootPressed())
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Instanciate the bullet at the firePoint's position and rotation
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("Falta asignar el prefab de la bala o el punto de disparo en el inspector.");
        }
    }
}