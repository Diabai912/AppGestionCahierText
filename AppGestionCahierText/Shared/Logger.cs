using System;
using System.Diagnostics;
using System.IO;

namespace AppGestionCahierText.Shared
{
    public static class Logger
    {
        // ✅ Chemin du fichier log dans le dossier de l'application
        private static string cheminLog = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Error", "erreur.txt");

        // ✅ Écrire dans un fichier texte
        public static void WriteFileError(string message)
        {
            try
            {
                // Créer le dossier Error s'il n'existe pas
                string dossier = Path.GetDirectoryName(cheminLog);
                if (!Directory.Exists(dossier))
                    Directory.CreateDirectory(dossier);

                using (StreamWriter writeFile = new StreamWriter(cheminLog, true))
                {
                    writeFile.WriteLine("" + DateTime.Now);
                    writeFile.WriteLine(message);
                    writeFile.WriteLine("----------------------------------------");
                }
            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "WriteFileError");
            }
        }

        // ✅ Écrire dans le journal Windows (Event Viewer)
        public static void WriteLogSystem(string erreur, string libelle)
        {
            try
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "GestionCahierTexte";
                    eventLog.WriteEntry(
                        string.Format("date: {0}, libelle: {1}, description: {2}",
                            DateTime.Now, libelle, erreur),
                        EventLogEntryType.Information, 101, 1);
                }
            }
            catch { }
        }
    }
}