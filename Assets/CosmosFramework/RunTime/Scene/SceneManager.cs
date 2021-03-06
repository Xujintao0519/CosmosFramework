﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cosmos.Event;
namespace Cosmos.Scene{
    public sealed class SceneManager : Module<SceneManager>
    {
        /// <summary>
        /// 同步加载 name
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="callBack"></param>
        public void LoadScene(string sceneName,CFAction callBack=null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            callBack?.Invoke();
        }
        /// <summary>
        /// 同步加载 index
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <param name="callBack"></param>
        public void LoadScene(int sceneIndex,CFAction callBack=null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
            callBack?.Invoke();
        }
        /// <summary>
        /// 异步加载 name
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="callBack"></param>
        public void LoadSceneAsync(string sceneName, CFAction callBack=null)
        {
            Facade.Instance.StartCoroutine(EnumLoadSceneAsync(sceneName, callBack));
        }
        public void LoadSceneAsync(string sceneName, CFAction<float> callBack = null)
        {
            Facade.Instance.StartCoroutine(EnumLoadSceneAsync(sceneName, callBack));
        }
        public void LoadSceneAsync(string sceneName, CFAction<AsyncOperation> callBack = null)
        {
            Facade.Instance.StartCoroutine(EnumLoadSceneAsync(sceneName, callBack));
        }
        /// <summary>
        /// 异步加载 index
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <param name="callBack"></param>
        public void LoadSceneAsync(int sceneIndex, CFAction callBack=null)
        {
            Facade.Instance.StartCoroutine(EnumLoadSceneAsync(sceneIndex, callBack));
        }
        public void LoadSceneAsync(int sceneIndex, CFAction<float> callBack = null)
        {
            Facade.Instance.StartCoroutine(EnumLoadSceneAsync(sceneIndex, callBack));
        }
        public void LoadSceneAsync(int sceneIndex, CFAction<AsyncOperation> callBack = null)
        {
            Facade.Instance.StartCoroutine(EnumLoadSceneAsync(sceneIndex, callBack));
        }
        /// <summary>
        /// 异步加载迭代器 name
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="callBack"></param>
        /// <returns></returns>
        IEnumerator EnumLoadSceneAsync(string sceneName, CFAction callBack=null)
        {
            AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            while (!ao.isDone)
            {
                yield return ao.progress;
            }
            yield return ao.progress;
            callBack?.Invoke();
        }
        IEnumerator EnumLoadSceneAsync(string sceneName, CFAction<float> callBack = null)
        {
            AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            while (!ao.isDone)
            {
                callBack?.Invoke(ao.progress);
                yield return ao.progress;
            }
            yield return null;
        }
        IEnumerator EnumLoadSceneAsync(string sceneName, CFAction<AsyncOperation> callBack = null)
        {
            AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            while (!ao.isDone)
            {
                callBack?.Invoke(ao);
                yield return null;
                //yield return ao.progress;
            }
        }
        /// <summary>
        /// 异步加载迭代器 index
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <param name="callBack"></param>
        /// <returns></returns>
        IEnumerator EnumLoadSceneAsync(int sceneIndex, CFAction callBack=null)
        {
            AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
            while (!ao.isDone)
            {
                yield return ao.progress;
            }
            yield return ao.progress;
            callBack?.Invoke();
        }
        IEnumerator EnumLoadSceneAsync(int sceneIndex, CFAction<float> callBack = null)
        {
            AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
            while (!ao.isDone)
            {
                callBack?.Invoke(ao.progress);
                yield return null;
                //yield return ao.progress;
            }
            //yield return null;
        }
        IEnumerator EnumLoadSceneAsync(int sceneIndex, CFAction<AsyncOperation> callBack = null)
        {
            AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
            while (!ao.isDone)
            {
                callBack?.Invoke(ao);
                yield return null;
                //yield return ao.progress;
            }
            //yield return null;
        }
    }
}