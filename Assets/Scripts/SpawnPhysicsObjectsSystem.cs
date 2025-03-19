using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

[BurstCompile]
public partial struct SpawnPhysicsObjectsSystem : ISystem
{
    private Random _random;
    private bool _hasSpawned;

    public void OnCreate(ref SystemState state)
    {
        _random = new Random(12345); // Fixed seed for deterministic physics
         state.RequireForUpdate<EntitiesReferences>();
    }

    public void OnUpdate(ref SystemState state)
    {
        if (_hasSpawned) return;

        var entitiesReferences = SystemAPI.GetSingleton<EntitiesReferences>();

        for (int i = 0; i < 100; i++) // Spawn 10 of each
        {
            //if i is even, use cube, otherwise use sphere
            var entityRef = i % 2 == 0 ? entitiesReferences.cubeEntity : entitiesReferences.sphereEntity;
            var instantiatedEntity = state.EntityManager.Instantiate(entityRef);
            SystemAPI.SetComponent(instantiatedEntity, new LocalTransform{
                Position = new float3(_random.NextFloat(-5f, 5f), _random.NextFloat(5f, 10f), _random.NextFloat(-5f, 5f)),
                Rotation = quaternion.RotateY(_random.NextFloat(0, 360)),
                Scale = 1f
            });
        }
        
        _hasSpawned = true;
    }
}
