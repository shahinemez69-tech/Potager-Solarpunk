using UnityEngine;
using UnityEngine.InputSystem;

public class DronePlanter : MonoBehaviour
{
    public GameObject seedPrefab;
    public InputActionReference plantAction;
    public float groundY = 0.2f;
    public Transform plantsParent;
    public ScoreManager scoreManager;

    void OnEnable()
    {
        plantAction.action.Enable();
    }

    void OnDisable()
    {
        plantAction.action.Disable();
    }

    void Update()
    {
        if (plantAction.action.WasPressedThisFrame())
        {
            Plant();
        }
    }

    void Plant()
    {
        Vector3 position = new Vector3(transform.position.x, groundY, transform.position.z);
        GameObject newPlant = Instantiate(seedPrefab, position, Quaternion.identity, plantsParent);

        PlantHarvest harvest = newPlant.GetComponent<PlantHarvest>();
        if (harvest != null)
            harvest.scoreManager = scoreManager;

        AudioManager.instance.PlayPlant();
    }
}