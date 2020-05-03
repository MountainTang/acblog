﻿using AcBlog.Data.Models;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcBlog.Data.Repositories.FileSystem.Readers
{
    public class PostLocalReader : PostReaderBase
    {
        public PostLocalReader(string rootPath) : base(rootPath)
        {
        }

        public override Task<bool> Exists(string id)
        {
            return Task.FromResult(File.Exists(GetPostPath(id)));
        }

        protected override Task<Stream> GetFileReadStream(string path)
        {
            return Task.FromResult<Stream>(File.Open(path, FileMode.Open, FileAccess.Read));
        }
    }
}