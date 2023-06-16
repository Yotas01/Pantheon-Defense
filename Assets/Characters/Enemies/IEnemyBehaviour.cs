using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public interface IEnemyBehaviour
    {
        int health { get; set;}

        void damage(int damage);

        void heal(int heal);
    }
}
