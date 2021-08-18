using UnityEngine;

namespace Source.Scripts.Entities
{
    public class Block : MonoBehaviour
    {
        public int PositionX => Mathf.RoundToInt(transform.position.x);
        public int PositionY => Mathf.RoundToInt(transform.position.y);
    }
}
