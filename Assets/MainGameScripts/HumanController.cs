using UnityEngine;

namespace MainGameScripts
{
    public class HumanController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }
}
