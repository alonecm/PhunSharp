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
                var c = cs.Next();//当前值
                switch (c)
                {
                    case '='://设置项
                        var name = itemName.ToString();
                        var value = AnalyzeValue(cs);
                        //有则覆盖，没有则添加
                        if (!dic.ContainsKey(name))
                        {
                            dic.Add(name, value);
                        }
                        else
                        {
                            dic[name] = value;
                        }
                        itemName.Clear();
                        break;
                    case ':'://实体内部和全局变量
                        if (cs.Current == '=')
                        {
                            //跳过=当前
                            cs.Next();
                            name = itemName.ToString();
                            value = AnalyzeValue(cs);
                            dic.Add(name, value);
                            itemName.Clear();
                        }
                        break;
                    default:
                        //先记录名称
                        itemName.Append(c);
                        break;
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
            //分支栈
            var branchStack = new Stack<char>();
            var itemValue = new StringBuilder();
            while (!cs.IsEnd())
            {
                var c = cs.Next();
                switch (c)
                {
                    case '"':
                        //确保是真正的字符串
                        if (cs.Peek(-1) != '\\')
                        {
                            //检查如果栈顶也是字符串则弹出
                            if (branchStack.Count > 0 && branchStack.Peek() == '"')
                            {
                                branchStack.Pop();
                            }
                            else
                            {
                                branchStack.Push(c);
                            }
                        }
                        break;
                    case '{':
                    case '[':
                    case '(':
                        branchStack.Push(c);
                        break;
                    case '}':
                        if (branchStack.Peek()=='{')
                        {
                            branchStack.Pop();
                        }
                        break;
                    case ']':
                        if (branchStack.Peek() == '[')
                        {
                            branchStack.Pop();
                        }
                        break;
                    case ')':
                        if (branchStack.Peek() == '(')
                        {
                            branchStack.Pop();
                        }
                        break;
                    case ';':
                        if (branchStack.Count==0)
                        {
                            return itemValue.ToString();
                        }
                        break;
                    default:
                        break;
                }
                itemValue.Append(c);
            }
            return itemValue.ToString();
        }
    }
}
