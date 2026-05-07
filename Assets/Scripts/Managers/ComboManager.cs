using System.ComponentModel;
using UnityEngine;
using DG.Tweening;

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
        // Debug.Log("Combo aumentado: " + currentComboCount);
    }

    public void ReiniciarCombo()
    {
        currentComboCount = 0;
        ActualizarUI();
        // Debug.Log("Combo reiniciado.");
    }

    public void DisminuirCombo(int cantidad)
    {
        currentComboCount = Mathf.Max(0, currentComboCount - cantidad);
        ActualizarUI();
        // Debug.Log("Combo disminuido: " + currentComboCount);
    }

    public int SetDamage()
    {
        // El daño se calcula en función del combo actual, aumentando cada 4 combos, con un máximo de 6 niveles de daño, es dinamico, si baja el combo baja el daño
        return Mathf.Clamp(Mathf.FloorToInt(currentComboCount / 4f),1 , 6);
    }

    public void ActualizarUI()
    {
        comboText.text = "Combo: " + currentComboCount;

        // Movimiento

        float valorX = Random.Range(-25f, 25f);
        float valorY = Random.Range(-25f, 25f);
        float valorZ = Random.Range(-25f, 25f);

        //comboText.rectTransform.DOShakeAnchorPos(0.12f, 1f, 18, 45, false, true);

        comboText.rectTransform.DOPunchScale(
            new Vector3(0.2f, 0.2f, 0),
            0.15f, 7, 0.7f
        ).OnComplete(() => comboText.rectTransform.localScale = Vector3.one);

        comboText.rectTransform.DOPunchRotation(
            new Vector3(valorX, valorY, valorZ),
            0.15f,
            10,
            0.5f
        ).OnComplete(() => comboText.rectTransform.localRotation = Quaternion.identity);

    }

}
