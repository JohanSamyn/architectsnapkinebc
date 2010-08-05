using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ebc.patterns;
using ebc.patterns.aspects;
using Indexer.ProcessModel.FilesystemAdapter;

namespace Indexer.ProcessModel.Composites
{
    public class Compile_files
    {
        private readonly Action<Tuple<string, string>> in_Process;


        public Compile_files(Crawl_directory_tree crawlDirTree)
        {
            var split = new Split<Tuple<string, string>, string, string>(
                t => t.Item1,
                t => t.Item2
                );

            var validatePath = new Validate<string>(
                Directory.Exists,
                path => string.Format("Diretory to be indexed not found: {0}", path)
                );

            this.in_Process = _ => split.Input(_);
            split.Output0 += validatePath.In_Validate;
            validatePath.Out_ValidData += crawlDirTree.In_Process;
            validatePath.Out_InvalidData += _ => this.Out_ValidationError(_);

            split.Output1 += _ => this.Out_IndexFilename(_);

            crawlDirTree.Out_FileFound += _ => this.Out_FileFound(_);
        }


        public void In_Process(Tuple<string, string> args)
        {
            this.in_Process(args);
        }


        public event Action<IEnumerable<string>> Out_FileFound;
        public event Action<string> Out_IndexFilename;
        public event Action<string> Out_ValidationError;
    }
}