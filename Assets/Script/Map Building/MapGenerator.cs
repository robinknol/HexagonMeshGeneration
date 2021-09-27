using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;
// ReSharper disable PossibleLossOfFraction

namespace Script.Map_Building
{
    public class MapGenerator : MonoBehaviour
    {
        private TileBase[] _pallets;
        [SerializeField] private Vector2Int size;

        private void Awake()
        {
            _pallets = Resources.LoadAll<TileBase>("Palettes");
            var main = Camera.main;
            
            if (main is { })
                main.transform.position = new Vector3(size.x / 2, size.y / 2, -5);

            Vector3Int[] positions = new Vector3Int[size.x * size.y];
            var tilemap = GetComponent<Tilemap>();

            for (var i = 0; i < positions.Length; i++)
            {
                positions[i] = new Vector3Int(i % size.x, i / size.y, 0);
                tilemap.SetTile(positions[i], _pallets[Random.Range(0, _pallets.Length)]);
            }
        }
    }
}
