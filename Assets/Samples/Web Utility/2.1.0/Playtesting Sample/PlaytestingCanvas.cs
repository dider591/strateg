using UnityEngine;
using UnityEngine.UI;

namespace Agava.WebUtility.Samples
{
    public class PlaytestingCanvas : MonoBehaviour
    {
        [SerializeField]
        private Text _adBlockStatusText;

        private void OnEnable()
        {
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        }

        private void Update()
        {
            _adBlockStatusText.color = AdBlock.Enabled ? Color.red : Color.green;
            _adBlockStatusText.text = $"{nameof(AdBlock)}.{nameof(AdBlock.Enabled)} = {AdBlock.Enabled}";
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            AudioListener.pause = inBackground;
            AudioListener.volume = inBackground ? 0f : 1f;
        }
    }
}
