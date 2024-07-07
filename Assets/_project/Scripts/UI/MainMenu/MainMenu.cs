using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class MainMenu: MonoBehaviour
    {
       public static void LoadGame()
       {
            SceneManager.LoadScene("SampleScene");
       }
    }
}
