

 

using System;
using System.Collections.Generic;
using System.Linq;

public class CsvReader
{
    public static Dictionary<string, object> toObjectsDictionary(string[] cells, IDataTable metadata)
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();
        IColumnMetaData[] metadatas = metadata.GetColumnMetaDataArray();
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = cells[i].Replace("\r", "").Replace("\t", "").Replace("\n", "");
            string textValue = cells[i];
            string requiredType = metadatas[i].GetTypeName();
            //Api.Utils.Info(requiredType+" <= "+textValue);
            switch (metadatas[i].GetTypeName())
            {
                case "date":
                    if (cells[i] == "NULL")
                    {
                        dic[metadatas[i].name] = null;
                    }
                    else
                    {
                        dic[metadatas[i].name] = cells[i].ToString().ToDate();
                    }
                    break;
                case "datetime":
                    if (cells[i] == "NULL")
                    {
                        dic[metadatas[i].name] = null;
                    }
                    else
                    {
                        dic[metadatas[i].name] = cells[i].ToString().ToDate();
                    }
                    break;
                case "smallint":
                case "int":
                    if (cells[i] == "NULL")
                    {
                        dic[metadatas[i].name] = null;
                    }
                    else
                    {
                        dic[metadatas[i].name] = int.Parse(cells[i]);
                    }
                    break;
                case "nvarchar":
                case "text":
                case "varchar":
                    dic[metadatas[i].name] = cells[i];
                    break;
                case "float":
                    if (cells[i] == "NULL")
                    {
                        dic[metadatas[i].name] = null;
                    }
                    else
                    {
                        dic[metadatas[i].name] = float.Parse(cells[i].Replace(".", ","));
                    }
                    break;
                default: throw new Exception("Тип данных " + metadatas[i].GetTypeName() + " пока не поддерживается");
            }
        }
        return dic;
    }

    public static List<Dictionary<string, object>> Parse(string filename, IDataTable metadata)
    {
        string text = System.IO.File.ReadAllText(filename);
        List<Dictionary<string, object>> values = new List<Dictionary<string, object>>();
        List<string[]> textValues = Parse(text, metadata.Properties.Count);
        int rowNumber = 1;
        foreach(string[] rowTexts in textValues)
        {
            try
            {
                
                Dictionary<string, object> objects = toObjectsDictionary(rowTexts, metadata);
                values.Add(objects);
                rowNumber++;
            }
            catch(Exception ex)
            {
                Api.Utils.Info("Исключение строки № "+ rowNumber);
                Api.Utils.Info(ex);
                throw;
            }
        }
        //Api.Utils.Info(new { cells = textValues });
        return values;
    }

    public static List<string[]> Parse(string csvText, int columnsCount)
    {
        List<string[]> rows = new List<string[]>();
        int rowNumber = 1;
        foreach (string line in csvText.Trim('\n').Split("\n"))
        {
            try
            {
                string[] cells = parseLine(line.Replace("\r", "").Replace("\n", "").Replace("\t", "") + '\n');

                rows.Add(cells);
                if (cells.Length != columnsCount)
                {
                    throw new System.Exception("В строке № " + rowNumber + " количество элементов не соответвует требуемому кол-ву");
                }
                rowNumber++;
            }
            catch(Exception ex)
            {
                Api.Utils.Info("Ошибка в строке "+rowNumber+" "+ex.Message);
                continue;
            }
        }
        return rows;
    }

    private static string[] parseLine(string line)
    {
        List<string> values = new List<string>();

        string currentValue = "";
        bool firstLetter = true;
        bool comasOpened = false;

        //103,"Atelier graphique","Schmitt","Carine ","40.32.2555","54, rue Royale",NULL,"Nantes",NULL,"44000","France",1370,21000.00
        //1002,"Murphy","Diane","x5800","dmurphy@classicmodelcars.com","1",NULL,"President"
        for (int i=0; i< line.Length; i++)
        {
            //Api.Utils.Info($"\n{i})[{currentValue}]" + line.Substring(0, i), values.ToArray());
            if ( firstLetter )
            {
                firstLetter = false;
                if (line[i] == '"')
                {
                    comasOpened = true;                    
                    continue;
                }                
            }
            if( comasOpened )
            {
                if (line[i] == '"')
                {
                    values.Add(currentValue);
                    currentValue = "";
                    comasOpened = false;
                    firstLetter = true;

                    if (i < (line.Length - 1))
                    {
                        if(line[i+1] != ',' && line[i + 1] != '\n')
                        {
                            
                            throw new Exception("Следующий символ должен быть ,");
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                else
                {
                    currentValue += line[i];
                }
            }
            else
            {
                if (line[i] == ',' || line[i] == '\n')
                {
                    values.Add(currentValue);
                    currentValue = "";
                    firstLetter = true;
                }
                else
                {
                    currentValue += line[i];
                }
            }
            
        }
        return values.ToArray();
    }



     



}