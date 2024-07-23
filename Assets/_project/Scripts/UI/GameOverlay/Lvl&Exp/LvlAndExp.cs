using UnityEngine;
using System;
using TMPro;
using GameData.Player.Experience;

namespace UI.Overlay.LvlAndExp
{
    public class LvlAndExp : MonoBehaviour
    {
        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();

            Experience.LevelIsChaged += ChangeInfo;
            Experience.ExperienceIsChaged += ChangeInfo;
        }

        public void ChangeInfo(object sender, EventArgs e)
        {
            _text.text =  $"Current Level: {Experience.CurrentLevel}\nCurrent Experience: {Experience.CurrentExperience}";
        }
    }
}
