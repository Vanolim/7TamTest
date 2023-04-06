using UnityEngine;
using Random = UnityEngine.Random;

namespace TapTest
{
    public class GameBoard : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider2D[] _spawnZones;

        public Vector2 GetRandomSpawnPoint()
        {
            BoxCollider2D collider = _spawnZones[Random.Range(0, _spawnZones.Length)];
            Bounds bounds = collider.bounds;
            Vector2 point = new Vector2(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y)
            );

            return point;
        }
    }
}