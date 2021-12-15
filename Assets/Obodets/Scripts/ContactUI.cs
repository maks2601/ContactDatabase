using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Obodets.Scripts
{
    public class ContactUI : MonoBehaviour
    {
        [SerializeField] private Button contactButton;
        [SerializeField] private TextMeshProUGUI nameText;

        private void ContactButtonAddListener(UnityAction listener) => contactButton.onClick.AddListener(listener); 
        
        public void Initialize(string name, string surname, UnityAction contactButtonListener)
        {
            nameText.text = name + " " + surname;
            ContactButtonAddListener(contactButtonListener);
        }
    }
}
