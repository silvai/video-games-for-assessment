using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndRestorePosition : MonoBehaviour
{
    static bool indoors = true;

    void Start() // Check if we've saved a position for this scene; if so, go there.
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex))
        {
            transform.position = SavedPositionManager.savedPositions[sceneIndex];
        }
    }

    void OnDestroy() // Unloading scene, so save position.
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        var playerPosition = transform.position;
        
        if (indoors)
        {
            indoors = false;
            playerPosition.y = playerPosition.y + 1;
        } else
        {
            indoors = true;
            playerPosition.y = playerPosition.y - 1;
        }
        
        
        SavedPositionManager.savedPositions[sceneIndex] = playerPosition;
    }
}