using UnityEngine;
using System;
using Gameplay.Player.Controller;

namespace Gameplay.Player
{
    public class PlayerManager : MonoBehaviour, IDamageable
    {
        public static PlayerManager Instance { get; private set;}

        private PlayerController _controller;
        public Transform PlayerTransform;
        public event EventHandler OnDamageTaken;

        private void Awake()
        {
            Initialize();            
            PlayerTransform = GetComponent<Transform>();
        }

        private void Initialize()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
      
        public void TakeDamage(int damage)
        {

        }
    }
}
