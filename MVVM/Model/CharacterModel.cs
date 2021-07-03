using DndBruschiEd.Core.Characters;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DndBruschiEd.MVVM.Model
{
    class CharacterModel
    {
        public CharacterInfo Info { get; set; }
        public CharacterStats Stats { get; set; }

        private static string defaultSavedDir = Path.Combine(Directory.GetCurrentDirectory(), "Saved");


        public CharacterModel()
        {
            Info = null;
            Stats = null;
        }

        public CharacterModel(CharacterInfo info, CharacterStats stats)
        {
            Info = info;
            Stats = stats;
        }

        public void Export()
        {
            Directory.CreateDirectory(defaultSavedDir);

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Json file|*.json";
            saveDialog.Title = "Save Character";
            saveDialog.InitialDirectory = defaultSavedDir;
            saveDialog.FileName = Info.GetFullName();
            saveDialog.ShowDialog();

            if(saveDialog.FileName != "")
            {
                var serializeOptions = new JsonSerializerOptions{ WriteIndented = true };

                string json = JsonSerializer.Serialize(this, serializeOptions);
                File.WriteAllText(Path.GetFullPath(saveDialog.FileName), json);
            }
        }

        public static CharacterModel Import()
        {
            Directory.CreateDirectory(defaultSavedDir);

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Json file|*.json";
            openDialog.Title = "Load Character";
            openDialog.InitialDirectory = defaultSavedDir;
            openDialog.ShowDialog();

            if(openDialog.FileName != "")
            {
                try
                {
                    string json = File.ReadAllText(Path.GetFullPath(openDialog.FileName));

                    var serializeOptions = new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true, AllowTrailingCommas = true};
                    CharacterModel model = JsonSerializer.Deserialize<CharacterModel>(json, serializeOptions);

                    return model;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to deserialize json.");
                    return null;
                }
            }

            return null;
        }
    }
}
