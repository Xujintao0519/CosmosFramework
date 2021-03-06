﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
namespace Cosmos.Data
{
    /// <summary>
    /// 数据处理类;
    /// 解析、输出、编辑;
    ///处理类型： XML、 JSON、UnityPlayerPrefs
    ///XMLOperator
    /// </summary>
    public class DataProcess
    {
        #region Josn
        /// <summary>
        /// 解析Json
        /// </summary>
        /// <param name="callBack">回调函数，自定义解析Json</param>
        public void ParseJosn<T>(TextAsset ta, CFAction<T> callBack)
        {
            string jsonStr = ta.text;
            T jsonObj =JsonUtility.FromJson<T>(jsonStr);
            if (callBack != null)
                callBack(jsonObj);
        }
        /// <summary>
        /// 创建一个空的Json文件
        /// 如果有就删除旧的，没有就创建一个新的
        /// </summary>
        /// <param name="jsonFullPath">传入完整路径</param>
        public void CreateEmptyJson(string jsonFullPath)
        {
            if (File.Exists(jsonFullPath))
            {
                File.Delete(jsonFullPath);
            }
            FileStream fileStream = new FileStream(jsonFullPath,
                     FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("EmptyJsonFile");
            streamWriter.Close();
            fileStream.Close();
            fileStream.Dispose();
        }
        public void EditJson<T>(CFAction<T>callBack)
        {

        }
        public void SaveJson()
        {

        }
        #endregion
        #region Xml
        public void ParseXml(TextAsset ta, CFAction<XmlDocument> callBack)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ta.text);
            callBack(xmlDoc);
        }
        /// <summary>
        /// 创建一个新的Xml
        /// 如果有就删除旧的，没有就创建一个新的
        /// </summary>
        /// <param name="xmlFullPath">传入完整的路径</param>
        public XmlDocument CreateEmptyXml(string xmlFullPath)
        {
            if (!File.Exists(xmlFullPath))
            {
                File.Delete(xmlFullPath);
            }
            XmlDocument xml = new XmlDocument();
            XmlDeclaration xmlDel = xml.CreateXmlDeclaration("1.0", "UTF-8", "");
            xml.AppendChild(xmlDel);
            xml.Save(xmlFullPath);
            return xml;
        }
        public void EditXml()
        {

        }
        public void SaveXml() { }
        #endregion
    }
}