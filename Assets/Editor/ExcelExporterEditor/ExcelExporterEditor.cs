using ETModel;
using MongoDB.Bson;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public struct CellInfo
{
    public string Type;
    public string Name;
    public string Desc;
}

public class ExcelMD5Info
{
    public Dictionary<string, string> fileMD5 = new Dictionary<string, string>();

    public string Get(string fileName)
    {
        string md5 = "";
        this.fileMD5.TryGetValue(fileName, out md5);
        return md5;
    }

    public void Add(string fileName, string md5)
    {
        this.fileMD5[fileName] = md5;
    }
}

public class ExcelExporterEditor : EditorWindow
{
    [MenuItem("Tools/导出配置")]
    private static void ShowWindow()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo("./Assets/AddressableAssets/Config/");
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        GetWindow(typeof(ExcelExporterEditor));
    }

    private const string ExcelPath = "../Excel";
    private const string ServerConfigPath = "../Config/";

    private bool isClient;

    private ExcelMD5Info md5Info;

    // Update is called once per frame
    private void OnGUI()
    {
        try
        {
            const string clientPath = "./Assets/AddressableAssets/Config";

            if (GUILayout.Button("导出客户端配置"))
            {
                this.isClient = true;

                ExportAll(clientPath);

                CreateDirectory();

                ExportAllClass(@"./Assets/Model/Module/Demo/Config", "namespace ETModel\n{\n");
                ExportAllClass(@"./Assets/Hotfix/Module/Demo/Config", "using ETModel;\n\nnamespace ETHotfix\n{\n");

                Log.Info($"导出客户端配置完成!");
            }

            if (GUILayout.Button("导出服务端配置"))
            {
                this.isClient = false;

                ExportAll(ServerConfigPath);

                ExportAllClass(@"../Server/Model/Module/Demo/Config", "namespace ETModel\n{\n");

                Log.Info($"导出服务端配置完成!");
            }
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
    }

    private void CreateDirectory()
    {
        if (!Directory.Exists(@"./Assets/Model/Module/Demo/Config"))
        {
            Directory.CreateDirectory(@"./Assets/Model/Module/Demo/Config");
        }
        if (!Directory.Exists(@"./Assets/Hotfix/Module/Demo/Config"))
        {
            Directory.CreateDirectory(@"./Assets/Hotfix/Module/Demo/Config");
        }
    }

    private void ExportAllClass(string exportDir, string csHead)
    {
        foreach (string filePath in Directory.GetFiles(ExcelPath))
        {
            if (Path.GetExtension(filePath) != ".xlsx")
            {
                continue;
            }
            if (Path.GetFileName(filePath).StartsWith("~"))
            {
                continue;
            }
            if (!Path.GetFileNameWithoutExtension(filePath).Contains("Config"))
            {
                continue;
            }

            ExportClass(filePath, exportDir, csHead);
            Log.Info($"生成{Path.GetFileName(filePath)}类");
        }
        AssetDatabase.Refresh();
    }

    private void ExportClass(string fileName, string exportDir, string csHead)
    {
        XSSFWorkbook xssfWorkbook;
        using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            xssfWorkbook = new XSSFWorkbook(file);
        }

        string protoName = Path.GetFileNameWithoutExtension(fileName);

        string exportPath = Path.Combine(exportDir, $"{protoName}.cs");
        using (FileStream txt = new FileStream(exportPath, FileMode.Create))
        using (StreamWriter sw = new StreamWriter(txt))
        {
            StringBuilder sb = new StringBuilder();
            ISheet sheet = xssfWorkbook.GetSheetAt(0);
            sb.Append(csHead);

            sb.Append($"\t[Config((int)({GetCellString(sheet, 0, 0)}))]\n");
            sb.Append($"\tpublic partial class {protoName}Category : AddressableCategory<{protoName}>\n");
            sb.Append("\t{\n");
            sb.Append("\t}\n\n");

            sb.Append($"\tpublic class {protoName}: IConfig\n");
            sb.Append("\t{\n");
            sb.Append("\t\tpublic long Id { get; set; }\n");

            int cellCount = sheet.GetRow(3).LastCellNum;

            for (int i = 2; i < cellCount; i++)
            {
                string fieldDesc = GetCellString(sheet, 2, i);

                if (fieldDesc.StartsWith("#"))
                {
                    continue;
                }

                // s开头表示这个字段是服务端专用
                if (fieldDesc.StartsWith("s") && this.isClient)
                {
                    continue;
                }

                string fieldName = GetCellString(sheet, 3, i);

                if (fieldName == "Id" || fieldName == "_id")
                {
                    continue;
                }

                string fieldType = GetCellString(sheet, 4, i);
                if (fieldType == "" || fieldName == "")
                {
                    continue;
                }

                sb.Append($"\t\tpublic {fieldType} {fieldName};\n");
            }

            sb.Append("\t}\n");
            sb.Append("}\n");

            sw.Write(sb.ToString());
        }
    }

    private void ExportAll(string exportDir)
    {
        string md5File = Path.Combine(ExcelPath, "md5.txt");
        if (!File.Exists(md5File))
        {
            this.md5Info = new ExcelMD5Info();
        }
        else
        {
            this.md5Info = MongoHelper.FromJson<ExcelMD5Info>(File.ReadAllText(md5File));
        }
        string[] files = Directory.GetFiles(ExcelPath);

        foreach (string filePath in files)
        {
            if (Path.GetExtension(filePath) != ".xlsx")
            {
                continue;
            }
            if (Path.GetFileName(filePath).StartsWith("~"))
            {
                continue;
            }
            if (!Path.GetFileNameWithoutExtension(filePath).Contains("Config"))
            {
                continue;
            }
            string fileName = Path.GetFileName(filePath);
            string oldMD5 = this.md5Info.Get(fileName);
            string md5 = MD5Helper.FileMD5(filePath);
            this.md5Info.Add(fileName, md5);
            //if (md5 == oldMD5)
            //{
            //    continue;
            //}

            Export(filePath, exportDir);
        }

        File.WriteAllText(md5File, this.md5Info.ToJson());

        Log.Info("所有表导表完成");
        AssetDatabase.Refresh();
    }

    private void Export(string fileName, string exportDir)
    {
        XSSFWorkbook xssfWorkbook;
        IFormulaEvaluator formulaEvaluator;

        using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            xssfWorkbook = new XSSFWorkbook(file);
            formulaEvaluator = xssfWorkbook.GetCreationHelper().CreateFormulaEvaluator();
            Dictionary<string, IFormulaEvaluator> evaluators = new Dictionary<string, IFormulaEvaluator>
            {
                {Path.GetFileName(fileName),formulaEvaluator }
            };
            foreach (string linkedFileName in xssfWorkbook.ExternalLinksTable.Select(p => $"{ExcelPath}/{p.LinkedFileName}"))
            {
                XSSFWorkbook linkedWorkBook;
                using (FileStream linkedFile = new FileStream(linkedFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    linkedWorkBook = new XSSFWorkbook(linkedFile);
                }
                evaluators.Add(Path.GetFileName(linkedFileName), linkedWorkBook.GetCreationHelper().CreateFormulaEvaluator());
            }
            formulaEvaluator.SetupReferencedWorkbooks(evaluators);
        }
        string protoName = Path.GetFileNameWithoutExtension(fileName);
        Log.Info($"{protoName}导表开始");
        string exportPath = Path.Combine(exportDir, $"{protoName}.txt");
        using (FileStream txt = new FileStream(exportPath, FileMode.Create))
        using (StreamWriter sw = new StreamWriter(txt))
        {
            for (int i = 0; i < xssfWorkbook.NumberOfSheets; ++i)
            {
                ISheet sheet = xssfWorkbook.GetSheetAt(i);
                if (sheet.SheetName.StartsWith("~"))
                {
                    continue;
                }
                ExportSheet(sheet, sw, formulaEvaluator);
            }
        }
        Log.Info($"{protoName}导表完成");
    }

    private void ExportSheet(ISheet sheet, StreamWriter sw, IFormulaEvaluator formulaEvaluator)
    {
        int cellCount = sheet.GetRow(3).LastCellNum;

        CellInfo[] cellInfos = new CellInfo[cellCount];

        for (int i = 2; i < cellCount; i++)
        {
            string fieldDesc = GetCellString(sheet, 2, i);
            string fieldName = GetCellString(sheet, 3, i);
            string fieldType = GetCellString(sheet, 4, i);
            cellInfos[i] = new CellInfo() { Name = fieldName, Type = fieldType, Desc = fieldDesc };
        }

        for (int i = 5; i <= sheet.LastRowNum; ++i)
        {
            if (GetCellString(sheet, i, 2, formulaEvaluator) == "")
            {
                continue;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            IRow row = sheet.GetRow(i);
            for (int j = 2; j < cellCount; ++j)
            {
                string desc = cellInfos[j].Desc.ToLower();
                if (desc.StartsWith("#"))
                {
                    continue;
                }

                // s开头表示这个字段是服务端专用
                if (desc.StartsWith("s") && this.isClient)
                {
                    continue;
                }

                // c开头表示这个字段是客户端专用
                if (desc.StartsWith("c") && !this.isClient)
                {
                    continue;
                }

                string fieldValue = GetCellString(row, j, formulaEvaluator);
                //if (fieldValue == "")
                //{
                //    throw new Exception($"sheet: {sheet.SheetName} 中有空白字段 {GetCellPosition(i, j)}");
                //}

                if (j > 2)
                {
                    sb.Append(",");
                }

                string fieldName = cellInfos[j].Name;

                if (fieldName == "Id" || fieldName == "_id")
                {
                    if (this.isClient)
                    {
                        fieldName = "Id";
                    }
                    else
                    {
                        fieldName = "_id";
                    }
                }

                string fieldType = cellInfos[j].Type;
                sb.Append($"\"{fieldName}\":{Convert(fieldType, fieldValue)}");
            }
            sb.Append("}");
            sw.WriteLine(sb.ToString());
        }
    }

    private static string Convert(string type, string value)
    {
        switch (type)
        {
            case "int[]":
            case "int32[]":
            case "long[]":
                return string.IsNullOrEmpty(value) ? "[]" : $"[{value}]";

            case "string[]":
                //return $"[{value}]";
                return string.IsNullOrEmpty(value) ? "[]" : $"[{string.Join(",", value.Split(new[] { "\n" }, StringSplitOptions.None).Select(p => $"\"{p.Trim()}\""))}]";

            case "int":
            case "int32":
            case "int64":
            case "long":
            case "float":
            case "double":
                return value;

            case "bool":
                return value.ToLower();

            case "string":
                return $"\"{value.Trim()}\"";

            default:
                throw new Exception($"不支持此类型: {type}");
        }
    }

    private static string GetCellString(ISheet sheet, int i, int j, IFormulaEvaluator formulaEvaluator)
    {
        ICell cell = sheet.GetRow(i)?.GetCell(j);
        if (cell?.CellType == CellType.Formula)
        {
            return $"{formulaEvaluator.EvaluateInCell(cell)}";
        }
        else
        {
            return cell?.ToString() ?? "";
        }
    }

    private static string GetCellString(ISheet sheet, int i, int j)
    {
        return sheet.GetRow(i)?.GetCell(j)?.ToString() ?? "";
    }

    private static string GetCellString(IRow row, int i, IFormulaEvaluator formulaEvaluator)
    {
        ICell cell = row?.GetCell(i);
        if (cell?.CellType == CellType.Formula)
        {
            formulaEvaluator.ClearAllCachedResultValues();
            return $"{formulaEvaluator.EvaluateInCell(cell)}";
        }
        else
        {
            return cell?.ToString() ?? "";
        }
    }

    private static string GetCellString(ICell cell)
    {
        return cell?.ToString() ?? "";
    }

    private static string GetCellPosition(int row, int column)
    {
        return $"{(char)(column + 65)}{row + 1}";
    }
}