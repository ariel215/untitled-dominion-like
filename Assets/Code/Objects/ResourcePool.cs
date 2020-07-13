using UnityEngine;
using System;

namespace GameResources
{

    public enum ResourceType { Early = 0, Mid=1, Late=2};

    public class ResourcePool : MonoBehaviour
    {

        public static ResourcePool gPool;

        [SerializeField]
        private int[] BaseResourceNumber = { 0, 0, 0 };

        public int[] Resources = { 0, 0, 0 };

        public ResourcePool()
        {
            gPool = this;
        }

        public void Start()
        {
           var pool =  gPool ?? throw new Exception("gPool is null");
        }

        public void Add(ResourceType type, int n)
        {
            Resources[(int) type] += n;
        }

        public void Reset()
        {
            foreach (var i in Enum.GetValues(typeof(ResourceType)))
            {
                Resources[(int)i] = BaseResourceNumber[(int)i];
            }
        }
    }
}
