using DG.Tweening;
using UnityEngine;

public class WallLimit : MonoBehaviour
{
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diana"))
        {
            Destroy(other);
        }
    }
    */
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Diana"))
        {
            ComboManager.Instance.DisminuirCombo(1);
            Destroy(collision.gameObject);
        }
    }
    
}
