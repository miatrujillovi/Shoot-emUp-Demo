using UnityEngine;
public enum Tipo
{
    Diana1,
    Diana2,
    Diana3
}

[System.Serializable]
public class TipoObjetivo
{
    public Tipo Type;
    public int maxHealth;
}

public class ObjetivesManager : MonoBehaviour
{
    public static ObjetivesManager Instance { get; private set; }

    [SerializeField]
    private TipoObjetivo[] tiposDisponibles = new TipoObjetivo[3]
    {
        new TipoObjetivo { Type = Tipo.Diana1, maxHealth = 2 },
        new TipoObjetivo { Type = Tipo.Diana2, maxHealth = 4 },
        new TipoObjetivo { Type = Tipo.Diana3, maxHealth = 6 }
    };

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public int ObtenerVidaMaxima(Tipo tipo)
    {
        foreach (TipoObjetivo tipoObj in tiposDisponibles)
        {
            if (tipoObj.Type == tipo)
            {
                return tipoObj.maxHealth;
            }
        }

        Debug.LogWarning($"Tipo {tipo} no encontrado, usando vida por defecto 2");
        return 2;
    }
}