using UnityEngine;

namespace WorkshopSoft.Abnormal.Arch
{
    public class SyncSingleton : MonoBehaviour
    {
        protected static readonly object Lock = new();
    }
}