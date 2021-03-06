﻿using Microsoft.Extensions.Configuration;
using ow.Framework.IO.File;
using System.IO;

namespace ow.Framework.IO.File
{
    public abstract class VisionDataFile : VisionZipFile
    {
        protected VisionDataFile(IConfiguration configuration, byte fileId) :
            base(Path.Join(configuration["Game:Dir"], "datas", $"data{fileId}.v"), configuration[$"Game:Datas:Passwords:Data{fileId}"])
        { }
    }
}
