using UnityEngine;

namespace Source.Scripts.Entities
{
    public class Tetromino : MonoBehaviour
    {
        [SerializeField] Vector2 _placementOffset;

        public Block[] Blocks { get; private set; }
        public Vector2 PlacementOffset => _placementOffset;

        void Start()
        {
            Blocks = GetComponentsInChildren<Block>();
        }
    }
}
