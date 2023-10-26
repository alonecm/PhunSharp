using Dex.Analysis.Parser;
using Dex.Common;
using System.Collections.Generic;

namespace PhunSharp.ArchiveSyntax
{
    /// <summary>
    /// 解析Phn
    /// </summary>
    internal sealed class ParsePhn
    {
        public ParsePhn(Container<ExtendableObject> objs)
        {
            Objs = objs;
        }

        public Container<ExtendableObject> Objs { get; }
    }
}
