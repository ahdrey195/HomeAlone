using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject PC;
    public GameObject Light;
    public GameObject LightOff;
    public GameObject smth;

    public GameObject Ending1GO;
    public GameObject Ending1GOoff;
    public GameObject Ending2GO;
    public GameObject Ending2GOoff;
    public GameObject Ending3GO;
    public GameObject Ending3GOoff;
    public GameObject Ending4GO;

    public GameObject Cheats;

    public TMP_InputField SensitivityInputField;
    public Slider SensitivitySlider;
    public float SensitivityValue;
    public AudioMixer audio;
    public Slider audioSlider;
    float volume;
    void Start()
    {
        PlayerPrefs.SetInt("Cheats", 0);
        Cursor.lockState = CursorLockMode.Confined;
        if (PlayerPrefs.HasKey("EndingSleep"))
        {
            if (PlayerPrefs.GetInt("EndingSleep") == 1)
            {
                Light.SetActive(true);
                LightOff.SetActive(false);
                Ending1GO.SetActive(true);
                Ending1GOoff.SetActive(false);
            }
        }
        if (PlayerPrefs.HasKey("EndingNoSleep"))
        {

            if (PlayerPrefs.GetInt("EndingNoSleep") == 1)
            {
                Ending2GO.SetActive(true);
                Ending2GOoff.SetActive(false);
                PC.SetActive(true);
            }

        }
        if (PlayerPrefs.HasKey("EndingBackrooms"))
        {
            if (PlayerPrefs.GetInt("EndingBackrooms") == 1)
            {
                Ending3GO.SetActive(true);
                Ending3GOoff.SetActive(false);
            }
        }
        if (PlayerPrefs.HasKey("EndingSecret"))
        {
            if (PlayerPrefs.GetInt("EndingSecret") == 1)
            {
                Ending4GO.SetActive(true);
                Cheats.SetActive(true);
            }

        }
        if (PlayerPrefs.HasKey("Volume"))
        {
            LoadVol();
        }
        if (PlayerPrefs.HasKey("Sens"))
        {
            LoadSens();
        }

    }
    void Update()
    {
        SensitivityInputField.onValueChanged.AddListener(delegate { UpdateSliderValue(); });

        SensitivitySlider.onValueChanged.AddListener(delegate { UpdateInputFieldValue(); });
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadVol()
    {
        audioSlider.value = PlayerPrefs.GetFloat("Volume");
        SetVolume();
    }
    public void LoadSens()
    {
        SensitivityValue = PlayerPrefs.GetFloat("Sens");
    }
    public void SetVolume()
    {
        volume = audioSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);
    }
    void UpdateSliderValue()
    {
        SensitivityValue = float.Parse(SensitivityInputField.text);
        SensitivitySlider.value = SensitivityValue;
        PlayerPrefs.SetFloat("Sens", SensitivityValue);
    }
    void UpdateInputFieldValue()
    {
        SensitivityInputField.text = SensitivitySlider.value.ToString();
        PlayerPrefs.SetFloat("Sens", SensitivityValue);
    }
    public void CheatsOn()
    {
        PlayerPrefs.SetInt("Cheats", 1);
    }
    public void CheatsOff()
    {
        PlayerPrefs.SetInt("Cheats", 0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
