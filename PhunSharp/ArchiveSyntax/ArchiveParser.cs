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
            stream = new CharStream(content: context, jumpComment: CommentRemover.DefaultRemover);
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
            var sb = new StringBuilder();
            //先进行第一部分的解析然后分类
            while (!stream.IsEnd())
            {
                var c = stream.Next();
                //是块
                if (c == '{')
                {
                    //优先压栈
                    branchStack.Push(c);
                    ParseObjectDef(nodes, sb.Append(c).Append(ParseBlock()).ToString());
                    sb.Clear();
                }
                //是变量
                else if (c == ':' && stream.Current == '=')
                {
                    var name = sb.ToString();//先记录名称
                    stream.Next();
                    var value = ParseVariable();//再记录值
                    varCollection.Add(name, value);
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }
            nodes.Add(new ParseVariables(varCollection));
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
            StringBuilder sb = new StringBuilder();
            while (!stream.IsEnd())
            {
                var c = stream.Next();
                //记录并前进
                switch (c)
                {
                    //开括号则入栈
                    case '(':
                    case '[':
                    case '{':
                        sb.Append(c);
                        branchStack.Push(c);
                        break;
                    //闭括号则出栈
                    case '}':
                        if (branchStack.Peek() == '{')
                        {
                            sb.Append(c);
                            branchStack.Pop();
                        }
                        break;
                    case ']':
                        if (branchStack.Peek() == '[')
                        {
                            sb.Append(c);
                            branchStack.Pop();
                        }
                        break;
                    case ')':
                        if (branchStack.Peek() == '(')
                        {
                            sb.Append(c);
                            branchStack.Pop();
                        }
                        break;
                    case ';':
                        //如果不存在括号了则证明这个分号在外面则直接跳过分号并结束读取
                        if (branchStack.Count == 0)
                        {
                            return sb.ToString();
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            stream.Next();
            return sb.ToString();
        }
        /// <summary>
        /// 解析块
        /// </summary>
        private string ParseBlock()
        {
            StringBuilder sb = new StringBuilder();
            //栈中为空则弹出
            while (!stream.IsEnd() && branchStack.Count > 0)
            {
                var c = stream.Next();
                //记录并前进
                switch (c)
                {
                    //开括号则入栈
                    case '(':
                    case '[':
                    case '{':
                        sb.Append(c);
                        branchStack.Push(c);
                        break;
                    //闭括号则出栈
                    case '}':
                        if (branchStack.Peek() == '{')
                        {
                            sb.Append(c);
                            branchStack.Pop();
                        }
                        break;
                    case ']':
                        if (branchStack.Peek() == '[')
                        {
                            sb.Append(c);
                            branchStack.Pop();
                        }
                        break;
                    case ')':
                        if (branchStack.Peek() == '(')
                        {
                            sb.Append(c);
                            branchStack.Pop();
                        }
                        break;
                    case ';':
                        sb.Append(c);
                        //如果不存在括号了则证明这个分号在外面则直接跳过分号并结束读取
                        if (branchStack.Count == 0)
                        {
                            return sb.ToString();
                        }
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            //略过结尾分号
            stream.Next();
            return sb.ToString();
        }
    }
}
