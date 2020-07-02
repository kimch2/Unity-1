using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ETModel
{
    public class Global
    {
        /// <summary>
        /// 记录所有加载过的场景 防止重复加载
        /// </summary>
        public static List<string> LoadSceneAssetsbundle = new List<string>();

        /// <summary>
        /// 记录打开项目的HotFix中的事件 避免调用多次
        /// </summary>
        public static List<string> HotFixEvent = new List<string>();

        /// <summary>
        /// 当前打开的项目名称
        /// </summary>
        public static string LoadProjectName { get; set; }


        /// <summary>
        /// 测试是否能够引用得到
        /// </summary>
        public static readonly string Test = "测试CLR绑定";

    }
}