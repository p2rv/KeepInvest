using System;
using System.Collections.Generic;


namespace KeepInvest
{
    interface IFileService
    {
        List<ISecurities> Parse(string filename);
    }

    class FileService: IFileService
    {
        // TODO: реализвать парсинг файла 
        public List<ISecurities> Parse(string filename)
        {
            return new List<ISecurities>();
        }
    }
}
