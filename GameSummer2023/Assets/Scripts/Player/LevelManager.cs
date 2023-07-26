using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] float delayTime = 1.5f;

    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] GameObject player;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] GameObject victoryParticle;

    int currentSceneIndex;
    int nextSceneIndex;
    bool isTransitioning = false;

    void Update() {
        if (isTransitioning) {
            return;
        }
        DebugKeys();
        CheckPlayerStatus();
    }
    void DebugKeys() {
        if (Input.GetKey(KeyCode.R)) {
            ReloadLevel();
        }
    }

    public bool IsTransitioning() {
        return isTransitioning;
    }

    private void CheckPlayerStatus() {
        if (playerStatus.CurrentHealthPoint() == 0) {
            isTransitioning = true;
            Instantiate(explosionParticle, player.transform.position, player.transform.rotation);
            player.SetActive(false);
            StartCoroutine(ReloadLevelRoutine());
        }
        if (playerStatus.CurrentAchievedObjective() == playerStatus.MaxObjective()) {
            isTransitioning = true;
            Instantiate(victoryParticle, player.transform.position, player.transform.rotation);
            StartCoroutine(LoadNextLevelRoutine());
        }
    }

    IEnumerator ReloadLevelRoutine() {
        yield return new WaitForSeconds(delayTime);
        ReloadLevel();
    } 
    IEnumerator LoadNextLevelRoutine() {
        yield return new WaitForSeconds(delayTime);
        LoadNextLevel();
    }

    private void ReloadLevel() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    private void LoadNextLevel() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}