﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cosmos
{
    /// <summary>
    /// 继承自Mono下的事件处理基类
    /// 此类分装了事件派发的方法，派生类调用即可
    /// </summary>
    public abstract class MonoEventHandler : MonoBehaviour
    {
        private void Awake()
        {
            OnInitialization();
        }
        private void OnDestroy()
        {
            OnTermination();
        }
        /// <summary>
        /// Awake时候被调用，在此注册事件
        /// </summary>
        protected abstract void OnInitialization();
        /// <summary>
        /// Desotry时候被调用，
        /// 空的虚函数,在此注销事件
        /// </summary>
        protected virtual void OnTermination() { }
        protected virtual void OnValidate() { }
        /// <summary>
        /// 默认的标准事件处理者，
        /// 空的虚函数
        /// </summary>
        protected virtual void EventHandler(object sender, GameEventArgs args) { }
        protected void DispatchEvent(string eventKey,GameEventArgs args)
        {
            Facade.Instance.DispatchEvent(eventKey, this, args);
        }
        /// <summary>
        /// 注册事件，默认将EventHandler注册到事件中心
        /// 如果需要注册其他事件，则移步AddEventListener
        /// </summary>
        protected void AddDefaultEventListener(string eventKey)
        {
            Facade.Instance.AddEventListener(eventKey, EventHandler);
        }
        protected void AddEventListener(string eventKey,CFAction<object,GameEventArgs> handler)
        {
            Facade.Instance.AddEventListener(eventKey, handler);
        }
        /// <summary>
        /// 注销事件，默认将EventHandler从事件中心注销
        /// 如果需要注销其他事件，则移步RemoveEventListener
        /// </summary>
        protected void RemoveDefaultEventListener(string eventKey)
        {
            Facade.Instance.RemoveEventListener(eventKey, EventHandler);
        }
        protected void RemoveEventListener(string eventKey,CFAction<object ,GameEventArgs>handler)
        {
            Facade.Instance.RemoveEventListener(eventKey, handler);
        }
    }
}