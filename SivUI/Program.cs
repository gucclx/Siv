﻿using SivBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// TODO - catch any exceptions when calling the connection
namespace SivUI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigGlobal.inicializarConexion();
            Application.Run(new VenderForm());
        }
    }
}
