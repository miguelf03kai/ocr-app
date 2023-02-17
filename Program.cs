using System;
using System.Diagnostics;
using Tesseract;

namespace OCR_text
{
    public class Program
    {
        Interator interator = new Interator();
        public static void Main(String[] args){
            var testImagePath = "images/comprovante_dep_sito_banc_rio.jpeg";

            if (args.Length > 0)
            {
                testImagePath = args[0];
            }
            
            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", "por", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            Console.WriteLine("Taxa de Precisão: {0}\n\n", page.GetMeanConfidence());
                            Console.WriteLine("{0}", text);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine("Erro Inesperado: " + e.Message);
                Console.WriteLine("Detalhes: ");
                Console.WriteLine(e.ToString());
            }

            interator.ComInteracao(testImagePath);

            Console.Write("Pressione qualquer tecla para continuar . . . ");
            Console.ReadKey(true);
        }
    }
}