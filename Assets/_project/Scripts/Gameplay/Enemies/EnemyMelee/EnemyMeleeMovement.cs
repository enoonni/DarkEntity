using System;
using UnityEngine;
using GameData.Enemy;
using GameData.Player.PlayerData;

namespace Gameplay.Enemys.EnemyMelee
{
    public class EnemyMeleeMovement
    {
        private Transform _player;
        private Transform _skeleton;
        private DataEnemy _dataSkeleton;
        private CharacterController _controller;

        private bool _hasReached = false;
        private float _distants = 0;
        public event EventHandler OnHasReached;

        public EnemyMeleeMovement(Transform skeleton, DataEnemy dataSkeleton, CharacterController controller)
        {
            _player = PlayerInfo.PlayerTransform;
            _skeleton = skeleton;
            _dataSkeleton = dataSkeleton;
            _controller = controller;
        }

        public void Move()
        {
            CheckDistants();
            RotateEnemy();
            PursuitPlayer();
        }

        private void RotateEnemy()
        {
            var dist = _player.transform.position - _skeleton.position;
            Quaternion rotation = Quaternion.LookRotation(dist, _skeleton.TransformDirection(Vector3.up));
            _skeleton.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        } 

        private void CheckDistants()
        {
            _distants = Vector3.Distance(_player.transform.position, _skeleton.position);
        }

        private void PursuitPlayer()
        {        
            if(_distants > _dataSkeleton.AttackRange && _hasReached == false)
            {
                Vector3 direction = (_player.transform.position - _skeleton.position).normalized;
                _controller.Move(direction * _dataSkeleton.MoveSpeed * Time.deltaTime);
            }
            else if(_hasReached == false)
            {
                _hasReached = true;
                OnHasReached?.Invoke(null, null);
            }
        }
    }
}
