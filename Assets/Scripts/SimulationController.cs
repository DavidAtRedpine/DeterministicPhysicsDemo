using Unity.Entities;
using Unity.Scenes;
using UnityEngine;
using UnityEngine.UI;

public class SimulationController : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton.enabled = true;
        startButton.onClick.AddListener(StartSimulation);


        // Get the default world
        var world = World.DefaultGameObjectInjectionWorld;
        // Get the specific ECS system you want to disable
        SystemHandle mySystem = world.GetExistingSystem<SpawnPhysicsObjectsSystem>();
        ref SystemState state = ref world.Unmanaged.ResolveSystemStateRef(mySystem); // REF USED HERE
        state.Enabled = false;
        
    }

    void StartSimulation()
    {
        startButton.enabled = false;
        //hide the button
        startButton.gameObject.SetActive(false);

        Debug.Log("✅ Loading Physics SubScene...");

        // Get the default world
        var world = World.DefaultGameObjectInjectionWorld;
        // Get the specific ECS system you want to disable
        SystemHandle mySystem = world.GetExistingSystem<SpawnPhysicsObjectsSystem>();
        ref SystemState state = ref world.Unmanaged.ResolveSystemStateRef(mySystem); // REF USED HERE
        state.Enabled = true;
    }
}
