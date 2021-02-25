using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Behavior_Tree_Designer
{
    public class PluginLoader
    {
        public const string FolderName = "Plugins";

        public static List<INode> Plugins { get; set; }

        public bool LoadPlugins()
        {
            Plugins = new List<INode>();

            try
            {
                //Load the DLLs from the Plugins directory
                if (Directory.Exists(FolderName))
                {
                    string[] files = Directory.GetFiles(FolderName);
                    foreach (string file in files)
                    {
                        if (file.EndsWith(".dll"))
                        {
                            Assembly.LoadFile(Path.GetFullPath(file));
                        }
                    }
                }

                Type interfaceType = typeof(INode);
                //Fetch all types that implement the interface INode and are a class
                Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                    .ToArray();
                foreach (Type type in types)
                {
                    //Create a new instance of all found types
                    Plugins.Add((INode)Activator.CreateInstance(type));
                }
                return true;
            }
            catch(Exception ex)
            {

            }
            return false;
        }

        public void Populate(ToolStrip menu)
        {
            ToolStripButton reference = menu.Items[0] as ToolStripButton;
            foreach(INode node in Plugins)
            {
                if (node.Tag == null)
                    continue;

                ToolStripButton btn = new ToolStripButton();
                btn.AutoSize = reference.AutoSize;
                btn.Size = reference.Size;
                btn.TextImageRelation = reference.TextImageRelation;
                btn.ImageScaling = reference.ImageScaling;
                btn.ImageAlign = reference.ImageAlign;
                btn.Font = reference.Font;

                btn.Image = node.Icon;
                btn.Text = node.Text;
                btn.Name = "btn" + node.Tag;

                menu.Items.Add(btn);
            }
            
        }
    }
}
