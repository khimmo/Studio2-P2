using System.Threading.Tasks;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutor;

    private async void OnTriggerEnter(Collider other)
    {
        tutor.SetActive(true);
        await Task.Delay(10000);
        Destroy(tutor);
    }

}
