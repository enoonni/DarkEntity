using UnityEngine;
using GameData.Stopwatch;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        
        void Start()
        {
            Stopwatch.StartStopwatch();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void FixedUpdate()
        {
            Stopwatch.AddTime(Time.deltaTime);
        }
    } 
}
