using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New DataEnemy", menuName = "Data Enemy", order = 51)]
public class DataEnemy : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private string _name;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _getExp;


    public GameObject Prefab { get { return _prefab; } }
    public string Name { get { return _name; } }
    public int MaxHealth {get { return _maxHealth;} }
    public int AttackDamage {get { return _attackDamage;} }
    public float AttackSpeed {get { return _attackSpeed;} }
    public float AttackRange {get { return _attackRange;} }
    public float MoveSpeed {get { return _moveSpeed;} }
    public int GetExp { get { return _getExp;}}

    private static List<DataEnemy> _listEnemy = new List<DataEnemy>();
    public static List<DataEnemy> ListEnemy{get{ return _listEnemy;} }

    public DataEnemy()
    {
        _listEnemy.Add(this);
    }

    public static DataEnemy GetEnemy(string name)
    {
        foreach(DataEnemy enemy in _listEnemy)
        {
            if(enemy.Name == name)
                return enemy;
        }
        return null;
    }
}
