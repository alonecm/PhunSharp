using Dex.Analysis.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhunSharp.ArchiveSyntax
{
    internal static class AnalyzUtils
    {
        /// <summary>
        /// 分析内容
        /// </summary>
        /// <param name="content"></param>
        internal static Dictionary<string, object> AnalyzeContent(this CharStream cs)
        {
            var dic = new Dictionary<string, object>();
            //解析所有内容
            var itemName = new StringBuilder();
            while (!cs.IsEnd())
            {
                //先记录名称
                itemName.Append(cs.Next());
                //如果是直接赋值号则读入
                if (cs.Current == '=')
                {
                    cs.Next();
                    var name = itemName.ToString();
                    if (!dic.ContainsKey(name))
                    {
                        dic.Add(name, AnalyzeValue(cs));
                    }
                    itemName.Clear();
                }
                //检测当前是否是:=，是则读取值
                else if (cs.Current == ':' && cs.Peek(1) == '=')
                {
                    //跳过这俩东西
                    cs.Next();
                    cs.Next();
                    dic.Add(itemName.ToString(), AnalyzeValue(cs));
                    itemName.Clear();
                }
            }
            return dic;
        }
        /// <summary>
        /// 分析值
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        private static string AnalyzeValue(CharStream cs)
        {
            var stack = new Stack<char>();
            var itemValue = new StringBuilder();
            while (!cs.IsEnd())
            {
                //如果是大括号则进入栈记录状态
                if (cs.Current == '{')
                {
                    var b_start = cs.Next();
                    itemValue.Append(b_start);
                    stack.Push(b_start);
                }
                else if (cs.Current == '}')
                {
                    var b_end = cs.Next();
                    itemValue.Append(b_end);
                    stack.Pop();
                }
                //如果栈中不存在括号并且是结束分号
                else if (stack.Count == 0 && cs.Current == ';')
                {
                    cs.Next();
                    break;
                }
                else
                {
                    //先记录名称
                    itemValue.Append(cs.Next());
                }
            }
            return itemValue.ToString();
        }
    }
}
