using System.ComponentModel;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public static ComboManager Instance { get; private set; }

    [Header("ComboUI")]
    public TMPro.TextMeshProUGUI comboText;

    private int currentComboCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AumentarCombo(int cantidad)
    {
        currentComboCount = currentComboCount + cantidad;
        ActualizarUI();
        Debug.Log("Combo aumentado: " + currentComboCount);
    }

    public void ReiniciarCombo()
    {
        currentComboCount = 0;
        ActualizarUI();
        Debug.Log("Combo reiniciado.");
    }

    public void DisminuirCombo(int cantidad)
    {
        currentComboCount = Mathf.Max(0, currentComboCount - cantidad);
        ActualizarUI();
        Debug.Log("Combo disminuido: " + currentComboCount);
    }

    public int SetDamage()
    {
        // El daño se calcula en función del combo actual, aumentando cada 4 combos, con un máximo de 3 niveles de daño.
        return Mathf.Clamp(Mathf.Max(1, Mathf.FloorToInt(currentComboCount / 4f)),1 , 3);
    }

    public void ActualizarUI()
    {
        comboText.text = "Combo: " + currentComboCount;
    }

}
