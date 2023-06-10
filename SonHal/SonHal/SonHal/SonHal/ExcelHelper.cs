using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace SeleniumRunner
{
    public class ExcelHelper
    {

        public static List<dynamic> ReadExcel(string filePath)
        {
            var result = new List<dynamic>();

            // Sütun isimlerini ve sıralarını saklamak için bir sözlük oluşturuyoruz.
            var columnNames = new Dictionary<int, string>();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet();
                    var table = dataSet.Tables[0];

                    // Sütun isimlerini ve sıralarını sözlüğe ekliyoruz.
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        columnNames[i] = table.Rows[0][i].ToString();
                    }

                    // Her bir satırı sözlükte saklayarak dinamik bir sınıf oluşturuyoruz.
                    for (int i = 1; i < table.Rows.Count; i++)
                    {
                        var row = table.Rows[i];
                        var data = new Dictionary<string, object>();

                        for (int j = 0; j < columnNames.Count; j++)
                        {
                            data[columnNames[j]] = row[j];
                        }

                        // Dinamik bir sınıf oluşturuyoruz.
                        var assemblyName = new AssemblyName("DynamicAssembly");
                        var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
                        var moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
                        var typeBuilder = moduleBuilder.DefineType("DynamicType", TypeAttributes.Public);

                        foreach (var columnName in columnNames.Values)
                        {
                            typeBuilder.DefineField(columnName, typeof(object), FieldAttributes.Public);
                        }

                        var dynamicType = typeBuilder.CreateType();

                        // Dinamik sınıftan bir nesne oluşturuyoruz.
                        var obj = Activator.CreateInstance(dynamicType);

                        foreach (var item in data)
                        {
                            var field = dynamicType.GetField(item.Key);
                            field.SetValue(obj, item.Value);
                        }

                        result.Add(obj);
                    }
                }
            }

            return result;
        }
    }
}
