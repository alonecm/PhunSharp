using Dex.Analysis.Parser;
using Dex.Common;
using System.Collections.Generic;
using System.Text;

namespace PhunSharp.ArchiveSyntax
{
    internal sealed class ArchiveParser
    {
        private Stack<char> branchStack;
        private CharStream stream;

        public ArchiveParser(string context)
        {
            stream = new CharStream(content: context);
            branchStack = new Stack<char>();//花括号栈
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <returns></returns>
        public ParsePhn Parse()
        {
            var nodes = new Container<ExtendableObject>();
            var varCollection = new Dictionary<string, object>();
            var sceneVarCollection = new Dictionary<string, object>();
            var sb = new StringBuilder();
            //先进行第一部分的解析然后分类
            while (!stream.IsEnd())
            {
                var c = stream.Next();
                switch (c)
                {
                    case '{'://块
                        var block = ParseBlock(c);
                        //合并
                        var str = sb.Append(block).ToString();
                        //解析
                        ParseObjectDef(nodes, str);
                        sb.Clear();
                        break;
                    case ':'://Scene.my变量
                        if (stream.Current == '=')
                        {
                            var name1 = sb.ToString();
                            stream.Next();
                            var value1 = ParseVariable();
                            //相同则覆盖，不同则添加
                            if (!sceneVarCollection.ContainsKey(name1))
                            {
                                sceneVarCollection.Add(name1, value1);
                            }
                            else
                            {
                                sceneVarCollection[name1] = value1;
                            }
                            sb.Clear();
                        }
                        break;
                    case '='://全局变量
                        var name2 = sb.ToString();//先记录名称
                        var value2 = ParseVariable();//再记录值
                        //相同则覆盖，不同则添加
                        if (!varCollection.ContainsKey(name2))
                        {
                            varCollection.Add(name2, value2);
                        }
                        else
                        {
                            varCollection[name2] = value2;
                        }
                        sb.Clear();
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            nodes.Add(new ParseVariables(varCollection));
            nodes.Add(new ParseSceneMyVars(sceneVarCollection));
            return new ParsePhn(nodes);
        }

        /// <summary>
        /// 解析定义并记录
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="sb"></param>
        private void ParseObjectDef(Container<ExtendableObject> nodes, string sb)
        {
            var declare = sb.Substring(0, sb.IndexOf("{"));
            if (declare.Contains("Scene.add"))
            {
                nodes.Add(new ParseObject(declare.Replace("Scene.add", ""), sb.Remove(0, sb.IndexOf("{"))));
            }
            else if (declare.Contains("Scene.set"))
            {
                nodes.Add(new ParseSet(declare.Replace("Scene.set", ""), sb.Remove(0, sb.IndexOf("{"))));
            }
            else if (declare.Contains("->"))
            {
                nodes.Add(new ParseSetting(declare.Replace("->", ""), sb.Remove(0, sb.IndexOf("{"))));
            }
        }

        /// <summary>
        /// 解析变量
        /// </summary>
        /// <returns></returns>
        private string ParseVariable()
        {
            var itemValue = new StringBuilder();
            while (!stream.IsEnd())
            {
                var c = stream.Next();
                switch (c)
                {
                    case '"':
                        //确保是真正的字符串
                        if (stream.Peek(-1) != '\\')
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
                        //只要前面没东西或者前面不是字符串开头才能开始分支
                        if (branchStack.Count == 0 || branchStack.Peek() != '"')
                        {
                            branchStack.Push(c);
                        }
                        break;
                    case '}':
                        if (branchStack.Peek() == '{')
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
                        if (branchStack.Count == 0)
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
        /// <summary>
        /// 解析块
        /// </summary>
        private string ParseBlock(char blockStart)
        {
            //解析到的是块，因为外部不能压栈，所以只能从这开始
            branchStack.Push(blockStart);
            var itemValue = new StringBuilder();
            itemValue.Append(blockStart);
            while (!stream.IsEnd())
            {
                var c = stream.Next();
                switch (c)
                {
                    case '"':
                        //确保是真正的字符串
                        if (stream.Peek(-1) != '\\')
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
                        //只要前面没东西或者前面不是字符串开头才能开始分支
                        if (branchStack.Count == 0 || branchStack.Peek() != '"')
                        {
                            branchStack.Push(c);
                        }
                        break;
                    case '}':
                        if (branchStack.Peek() == '{')
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
                        if (branchStack.Count == 0)
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
