using UnityEngine;
using System;
using System.Collections.Generic;

namespace GameResources
{

    public enum ResourceType { Early, Mid, Late, Damage };


    public static class ResourceTypeMethods
    {
        public static string String(this ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Early:
                    return "E";
                case ResourceType.Mid:
                    return "M";
                case ResourceType.Late:
                    return "L";
                case ResourceType.Damage:
                    return "D";
                default:
                    throw new Exception("Unhandled resource type");
            }
        }
    }


    
    public class ResourcePool : MonoBehaviour
    {

        public static ResourcePool gPool;

        [SerializeField]
        private Dictionary<ResourceType,int> BaseResourceNumber = new Dictionary<ResourceType, int>{
            {ResourceType.Early, 0 },
            {ResourceType.Mid, 0 },
            {ResourceType.Late, 0 },
            { ResourceType.Damage, 0}
            };

        public Dictionary<ResourceType, int> Resources = new Dictionary<ResourceType, int>
        {
            {ResourceType.Early, 0 },
            {ResourceType.Mid, 0 },
            {ResourceType.Late, 0 },
            { ResourceType.Damage, 0}
        };

        public ResourcePool()
        {
            gPool = this;
        }

        public void Start()
        {
           var pool =  gPool ?? throw new Exception("gPool is null");
        }

        public void Shift(ResourceType type, int n)
        {
            Resources[type] += n;
        }

        public void Reset()
        {
            Opponent.gOpponent.DealDamage(Resources[ResourceType.Damage]);
            foreach (var i in BaseResourceNumber.Keys)
            {
                Resources[i] = BaseResourceNumber[i];   
            }
        }
    }
}
