using Unity.Entities;
using UnityEngine;

public class PhysicsPrefabAuthoring : MonoBehaviour
{
    public class Baker : Baker<PhysicsPrefabAuthoring>
    {
        public override void Bake(PhysicsPrefabAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new PhysicsPrefab());
        }
    }

}

public struct PhysicsPrefab : IComponentData { 
}
