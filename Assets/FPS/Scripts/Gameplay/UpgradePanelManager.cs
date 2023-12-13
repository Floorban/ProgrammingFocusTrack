using UnityEngine;
using UnityEngine.EventSystems;
namespace Unity.FPS.UI
{
    public class UpgradePanelManager : MonoBehaviour
    {
        [SerializeField] GameObject panel;
        public void OpenPanel()
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        public void ClosePanel()
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
          
            Debug.Log("sad");
        }

    }

}