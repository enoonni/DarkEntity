using UnityEngine.SceneManagement;

public class PlayerHealth : HeandlerHealth
{
    protected override void Death()
    {
       SceneManager.LoadScene("SampleScene");
    }
}
