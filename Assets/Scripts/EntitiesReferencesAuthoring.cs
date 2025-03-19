using Unity.Entities;
using UnityEngine;

public class EntitiesReferencesAuthoring : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public class Baker : Baker<EntitiesReferencesAuthoring>
    {
        public override void Bake(EntitiesReferencesAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new EntitiesReferences{
                cubeEntity = GetEntity(authoring.cubePrefab, TransformUsageFlags.Dynamic),
                sphereEntity = GetEntity(authoring.spherePrefab, TransformUsageFlags.Dynamic)
            });
        }
    }
}

public struct EntitiesReferences : IComponentData
{
    public Entity cubeEntity;
    public Entity sphereEntity;
}