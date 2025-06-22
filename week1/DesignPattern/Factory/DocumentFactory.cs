
using FactoryMethodPatternExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

