using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public float seedDuration = 8f;
    public float readyDuration = 8f;
    public float overripeDuration = 5f;
    public float waterMultiplier = 2f;

    public GameObject seedVisual;
    public GameObject readyVisual;
    public GameObject overripeVisual;
    public GameObject burstFx; 

    public int stage = 0;

    float timer = 0f;
    bool isWatered = false;

    void Start()
    {
        ShowStage();
    }

    public void SetWatered(bool value)
    {
        isWatered = value;
    }

    void Update()
    {
        if (isWatered)
            timer += Time.deltaTime * waterMultiplier;
        else
            timer += Time.deltaTime;

        if (stage == 0 && timer >= seedDuration)
            NextStage();
        else if (stage == 1 && timer >= readyDuration)
            NextStage();
        else if (stage == 2 && timer >= overripeDuration)
        {
            AudioManager.instance.PlayPop();

            if (burstFx != null)
                Instantiate(burstFx, transform.position + Vector3.up * 0.4f, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    void NextStage()
    {
        stage = stage + 1;
        timer = 0f;
        ShowStage();
    }

    void ShowStage()
    {
        seedVisual.SetActive(stage == 0);
        readyVisual.SetActive(stage == 1);
        overripeVisual.SetActive(stage == 2);
    }
}