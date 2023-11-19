using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFlashBeat : MonoBehaviour
{
    public AudioSource audioSource;
    public float beatThreshold;
    public GameObject flashObject;  // le flash
    private bool isFlashing = false;
    private float decaySpeed;
    private float currentAlpha;
    public SpriteRenderer spriteFlash;

    void Start()
    {
        decaySpeed = 2f; // vitesse de décroissance de l'alpha
        currentAlpha = 0.0f;
        beatThreshold = 0.01f;  // valeur à laquelle on flash (0.01 pour intensité, 0.3 pour basse fréquence)
        flashObject.SetActive(false);
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {



        // intensité
        float[] spectrumData = new float[256];
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        // autre méthode avec les basses fréquences
        //float average = GetMaxLowFrequency(spectrumData);



        // Utilisez les données audio pour détecter les battements
        float average = CalculateAverageIntensity(spectrumData);

        // Ajustez l'alpha en fonction de l'intensité des battements
        currentAlpha = Mathf.Lerp(currentAlpha, average > beatThreshold ? 1f : 0f, Time.deltaTime * 2);


        // Ajustez l'alpha progressivement vers zéro si la fonction StartFlash n'est pas appelée
        currentAlpha = Mathf.Lerp(currentAlpha, 0f, Time.deltaTime * decaySpeed);

        // Appliquez l'alpha au sprite
        spriteFlash.color = new Color(spriteFlash.color.r, spriteFlash.color.g, spriteFlash.color.b, currentAlpha);

        // Si l'énergie dépasse le seuil des battements
        if (average > beatThreshold && !isFlashing)
        {
            // Déclenchez le flash blanc
            StartFlash();
        }

        Debug.Log(average);
        
    }

    float CalculateAverageIntensity(float[] spectrumData)
    {
        // Calculez l'intensité moyenne en fonction des données du spectre audio
        float sum = 0f;

        for (int i = 0; i < spectrumData.Length; i++)
        {
            sum += spectrumData[i];
        }

        return sum / spectrumData.Length;
    }
   
    float GetMaxLowFrequency(float[] spectrumData)
    {
        int numLowFreqBins = 40;  // Ajustez le nombre de bins pour les basses fréquences
        int startIndex = 0;
        float maxLowFrequency = 0f;

        for (int i = startIndex; i < startIndex + numLowFreqBins; i++)
        {
            maxLowFrequency = Mathf.Max(maxLowFrequency, spectrumData[i]);
        }

        return maxLowFrequency;
    }


    void StartFlash()
    {
        
        // Activez le flash blanc (vous pouvez ajuster cette partie en fonction de votre configuration)
        flashObject.SetActive(true);

        // Ajoutez des effets supplémentaires ici si nécessaire

        // Empêchez les flashs trop fréquents en ajoutant un délai
        StartCoroutine(StopFlashAfterDelay());
    }

    System.Collections.IEnumerator StopFlashAfterDelay()
    {
        isFlashing = true;
        yield return new WaitForSeconds(0.9f);  // Ajustez la durée du flash
        flashObject.SetActive(false);
        isFlashing = false;
    }

}
