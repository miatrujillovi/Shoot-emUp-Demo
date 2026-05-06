using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;
    public int damage;
    
    private Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * speed;
        }
    }

    private void Update()
    {
        if (rb == null)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión detectada con: " + other.gameObject.name);

        if (other.TryGetComponent(out IDamageble damageble))
        {
            Debug.Log("IDamageble encontrado, aplicando daño: " + damage);
            damageble.Damage(damage);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No se encontró IDamageble en " + other.gameObject.name);
            Destroy(gameObject);
        }
    }
}