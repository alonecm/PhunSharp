using Dex.Analysis.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhunSharp.ArchiveSyntax
{
    /// <summary>
    /// 档案转换器
    /// </summary>
    internal sealed class ArchiveParser : Parser
    {
        public ArchiveParser(LexicalResult lexicalResult) : base(lexicalResult)
        {

        }

        public override SyntaxTree Parse()
        {
            throw new NotImplementedException();
        }
    }
}
