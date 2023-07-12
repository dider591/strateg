using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChanger : MonoBehaviour
{
    [SerializeField] private LanguageSwitch _languageSwitch;
    [SerializeField] private LocalizationScreen _localizationScreen;

    private void OnEnable()
    {
        _localizationScreen.ChangeLanguage += OnChangeLanguage;
    }

    private void OnDisable()
    {
        _localizationScreen.ChangeLanguage -= OnChangeLanguage;
    }

    private void OnChangeLanguage()
    {
        _languageSwitch.Start();
    }
}
