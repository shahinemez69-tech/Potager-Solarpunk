using UnityEngine;


public class PlantHarvest : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject harvestFx; 
    PlantGrowth growth;

    void Start()
    {
        growth = GetComponent<PlantGrowth>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<DroneController>() == null) return;

        if (growth.stage == 1)
        {
            if (scoreManager != null)
                scoreManager.AddPoint();

            AudioManager.instance.PlayHarvest();

            if (harvestFx != null)
                Instantiate(harvestFx, transform.position + Vector3.up * 0.4f, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}