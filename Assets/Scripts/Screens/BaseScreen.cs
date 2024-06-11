using UnityEngine;

namespace Screens
{
    public abstract class BaseScreen : MonoBehaviour
    {
        public abstract void Open();
        public abstract void Close();
    }
}