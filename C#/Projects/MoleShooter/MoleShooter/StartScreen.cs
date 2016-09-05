//#define IncludeFonts

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using MoleShooter.Properties;

namespace MoleShooter
{
    public partial class StartScreen : Form
    {
#if IncludeFonts
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;
#endif
        public StartScreen()
        {
            InitializeComponent();

#if IncludeFonts
            byte[] fontData = Resources.Rosewood;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Resources.Rosewood.Length);
            AddFontMemResourceEx(fontPtr, (uint)Resources.Rosewood.Length, IntPtr.Zero, ref dummy);
            Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 30.0F, FontStyle.Regular);
#endif
        }


        private void Form2_Load(object sender, EventArgs e)
        {            
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            var ms = new MoleShooter();
            this.Hide();
            ms.ShowDialog();
        }
    }
}
