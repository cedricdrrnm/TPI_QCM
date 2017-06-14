using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    class QCMModele
    {
        public enum Modes { Create, Update, Delete }; //Permet de faire les types (https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/enumeration-types)
        private QCMDatas _qcm;
        private const string FILENAME_ACCESS = ".TPI_QCM\\Models";

        //Key.Key = idObjet
        //Key.Value = objet
        //Value.Key = Modes
        //Value.Value = idObjetLiee (peut être 0 s'il n'y en a pas)
        private Dictionary<object, KeyValuePair<int, KeyValuePair<Modes, int>>> _dictEditionDataBase;
        private DAO _dao;

        private QCMDatas Qcm
        {
            get
            {
                return _qcm;
            }

            set
            {
                _qcm = value;
            }
        }

        public QCMModele(int idQCM)
        {
            _dao = new DAO();
            Qcm = _dao.SelectQCMById(idQCM);
            _dictEditionDataBase = new Dictionary<object, KeyValuePair<int, KeyValuePair<Modes, int>>>();
        }

        public int GetLevelByIdQCM()
        {
            return Qcm.Level;
        }

        public Dictionary<int, QuestionDatas> GetQuestions()
        {
            return Qcm.DictQuestionModele;
        }

        public Dictionary<int, string> GetMotsCles()
        {
            return Qcm.DictMotCle;
        }

        public Dictionary<int, ReponseDatas> GetReponsesByIdQuestion(int idQuestion)
        {
            QuestionDatas qm;
            Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm);
            return qm.DictReponseModele;
        }

        public string InsertQuestion(string text, Dictionary<string, bool> dictReponses)
        {
            QuestionDatas qm = new QuestionDatas(text);
            int nbReponseJuste = 0;
            foreach (KeyValuePair<string, bool> item in dictReponses)
            {
                if (item.Value)
                    nbReponseJuste++;
                qm.AddReponse(Qcm.NextIdReponse, new ReponseDatas(item.Key, item.Value));
                Qcm.NextIdReponse++;
            }

            if (nbReponseJuste == 1)
            {
                if (qm.DictReponseModele.Count >= 4 && qm.DictReponseModele.Count <= 6)
                {
                    Qcm.AddQuestion(Qcm.NextIdQuestion, qm);
                    AddEditionDatabase(Qcm.NextIdQuestion, qm, Modes.Create, Qcm.IdQCM);
                    Qcm.NextIdQuestion++;
                    return "Question insérée avec succès !";
                }
                else
                {
                    return "Il n'y a pas le nombre adéquat de réponse !";
                }
            }
            else
            {
                return "Nombre de réponses justes incorrecte !";
            }
        }

        public string GetTitreQCM()
        {
            return Qcm.NomQCM;
        }

        public int GetIdQCM()
        {
            return Qcm.IdQCM;
        }

        public int GetNextIdQuestion()
        {
            return Qcm.NextIdQuestion;
        }

        public int GetNextIdReponse()
        {
            return Qcm.NextIdReponse;
        }

        public int GetNextIdMotCle()
        {
            return Qcm.NextIdMotCle;
        }

        public string InsertQCM(string titreQCM, int levelQCM)
        {
            try
            {
                //_dao.InsertQCM(titreQCM, levelQCM);
                AddEditionDatabase(Qcm.IdQCM, Qcm, Modes.Create, 0);
                return "Ce qcm a bien été créé !";
            }
            catch (Exception ex)
            {
                return "Erreur lors de l'insertion du QCM: " + ex.Message;
            }
        }

        public bool DeleteQuestionByIdQuestion(int idQuestion)
        {
            //_listDeletedQuestion.Add(idQuestion);
            QuestionDatas question;
            if (Qcm.DictQuestionModele.TryGetValue(idQuestion, out question))
                if (Qcm.DictQuestionModele.Remove(idQuestion))
                {
                    AddEditionDatabase(idQuestion, question, Modes.Delete, Qcm.IdQCM);
                    return true;
                }
                else
                    return false;
            return false;
        }

        public bool UpdateQuestionByIdQuestion(int idQuestion, string nouveauTexte)
        {
            QuestionDatas qm;
            if (Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                qm.Question = nouveauTexte;
                AddEditionDatabase(idQuestion, qm, Modes.Update, Qcm.IdQCM);
                return true;
            }
            else
            {
                return false;
            }
        }

        public KeyValuePair<bool, string> UpdateReponseByIdQuestionAndIdReponse(int idQuestion, int idReponse, ReponseDatas reponseModele)
        {
            QuestionDatas qm;
            if (Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                ReponseDatas rm;
                if (qm.DictReponseModele.TryGetValue(idReponse, out rm))
                {
                    if (rm.Reponse != reponseModele.Reponse || rm.BonneReponse != reponseModele.BonneReponse)
                    {
                        rm.Reponse = reponseModele.Reponse;
                        rm.BonneReponse = reponseModele.BonneReponse;
                        AddEditionDatabase(idReponse, rm, Modes.Update, idQuestion);
                        return new KeyValuePair<bool, string>(false, "Réponse modifiée avec succès !");
                    }
                    else
                        return new KeyValuePair<bool, string>(false, null);
                }
                else
                    return new KeyValuePair<bool, string>(true, "Echec lors de la récupération de la réponse pour la modification !");
            }
            else
                return new KeyValuePair<bool, string>(true, "Echec lors de la récupération de la question contenant la réponse pour la modification !");
        }

        public string DeleteQCM()
        {
            try
            {
                _dao.DeleteQCMByIdQCM(Qcm.IdQCM);
                AddEditionDatabase(Qcm.IdQCM, Qcm, Modes.Delete, 0);
                Qcm = null;
                return "Supprimé avec succès !";
            }
            catch (Exception ex)
            {
                return "Erreur lors de la suppression: " + ex.Message;
            }

        }

        public string UpdateQCM(string nouveauText, int nouveauLevel)
        {
            if (nouveauText.Trim() != "")
            {
                try
                {
                    _dao.UpdateQCMByIdQCM(Qcm.IdQCM, nouveauText, nouveauLevel);
                    AddEditionDatabase(Qcm.IdQCM, Qcm, Modes.Update, 0);
                    return "Modifié avec succès !";
                }
                catch (Exception ex)
                {
                    return "Erreur lors de la modification: " + ex.Message;
                }
            }
            return "Nom vide !";
        }

        public string InsertReponse(int idQuestion, string reponseText, bool bonneReponse)
        {
            QuestionDatas qm = null;
            foreach (KeyValuePair<int, QuestionDatas> item in Qcm.DictQuestionModele)
            {
                if (item.Key == idQuestion)
                {
                    qm = item.Value;
                }
            }
            if (qm != null)
            {
                if (qm.DictReponseModele.Count >= 6)
                    return "Il a trop de réponses !";
                else
                {
                    ReponseDatas rm = new ReponseDatas(reponseText, bonneReponse);
                    qm.AddReponse(Qcm.NextIdReponse, rm);
                    AddEditionDatabase(Qcm.NextIdReponse, rm, Modes.Create, Qcm.IdQCM);
                    Qcm.NextIdReponse++;
                    return "";
                }
            }
            return "Cette question est introuvable !";
        }

        public bool DeleteReponseByIdReponse(int idQuestion, int idReponse)
        {
            QuestionDatas qm;
            if (Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                ReponseDatas rm;
                qm.DictReponseModele.TryGetValue(idReponse, out rm);
                AddEditionDatabase(Qcm.NextIdReponse, rm, Modes.Delete, Qcm.IdQCM);
                qm.DictReponseModele.Remove(idReponse);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChangeCorrectAnswer(int idQuestion, int idNewReponse)
        {
            foreach (KeyValuePair<int, ReponseDatas> item in GetReponsesByIdQuestion(idQuestion))
            {
                item.Value.BonneReponse = (item.Key == idQuestion) ? true : false;
                AddEditionDatabase(item.Key, item.Value, Modes.Update, idQuestion);
            }
        }

        public static List<string> GetListModeles()
        {
            List<string> listModeles = new List<string>();


            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS);

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS + "\\latex.txt"))
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS + "\\latex.txt", Properties.Resources.latex);
            }

            //http://www.csharp-examples.net/get-files-from-directory/
            foreach (string item in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS))
            {
                listModeles.Add(item.Split('\\').Last());
            }
            return listModeles;
        }

        public static Dictionary<int, string> GetListQCM()
        {
            return DAO.SelectAllQCM();
        }

        public string InsertMotCle(string textMotCle)
        {
            if (Qcm.DictMotCle.Count < 4)
            {
                string returnString = Qcm.AddMotsCles(this.GetNextIdMotCle(), textMotCle);
                AddEditionDatabase(GetNextIdMotCle(), textMotCle, Modes.Create, Qcm.IdQCM);
                Qcm.NextIdMotCle++;
                return returnString;
            }
            else
            {
                return "Ce mot-clé ne sera pas ajouté car il y a déjà 4 mots-clés !";
            }
        }

        public string UpdateMotCle(int idMotCle, string textMotCle)
        {
            if (Qcm.DictMotCle.ContainsKey(idMotCle))
            {
                try
                {
                    string motCle;
                    if (Qcm.DictMotCle.TryGetValue(idMotCle, out motCle))
                    {
                        if (motCle != textMotCle)
                        {
                            Qcm.DictMotCle.Remove(idMotCle);
                            Qcm.DictMotCle.Add(idMotCle, textMotCle);
                            AddEditionDatabase(idMotCle, textMotCle, Modes.Update, Qcm.IdQCM);
                            return "Mot-Clé modifié !";
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "Impossible de récupérer l'ancienne valeur du mot-clé !";
                    }
                }
                catch (Exception ex)
                {
                    return "Erreur lors de la modification du mot-clé: " + ex.Message;
                }
            }
            else
                return "Ce mot-clé n'existe pas, il ne peut pas être modifié !";
        }

        public bool DeleteMotCleByIdMotCle(int idMotCle)
        {
            string textMotCle;
            if (Qcm.DictMotCle.TryGetValue(idMotCle, out textMotCle))
            {
                AddEditionDatabase(idMotCle, textMotCle, Modes.Delete, Qcm.IdQCM);
                return Qcm.DictMotCle.Remove(idMotCle);
            }
            return false;
        }

        public void Save()
        {
            string query = "";
            foreach (KeyValuePair<object, KeyValuePair<int, KeyValuePair<Modes, int>>> item in _dictEditionDataBase)
            {
                int idObjet = item.Value.Key;
                if (item.Key is QCMDatas)
                {
                    QCMDatas qcmd = item.Key as QCMDatas;
                    if (item.Value.Value.Key == Modes.Create)
                    {
                        query += "INSERT INTO `qcm`(`nomQCM`, `level`) VALUES(\"" + qcmd.NomQCM + "\"," + qcmd.Level + ");";
                    }
                    else if (item.Value.Value.Key == Modes.Update)
                    {
                        query += "UPDATE `qcm` SET `nomQCM`=\"" + qcmd.NomQCM + "\",`level`=" + qcmd.Level + " WHERE `idQCM`=" + idObjet + ";";
                    }
                    else if (item.Value.Value.Key == Modes.Delete)
                    {
                        query += "DELETE FROM `qcm` WHERE `idQCM` = " + idObjet + ";";
                    }
                }
                else if (item.Key is QuestionDatas)
                {
                    QuestionDatas qd = item.Key as QuestionDatas;
                    if (item.Value.Value.Key == Modes.Create)
                    {
                        query += "INSERT INTO `question`(`question`) VALUES (\"" + qd.Question + "\");" + Environment.NewLine;
                        query += "INSERT INTO `qcm_has_question`(`idQCM`, `idQuestion`) VALUES (" + item.Value.Value.Value + ",(SELECT LAST_INSERT_ID()));";
                    }
                    else if (item.Value.Value.Key == Modes.Update)
                    {
                        query += "UPDATE `question` SET `question`=\"" + qd.Question + "\" WHERE `idQuestion`=" + idObjet + ";";
                    }
                    else if (item.Value.Value.Key == Modes.Delete)
                    {
                        query += "DELETE FROM `question` WHERE `idQuestion` = " + idObjet + ";";
                        //La liaison est supprimé par le cascade dans le concepteur
                    }
                }
                else if (item.Key is ReponseDatas)
                {
                    ReponseDatas rd = item.Key as ReponseDatas;
                    if (item.Value.Value.Key == Modes.Create)
                    {
                        query += "INSERT INTO `reponse`(`reponse`) VALUES (" + rd.Reponse + ");" + Environment.NewLine;
                        query += "INSERT INTO `question_has_reponse`(`idQuestion`, `idReponse`, `bonneReponse`) VALUES (" + item.Value.Value.Value + ",(SELECT LAST_INSERT_ID()), " + rd.BonneReponse + ");";
                    }
                    else if (item.Value.Value.Key == Modes.Update)
                    {
                        query += "UPDATE `reponse` SET `reponse`=" + rd.Reponse + " WHERE `idReponse`=" + idObjet + ";" + Environment.NewLine;
                        query += "UPDATE `question_has_reponse` SET `bonneReponse`=" + rd.BonneReponse + " WHERE `idReponse`=" + idObjet + " AND `idQuestion`=" + item.Value.Value.Value + ";";
                    }
                    else if (item.Value.Value.Key == Modes.Delete)
                    {
                        query += "DELETE FROM `question` WHERE `idQuestion` = " + idObjet + ";";
                        //La liaison est supprimé par le cascade dans le concepteur
                    }
                }
                else if (item.Key is string)
                {
                    string motcle = item.Key.ToString();
                    if (item.Value.Value.Key == Modes.Create)
                    {
                        query += "INSERT INTO `motcle`(`motCle`) VALUES (\"" + motcle + "\");" + Environment.NewLine;
                        query += "INSERT INTO `qcm_has_motcle`(`idQCM`, `idMotCle`) VALUES (" + item.Value.Value + ",(SELECT LAST_INSERT_ID()));";
                    }
                    else if (item.Value.Value.Key == Modes.Update)
                    {
                        query += "UPDATE `motcle` SET `motCle`=\"" + motcle + "\" WHERE `idMotCle`=" + idObjet + ";" + Environment.NewLine;
                    }
                    else if (item.Value.Value.Key == Modes.Delete)
                    {
                        query += "DELETE FROM `motcle` WHERE `idMotCle` = " + idObjet + ";";
                        //La liaison est supprimé par le cascade dans le concepteur
                    }
                }
                query += Environment.NewLine;
            }
            Console.WriteLine(query);
        }

        private void AddEditionDatabase(int idObjet, object objet, Modes mode, int idLinkedObject)
        {
            KeyValuePair<int, KeyValuePair<Modes, int>> getMode;
            if (_dictEditionDataBase.TryGetValue(objet, out getMode))
            {
                if (getMode.Value.Key == Modes.Create)
                {
                    if (mode == Modes.Update)
                    {
                        _dictEditionDataBase.Remove(objet);
                        _dictEditionDataBase.Add(objet, new KeyValuePair<int, KeyValuePair<Modes,int>>(idObjet, new KeyValuePair<Modes, int>(Modes.Create, idLinkedObject)));
                    }
                    else if (mode == Modes.Delete)
                    {
                        _dictEditionDataBase.Remove(objet);
                    }
                }
                else if (getMode.Value.Key == Modes.Update)
                {
                    if (mode == Modes.Update || mode == Modes.Delete)
                    {
                        _dictEditionDataBase.Remove(new KeyValuePair<int, object>(idObjet, objet));
                        _dictEditionDataBase.Add(objet, new KeyValuePair<int, KeyValuePair<Modes, int>>(idObjet, new KeyValuePair<Modes, int>(mode, idLinkedObject)));
                    }
                }
            }
            else
            {
                _dictEditionDataBase.Add(objet, new KeyValuePair<int, KeyValuePair<Modes, int>>(idObjet, new KeyValuePair<Modes, int>(mode, idLinkedObject)));
            }
        }
    }
}
