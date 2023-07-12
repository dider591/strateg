using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitch : MonoBehaviour
{
    [SerializeField] private string _russianWord;
    [SerializeField] private string _turkishWord;
    [SerializeField] private string _englishWord;

    private const string Language = "language";

    private string _russian = "russian";
    private string _turkish = "turkish";
    private string _english = "english";
    private Text _text;
    private string _language;

    public void Start()
    {
        _text = GetComponent<Text>();
        _language = PlayerPrefs.GetString(Language);
        ChangeWord(_language, _text);
    }

    private void ChangeWord(string language, Text text)
    {
        if (language == _russian)
        {
            text.text = _russianWord;
        }
        if (language == _turkish)
        {
            text.text = _turkishWord;
        }
        if (language == _english || language == "")
        {
            text.text = _englishWord;
        }
    }
}
