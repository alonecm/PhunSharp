using Dex.Analysis.Parser;
using Dex.Common;
using System.Collections.Generic;
using System.Text;

namespace PhunSharp.ArchiveSyntax
{
    public sealed partial class ArchiveAnalyzer
    {
        internal sealed class ArchiveParser : Parser<ParsePhn>
        {
            private Stack<string> branchStack = new Stack<string>();//花括号栈
            public ArchiveParser(LexicalResult lexicalResult) : base(lexicalResult)
            {
            }

            /// <summary>
            /// 解析
            /// </summary>
            /// <returns></returns>
            public override ParsePhn Parse()
            {
                var nodes = new Container<ExtendableObject>();
                var varCollection = new Dictionary<string, object>();
                var sb = new StringBuilder();
                //先进行第一部分的解析然后分类
                while (!IsEnd())
                {
                    sb.Append(Next().Value);
                    if (Current.Value == "{")
                    {
                        ParseObjectDef(nodes, sb.Append(ParseBlock()).ToString());
                        sb.Clear();
                    }
                    else if (Current.Value == ":" && Peek(1).Value=="=")
                    {
                        var name = sb.ToString();//先记录名称
                        Next();
                        Next();
                        var value = ParseVariable();//再记录值
                        varCollection.Add(name, value);
                        sb.Clear();
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
                while (!IsEnd())
                {
                    //记录并前进
                    switch (Current.Value)
                    {
                        case "(":
                        case "[":
                        case "{":
                            //开括号则入栈
                            sb.Append(Current.Value);
                            branchStack.Push(Next().Value);
                            break;
                        case "}"://闭括号则出栈
                            if (branchStack.Peek() == "{")
                            {
                                sb.Append(Next().Value);
                                branchStack.Pop();
                            }
                            break;
                        case "]"://闭括号则出栈
                            if (branchStack.Peek() == "[")
                            {
                                sb.Append(Next().Value);
                                branchStack.Pop();
                            }
                            break;
                        case ")"://闭括号则出栈
                            if (branchStack.Peek() == "(")
                            {
                                sb.Append(Next().Value);
                                branchStack.Pop();
                            }
                            break;
                        case ";":
                            //如果不存在括号了则证明这个分号在外面则直接跳过分号并结束读取
                            if (branchStack.Count==0)
                            {
                                Next();
                                return sb.ToString();
                            }
                            else
                            {
                                sb.Append(Next().Value);
                            }
                            break;
                        default:
                            if (Current.Type == "string")
                            {
                                sb.Append($"\"{Next().Value}\"");
                            }
                            else
                            {
                                sb.Append(Next().Value);
                            }
                            break;
                    }
                }
                return sb.ToString();
            }
            /// <summary>
            /// 解析块
            /// </summary>
            private string ParseBlock()
            {
                //优先压栈
                branchStack.Push(Current.Value);
                StringBuilder sb = new StringBuilder(Next().Value);
                //栈中为空则弹出
                while (!IsEnd() && branchStack.Count > 0)
                {
                    //记录并前进
                    switch (Current.Value)
                    {
                        //开括号则入栈
                        case "(":
                        case "[":
                        case "{":
                            sb.Append(Current.Value);
                            branchStack.Push(Next().Value);
                            break;
                        //闭括号则出栈
                        case "}":
                            if (branchStack.Peek()=="{")
                            {
                                sb.Append(Next().Value);
                                branchStack.Pop();
                            }
                            break;
                        case "]":
                            if (branchStack.Peek() == "[")
                            {
                                sb.Append(Next().Value);
                                branchStack.Pop();
                            }
                            break;
                        case ")":
                            if (branchStack.Peek() == "(")
                            {
                                sb.Append(Next().Value);
                                branchStack.Pop();
                            }
                            break;
                        default:
                            if (Current.Type=="string")
                            {
                                sb.Append($"\"{Next().Value}\"");
                            }
                            else
                            {
                                sb.Append(Next().Value);
                            }
                            break;
                    }
                }
                //如果有分号则向后移动一个跳过分号
                if (Current.Value==";")
                {
                    Next();
                }
                return sb.ToString();
            }
        }
    }
}
