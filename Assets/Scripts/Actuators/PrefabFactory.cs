﻿using UnityEngine;

namespace Actuators
{
    public class PrefabFactory : MonoBehaviour
    {
        [SerializeField] private GameObject pipePairPrefab;

        
        public GameObject CreatePipePair()
        {
            return CreatePipePair(Vector3.zero, Quaternion.identity, null);
        }
        
        public GameObject CreatePipePair(Vector3 position, Quaternion rotation, GameObject parent)
        {
            var pipePair = Instantiate(pipePairPrefab, position, rotation);
            if (parent != null) pipePair.transform.parent = parent.transform;
            return pipePair;
        }
    }
}