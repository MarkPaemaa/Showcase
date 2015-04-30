﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SRP
{
    public class FormatConverter
    {
        private readonly DocumentStorage _documentStorage;
        private readonly InputParser _inputParser;
        private readonly DocumentSerializer _documentSerializer;

        public FormatConverter()
        {
            _documentStorage = new DocumentStorage();
            _inputParser = new InputParser();
            _documentSerializer = new DocumentSerializer();
        }

        public bool ConvertFormat(string sourceFileName, string targetFileName)
        {
            string input;
            try
            {
                input = _documentStorage.GetData(sourceFileName);
            }
            catch (FileNotFoundException)
            {
                return false;
            }

            var doc = _inputParser.ParseInput(input);
            var serializedDoc = _documentSerializer.Serialize(doc);

            try 
            {
                _documentStorage.PersistDocument(serializedDoc, targetFileName);
            }
            catch (AccessViolationException)
            {
                return false;
            }
            return true;
        }
    }
}
