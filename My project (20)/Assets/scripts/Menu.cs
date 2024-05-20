using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public TMP_InputField SensitivityInputField;
    public Slider SensitivitySlider;
    public float SensitivityValue;
    public interaction Player;
    public FirstPersonController fpc;
    public AudioMixer audio;
    public Slider audioSlider;
    public GameObject Pause;
    float volume;
    void Start()
    {
        SensitivityValue = fpc.mouseSensitivity;
        SensitivitySlider.value = SensitivityValue;
        UpdateInputFieldValue();
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
    void UpdateSliderValue()
    {
        SensitivityValue = float.Parse(SensitivityInputField.text);
        SensitivitySlider.value = SensitivityValue;
        fpc.mouseSensitivity = SensitivityValue;
        PlayerPrefs.SetFloat("Sens",SensitivityValue );
    }
    void UpdateInputFieldValue()
    {
        SensitivityInputField.text = SensitivitySlider.value.ToString();
        fpc.mouseSensitivity = SensitivityValue;
        PlayerPrefs.SetFloat("Sens", SensitivityValue);
    }
    public void SetVolume()
    {
        volume = audioSlider.value;
        audio.SetFloat("Master",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void LoadVol()
    {
        volume= PlayerPrefs.GetFloat("Volume");
        audioSlider.value = PlayerPrefs.GetFloat("Volume");
        SetVolume();
    }
    public void LoadSens()
    { 
        SensitivityValue = PlayerPrefs.GetFloat("Sens");
        SensitivityInputField.text = SensitivityValue.ToString();
        fpc.mouseSensitivity = SensitivityValue;
    }
}
