using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioPeerScript : MonoBehaviour
{
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetAudioSpectrumSource();
        CreateFrequencyBands();
    }

    void GetAudioSpectrumSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void CreateFrequencyBands()
    {
        /* 22000 / 512 = 43hz per sample
         * 22000 / 1024 = 22hz per sample
         * 22000 / 2048 = 10hz per sample
         * 
         * 20-60
         * 60-250
         * 250-500
         * 500-2000
         * 2000-4000
         * 4000-6000
         * 6000-20000 
         */

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;
            freqBand[i] = average * 10;

        }
    }
}
