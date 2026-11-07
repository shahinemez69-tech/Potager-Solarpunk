using UnityEngine;
using UnityEngine.InputSystem;

public class DroneWatering : MonoBehaviour
{
    public InputActionReference waterAction;
    public ParticleSystem waterParticles;
    public AudioSource waterSound;   // nouveau champ
    public Transform plantsParent;
    public float waterRadius = 0.8f;

    void OnEnable()
    {
        waterAction.action.Enable();
    }

    void OnDisable()
    {
        waterAction.action.Disable();
    }

    void Update()
    {
        bool watering = waterAction.action.IsPressed();

        if (watering && !waterParticles.isPlaying)
        {
            waterParticles.Play();
            waterSound.Play();
        }
        else if (!watering && waterParticles.isPlaying)
        {
            waterParticles.Stop();
            waterSound.Stop();
        }

        foreach (Transform plant in plantsParent)
        {
            PlantGrowth growth = plant.GetComponent<PlantGrowth>();
            if (growth == null) continue;

            float dx = plant.position.x - transform.position.x;
            float dz = plant.position.z - transform.position.z;
            float distance = Mathf.Sqrt(dx * dx + dz * dz);

            growth.SetWatered(watering && distance < waterRadius);
        }
    }
}