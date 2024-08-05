using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Gameplay.Player.Controller;
using GameData.Player.PlayerData;


namespace Gameplay.Player
{
    public class PlayerManager : MonoBehaviour, IDamageable
    {
        public static PlayerManager Instance { get; private set;}

        private PlayerController _controller;
        private Health _health;
        public Transform PlayerTransform;
        public event EventHandler OnDamageTaken;

        private void Awake()
        {
            Initialize();            
            PlayerTransform = GetComponent<Transform>();
            PlayerInfo.WritePlayerTransform(PlayerTransform);

            _health = new Health(100);
            Health.Death += Death;
            _controller = new PlayerController(Camera.main, GetComponent<CharacterController>(), GetComponent<Transform>());
        }

        private void Update()
        {
            _controller.Rorate();
        }

        private void FixedUpdate()
        {
            _controller.Move();
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
            OnDamageTaken?.Invoke(null, null);
            _health.GetDamage(damage);
            Health.Death -= Death;
        }
        
        private void Death(object sender, EventArgs e)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
