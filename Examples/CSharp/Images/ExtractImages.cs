using System.IO;
using Aspose.Note;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace Aspose.Note.Examples.CSharp.Images
{
    public class ExtractImages
    {
        public static void Run()
        {
            try
            {
                // ExStart:ExtractImages
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir_Images();

                // Load the document into Aspose.Note.
                Document oneFile = new Document(dataDir + "Aspose.one");

                // Get all Image nodes
                IList<Aspose.Note.Image> nodes = oneFile.GetChildNodes<Aspose.Note.Image>();

                foreach (Aspose.Note.Image image in nodes)
                {
                    using (MemoryStream stream = new MemoryStream(image.Bytes))
                    {
                        using (Bitmap bitMap = new Bitmap(stream))
                        {
                            // Save image bytes to a file
                            bitMap.Save(String.Format(dataDir + "{0}", Path.GetFileName(image.FileName)));
                        }
                    }
                }
                // ExEnd:ExtractImages 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}