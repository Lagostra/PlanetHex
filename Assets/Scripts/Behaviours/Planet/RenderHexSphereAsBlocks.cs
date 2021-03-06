using System.Collections.Generic;
using System.Linq;

using Extensions;

using PlanetGeneration;

using Rendering;

using UnityEngine;
using UnityEngine.Serialization;

namespace Behaviours.Planet
{
    public class RenderHexSphereAsBlocks : MonoBehaviour
    {
        public List<Material> blockMaterials;
        public float sphereRadius = 100;
        public float blockHeight = 10;

        public void Start()
        {
            var hexSphere = new HexSphereGenerator(sphereRadius, 16).Generate();

            foreach (var (region, regionIndex) in hexSphere.Regions.WithIndex())
            foreach (var tile in region.Tiles)
            {
                var materialIndex = regionIndex % blockMaterials.Count;
                var material = blockMaterials[materialIndex];
                for (var i = 0; i < Random.Range(1, 5); i++)
                {
                    var block = BlockGameObjectFactory.Create(tile, sphereRadius + i * blockHeight, material,
                        blockHeight);
                    block.transform.parent = transform;
                }
            }
        }
    }
}
