using UnityEngine;

namespace Screens
{
    public abstract class BaseScreen : MonoBehaviour
    {
        [SerializeField] private Header _header;

        public Header Header => _header;
        
        public abstract void Open();
        public abstract void Close();
    }
}