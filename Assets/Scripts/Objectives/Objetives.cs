using UnityEngine;
using UnityEngine.Rendering;

public class Objetives : MonoBehaviour, IDamageble
{
    [Header("Configuración")]
    public Tipo tipoObjetivo = Tipo.Diana1;

    private float currentHealth;
    private int maxHealth;
    private int comboAmount;
    private float speed;

    private Rigidbody rb;
    

    private void Start()
    {
        maxHealth = ObjetivesManager.Instance.ObtenerVidaMaxima(tipoObjetivo);
        comboAmount = ObjetivesManager.Instance.ObtenerComboAmount(tipoObjetivo);
        speed = ObjetivesManager.Instance.ObtenerVelocidad(tipoObjetivo);
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            Movement();
        }
        //Debug.Log($"Objetivo tipo {tipoObjetivo} creado con {maxHealth} de vida");
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        //Debug.Log($"Objetivo {tipoObjetivo} recibió {damage} de daño. Vida restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Debug.Log($"Objetivo {tipoObjetivo} ha sido destruido");
        ComboManager.Instance.AumentarCombo(comboAmount);
        Destroy(gameObject);
    }

    private void Movement()
    {
        rb.linearVelocity = -transform.forward * speed;
    }
}
