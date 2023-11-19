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
        decaySpeed = 2f; // vitesse de d�croissance de l'alpha
        currentAlpha = 0.0f;
        beatThreshold = 0.01f;  // valeur � laquelle on flash (0.01 pour intensit�, 0.3 pour basse fr�quence)
        flashObject.SetActive(false);
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {



        // intensit�
        float[] spectrumData = new float[256];
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        // autre m�thode avec les basses fr�quences
        //float average = GetMaxLowFrequency(spectrumData);



        // Utilisez les donn�es audio pour d�tecter les battements
        float average = CalculateAverageIntensity(spectrumData);

        // Ajustez l'alpha en fonction de l'intensit� des battements
        currentAlpha = Mathf.Lerp(currentAlpha, average > beatThreshold ? 1f : 0f, Time.deltaTime * 2);


        // Ajustez l'alpha progressivement vers z�ro si la fonction StartFlash n'est pas appel�e
        currentAlpha = Mathf.Lerp(currentAlpha, 0f, Time.deltaTime * decaySpeed);

        // Appliquez l'alpha au sprite
        spriteFlash.color = new Color(spriteFlash.color.r, spriteFlash.color.g, spriteFlash.color.b, currentAlpha);

        // Si l'�nergie d�passe le seuil des battements
        if (average > beatThreshold && !isFlashing)
        {
            // D�clenchez le flash blanc
            StartFlash();
        }

        Debug.Log(average);
        
    }

    float CalculateAverageIntensity(float[] spectrumData)
    {
        // Calculez l'intensit� moyenne en fonction des donn�es du spectre audio
        float sum = 0f;

        for (int i = 0; i < spectrumData.Length; i++)
        {
            sum += spectrumData[i];
        }

        return sum / spectrumData.Length;
    }
   
    float GetMaxLowFrequency(float[] spectrumData)
    {
        int numLowFreqBins = 40;  // Ajustez le nombre de bins pour les basses fr�quences
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

        // Ajoutez des effets suppl�mentaires ici si n�cessaire

        // Emp�chez les flashs trop fr�quents en ajoutant un d�lai
        StartCoroutine(StopFlashAfterDelay());
    }

    System.Collections.IEnumerator StopFlashAfterDelay()
    {
        isFlashing = true;
        yield return new WaitForSeconds(0.9f);  // Ajustez la dur�e du flash
        flashObject.SetActive(false);
        isFlashing = false;
    }

}
