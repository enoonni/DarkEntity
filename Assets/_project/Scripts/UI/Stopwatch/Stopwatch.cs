using UnityEngine;
using TMPro;
using GameData.Stopwatch;

namespace UI.Stopwatch
{
    public class Stopwatch : MonoBehaviour
    {
        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            Debug.Break();
            GameData.Stopwatch.Stopwatch.TimeIsChanged += ChangeTIme;
        }

        public void ChangeTIme(object sender, System.EventArgs e)
        {     
            _text.text = string.Format("{0:00}:{1:00}", 
                    Mathf.FloorToInt((float)sender / 60), 
                    Mathf.FloorToInt((float)sender % 60), 
                    (int)((float)sender * 1000) % 1000);
        }
    }
}
