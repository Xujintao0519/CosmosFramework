﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;
namespace Cosmos.ObjectPool
{
    //对象池自动回收，用于非池注册对象回收
    // 由回收SpawnWithoutPool函数生成的对象
    public class ObjectSpawnPoolMemebr:MonoBehaviour
    {
        public void Despawn()
        {
            Facade.Instance.DespawnObject(null, this.gameObject);
        }
        public void Despawn(float delay)
        {
            var delayRoutine = Facade.Instance.DelayCoroutine(delay);
            Facade.Instance.StartCoroutine(delayRoutine, Despawn);
        }
    }
}