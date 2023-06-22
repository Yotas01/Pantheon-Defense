using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public interface IEnemyBehaviour
    {
        Transform [] waypoints { get; set;}
        void damage(int damage);
        void heal(int heal);
    }
}
