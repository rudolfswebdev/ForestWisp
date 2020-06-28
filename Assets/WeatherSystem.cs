using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
    public static WeatherSystem instance;

    [SerializeField] private float startSunIntensity = 2.47f;
    public GameObject sun;
    public Light sunLight;
    [SerializeField] private float endSunIntensity = 1.8f;

    public GameObject rainTop;
    public GameObject rainBottom;

    public Color startColorSun;
    public Color endColorSun;

    public Color startFogColor;
    public Color endFogColor;

    public float startFogIntensity;
    public float endFogIntensity;

    [SerializeField] private float movementTimeInSeconds = 5f;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rainBottom.SetActive(false);
        rainTop.SetActive(false);
        sunLight = sun.GetComponent<Light>();
    }

    public void SetNight()
    {
        StartCoroutine(SetNightRoutine());
        StartCoroutine(SetNightRoutineFog());
        StartCoroutine(SetNightColor());
        StartCoroutine(SetFog());
    }

    public void SetDay()
    {
        StartCoroutine(SetDayRoutine());
        StartCoroutine(SetDayRoutineFog());
        StartCoroutine(SetDayColor());

        StartCoroutine(SetFogDay());
    }

    private IEnumerator SetNightRoutine()
    {
        float t = 0f;

        while (true)
        {
            t += Time.deltaTime / movementTimeInSeconds;
            sunLight.intensity = Mathf.Lerp(startSunIntensity, endSunIntensity, t);
            yield return null;
        }
    }

    private IEnumerator SetDayRoutine()
    {
        float t = 0f;

        while (true)
        {
            t += Time.deltaTime / movementTimeInSeconds;
            sunLight.intensity = Mathf.Lerp(endSunIntensity, startSunIntensity, t);
            yield return null;
        }
    }
    private IEnumerator SetNightColor()
    {
        float t = 0f;

        while (true)
        {
            t += Time.deltaTime / movementTimeInSeconds;
            sunLight.color = Color.Lerp(startColorSun, endColorSun, t);
            rainTop.SetActive(true);
            rainBottom.SetActive(true);
            yield return null;
        }
    }
    private IEnumerator SetDayColor()
    {
        float t = 0f;

        while (true)
        {
            t += Time.deltaTime / movementTimeInSeconds;
            sunLight.color = Color.Lerp(endColorSun, startColorSun, t);
            rainTop.SetActive(true);
            rainBottom.SetActive(true);
            yield return null;
        }
    }
    private IEnumerator SetFog()
    {
        float t = 0f;

        while (true)
        {
            t += Time.deltaTime / movementTimeInSeconds;
            RenderSettings.fogColor = Color.Lerp(startFogColor, endFogColor, t);
            rainTop.SetActive(true);
            rainBottom.SetActive(true);
            yield return null;
        }
    }
    private IEnumerator SetFogDay()
    {
        float t = 0f;

        while (true)
        {
            t += Time.deltaTime / movementTimeInSeconds;
            RenderSettings.fogColor = Color.Lerp(endFogColor, startFogColor, t);
            rainTop.SetActive(true);
            rainBottom.SetActive(true);
            yield return null;
        }
    }
    private IEnumerator SetNightRoutineFog()
    {
        float t = 0f;

        while (true)
        {
            t += Time.deltaTime / movementTimeInSeconds;
            RenderSettings.fogDensity = Mathf.Lerp(0.01f, 0.013f, t);
            yield return null;
        }
    }

    private IEnumerator SetDayRoutineFog()
    {
        float t = 0f;

        while (true)
        {
            t += Time.deltaTime / movementTimeInSeconds;
            RenderSettings.fogDensity = Mathf.Lerp(0.02f, 0.01f, t);
            yield return null;
        }
    }




}
