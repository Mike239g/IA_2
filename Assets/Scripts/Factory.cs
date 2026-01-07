using UnityEngine;

namespace Disenos
{
    public class Factory : MonoBehaviour
    {
        public Enemy enemy = new EnemyFactory().Create(EnemyType.Zombie);
    }

    public abstract class Enemy
    {
        public int health;
        public abstract void Attack();
    }

    public class Zombie : Enemy
    {
        public Zombie()
        {
            health = 50;
        }

        public override void Attack()
        {
            Debug.Log("Zombie bite");
        }
    }

    public class SpookySkeleton : Enemy
    {
        public SpookySkeleton()
        {
            health = 67;
        }

        public override void Attack()
        {
            Debug.Log("Spooky spooky skeleton");
        }
    }

    public enum EnemyType
    {
        Zombie,
        SpookySkeleton
    }

    public class EnemyFactory
    {
        public Enemy Create(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Zombie:
                    return new Zombie();
                case EnemyType.SpookySkeleton:
                    return new SpookySkeleton();
                default:
                    Debug.Log("AAAAAAAAA");
                    return null;
            }
        }
    }
}