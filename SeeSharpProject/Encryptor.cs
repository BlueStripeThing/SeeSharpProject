using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;



namespace SeeSharpProject
{
    public class Encryptor
    {
        //Зашифровка
        public string Encrypt(string message, string key)
        {
            char[] alpha = new char[] {'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
                                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
                                                'э', 'ю', 'я'};
            string result = "";
            int keyword_index = 0;
            bool register = false;

                foreach (char symbol in message)
                {

                    if (alpha.Contains(char.ToLower(symbol)))
                    {
                        if (char.IsUpper(symbol)) register = true;
                        int p = (Array.IndexOf(alpha, char.ToLower(symbol)) +
                            Array.IndexOf(alpha, key[keyword_index])) % alpha.Length;

                        if (register)
                            result += char.ToUpper(alpha[p]);
                        else result += alpha[p];

                        keyword_index++;

                        if (keyword_index == key.Length)
                            keyword_index = 0;
                        register = false;
                    }
                    else { result += symbol; }
                }
            
            return result;
        }

        //Расшифровка
        public string Decrypt(string message, string key)
        {
            char[] alpha = new char[] {'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
                                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
                                                'э', 'ю', 'я'};
            string result = "";
            int keyword_index = 0;
            bool register = false;

            foreach (char symbol in message)
            {
                if (alpha.Contains(char.ToLower(symbol)))
                {
                    if (char.IsUpper(symbol)) register = true;
                    int p = (Array.IndexOf(alpha, char.ToLower(symbol)) + alpha.Length -
                        Array.IndexOf(alpha, key[keyword_index])) % alpha.Length;

                    if (register)
                        result += char.ToUpper(alpha[p]);
                    else result += alpha[p];

                    keyword_index++;

                    if (keyword_index == key.Length)
                        keyword_index = 0;
                    register = false;
                }
                else { result += symbol; }
            }
            return result;
        }

        //Загрузка теста из файлов txt или docx/doc
        public string LoadFile(string path)
        {
            string result = "";
            if (path != "" && path.Contains('\\'))
            {
                //Загрузка из docx/doc
                if (path.Substring(path.IndexOf('.')) == ".docx" || path.Substring(path.IndexOf('.')) == ".doc")
                {
                    if (File.Exists(path))
                    {
                        object FileName = path;
                        object rOnly = true;
                        object SaveChanges = false;
                        object MissingObj = System.Reflection.Missing.Value;

                        Word.Application app = new Word.Application();
                        Word.Document doc = null;
                        Word.Range range = null;
                        try
                        {
                            doc = app.Documents.Open(ref FileName, ref MissingObj, ref rOnly, ref MissingObj,
                            ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj,
                            ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj,
                            ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj);

                            object StartPosition = 0;
                            object EndPositiojn = doc.Characters.Count;
                            range = doc.Range(ref StartPosition, ref EndPositiojn);
                            string MainText = (range == null || range.Text == null) ? null : range.Text;
                            if (MainText != null)
                            {
                                result = MainText;
                            }
                        }
                        catch (Exception ex)
                        {
                            result = ex.Message;
                        }
                        finally
                        {
                            if (doc != null)
                            {
                                doc.Close(ref SaveChanges);
                            }
                            if (range != null)
                            {
                                Marshal.ReleaseComObject(range);
                                range = null;
                            }
                            if (app != null)
                            {
                                app.Quit();
                                Marshal.ReleaseComObject(app);
                                app = null;
                            }
                        }
                    }

                }
                // Загрузка из txt
                else
                {
                    string line = Encoding.Default.GetString(File.ReadAllBytes(path));
                    result = line;
                }

            }
            return result;

        }
        
        //Сохранение файла в txt и docx
        public string SaveFile(string path, string message)
        {
            //сохранение в docx с выбором пути через проводник
            if (path.Substring(path.IndexOf('.')) == ".docx" || path.Substring(path.IndexOf('.')) == ".doc")
            {
                Word.Application app = new Word.Application();
                Word.Document doc = app.Documents.Add();
                doc.Paragraphs[1].Range.Text = message;

                doc.Close();

            }
            //сохранение в txt по пути из приложения
            else
            {
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(message);
                    fstream.Write(array, 0, array.Length);
                }
            }
            return "Файл успешо записан";
        }

    }

}