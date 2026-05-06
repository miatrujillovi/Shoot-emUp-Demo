using UnityEngine;
using UnityEngine.Rendering;

public class Objetives : MonoBehaviour, IDamageble
{
    [Header("Configuración")]
    public Tipo tipoObjetivo = Tipo.Diana1;

    private float currentHealth;
    private int maxHealth;
    
    private void Start()
    {
        maxHealth = ObjetivesManager.Instance.ObtenerVidaMaxima(tipoObjetivo);
        currentHealth = maxHealth;

        Debug.Log($"Objetivo tipo {tipoObjetivo} creado con {maxHealth} de vida");
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Objetivo {tipoObjetivo} recibió {damage} de daño. Vida restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log($"Objetivo {tipoObjetivo} ha sido destruido");
        Destroy(gameObject);
    }
}
