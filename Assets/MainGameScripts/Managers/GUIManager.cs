using UnityEngine;

namespace MainSceneScripts
{
    public class GUIManager : MonoBehaviour
    {
        public GameObject[] Images;
        private bool isShowed;

        public void ShowHelp()
        {
            foreach (var image in Images)
            {
                image.SetActive(!isShowed);
            }

            isShowed = !isShowed;
        }
    }
}