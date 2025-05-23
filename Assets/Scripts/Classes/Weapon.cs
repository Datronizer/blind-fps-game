using UnityEngine;

public class Weapon
{
    string name;
    string description;
    float damage;
    float attackSpeed;

    public string Name { get => name; set => name = value; }
    public string Description { get; set; }
    public float Damage {  get; set; }
    public float AttackSpeed { get; set; }


    void Attack(GameObject target)
    {

    }
}