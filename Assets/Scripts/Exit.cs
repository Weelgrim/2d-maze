using UnityEngine;
public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject _win;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Win();
        }
    }

    void Win()
    {
        _win.SetActive(true);
    }
}
