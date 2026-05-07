using UnityEngine;

public class ObjetivesSpawner : MonoBehaviour
{
    [Header("Referencia del Prefab")]
    [SerializeField]
    private GameObject objetivoPrefab;

    [Header("Configuración de Spawn")]
    [SerializeField]
    private float tiempoEntreSpawns = 2f;

    [Header("Rango de Objetivos por Tipo")]
    [SerializeField]
    private int objetivosPorTipo = 4;

    [SerializeField]
    private Vector3 posicionSpawn = Vector3.zero;

    [SerializeField]
    private Vector3 rangoSpawn = new Vector3(5f, 0f, 5f);

    private float tiempoSiguienteSpawn = 0f;
    private int objetivosCreados = 0;

    private void Update()
    {
        tiempoSiguienteSpawn -= Time.deltaTime;

        if (tiempoSiguienteSpawn <= 0f)
        {
            SpawnObjetivo();
            tiempoSiguienteSpawn = tiempoEntreSpawns;
        }
    }

    private void SpawnObjetivo()
    {
        if (objetivoPrefab == null)
        {
            Debug.LogError("Falta asignar el prefab del objetivo en el Inspector");
            return;
        }

        Tipo tipoActual = ObtenerTipoSegunCuenta();

        Vector3 posicionAleatoria = posicionSpawn + new Vector3(
            Random.Range(-rangoSpawn.x, rangoSpawn.x),
            Random.Range(-rangoSpawn.y, rangoSpawn.y),
            Random.Range(-rangoSpawn.z, rangoSpawn.z)
        );

        GameObject nuevoObjetivo = Instantiate(objetivoPrefab, posicionAleatoria, Quaternion.identity);

        Objetives objetivoScript = nuevoObjetivo.GetComponent<Objetives>();
        if (objetivoScript != null)
        {
            objetivoScript.tipoObjetivo = tipoActual;
        }

        //Debug.Log($"Objetivo {objetivosCreados + 1} de tipo {tipoActual} creado en {posicionAleatoria}");
        objetivosCreados++;
    }

    private Tipo ObtenerTipoSegunCuenta()
    {
        int grupoActual = objetivosCreados / objetivosPorTipo;

        return grupoActual switch
        {
            0 => Tipo.Diana1,
            1 => Tipo.Diana2,
            2 => Tipo.Diana3,
            _ => Tipo.Diana3 
        };
    }

    public void Resetear()
    {
        objetivosCreados = 0;
        tiempoSiguienteSpawn = tiempoEntreSpawns;
    }

    public void PausarSpawns(bool pausado)
    {
        enabled = !pausado;
    }
}