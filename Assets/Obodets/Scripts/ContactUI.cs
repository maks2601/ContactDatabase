using TMPro;
using UnityEngine;

namespace Obodets.Scripts
{
    public class ContactUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;

        public void Initialize(string name, string surname)
        {
            nameText.text = name + " " + surname;
        }
    }
}
