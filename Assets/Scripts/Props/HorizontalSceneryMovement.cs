using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Props
{
    public class HorizontalSceneryMovement : MonoBehaviour
    {
        [Header("Visuals")] [SerializeField] private Sprite sprite;
        [SerializeField, Range(0, 10)] private uint nbTiles = 3;
        [SerializeField] private string sortingLayerName;

        [Header("Behaviour")] [SerializeField] private float speed = 0.3f;

        private Vector2 tileSize;
        private Vector3 initialPosition;
        private float currentOffset;

        private void Start()
        {
            tileSize = sprite.bounds.size;
            for (uint i = 0; i < nbTiles; i++)
            {
                var tile = new GameObject(i.ToString());
                tile.transform.parent = transform;

                var spriteRenderer = tile.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;

                tile.transform.localPosition = tileSize.x * i * Vector3.right;
                spriteRenderer.sortingLayerName = sortingLayerName;
            }

            initialPosition = transform.position;
            currentOffset = 0;
        }

        private void Update()
        {
            //Current offset, calculated based on the time.
            currentOffset += speed * Time.deltaTime;
            currentOffset %= tileSize.x;

            transform.position = initialPosition + Vector3.left * currentOffset;
        }
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            var size = sprite == null ? Vector3.one : sprite.bounds.size;
            var center = transform.position;

            Gizmos.DrawWireCube(center, size);
        }
#endif
    }
}