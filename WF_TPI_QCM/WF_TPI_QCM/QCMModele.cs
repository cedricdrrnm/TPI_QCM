﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    public enum Modes { AddedInBase, Create, Update }; //Permet de faire les types (https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/enumeration-types)
    public class QCMModele
    {
        private QCMDatas _qcm;
        private const string FILENAME_ACCESS = ".TPI_QCM\\Models";

        //Key.Key = idObjet
        //Key.Value = objet
        //Value.Key = Modes
        //Value.Value = idObjetLiee (peut être 0 s'il n'y en a pas)
        private DAO _dao;
        Dictionary<int, object> _dictObjetDelete;

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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="qcm">Modèle</param>
        public QCMModele(QCMModele qcm)
        {
            _dao = new DAO();
            _qcm.NextIdMotCle = 1;
            _qcm.NextIdQuestion = 1;
            _qcm.NextIdReponse = 1;
            _dictObjetDelete = new Dictionary<int, object>();
        }

        /// <summary>
        /// Vérifie si le QCM existe déjà
        /// </summary>
        /// <param name="titreQCM">Titre du QCM</param>
        /// <returns>Retourne true s'il existe et false s'il existe pas</returns>
        public bool CheckExists(string titreQCM)
        {
            return _dao.QCMExists(titreQCM);
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        public QCMModele(int idQCM)
        {
            _dao = new DAO();
            Qcm = _dao.SelectQCMById(idQCM);
            _dictObjetDelete = new Dictionary<int, object>();
        }

        /// <summary>
        /// Récupère le niveau du QCM
        /// </summary>
        /// <returns>Niveau du QCM</returns>
        public int GetLevel()
        {
            return Qcm.Level;
        }

        /// <summary>
        /// Récupère les questions du QCM
        /// </summary>
        /// <returns>Question du QCM</returns>
        public Dictionary<int, QuestionDatas> GetQuestions()
        {
            return Qcm.DictQuestionModele;
        }

        /// <summary>
        /// Récupère les mots-clés du QCM
        /// </summary>
        /// <returns>Mots-clés du QCM</returns>
        public Dictionary<int, MotsClesDatas> GetMotsCles()
        {
            return Qcm.DictMotCle;
        }

        /// <summary>
        /// Récupère les réponses d'une question du QCM grâce à l'id de la question
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <returns>Réponses d'une question</returns>
        public Dictionary<int, ReponseDatas> GetReponsesByIdQuestion(int idQuestion)
        {
            QuestionDatas qm;
            Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm);
            return qm.DictReponseModele;
        }

        /// <summary>
        /// Insère une question avec les informations fournies
        /// </summary>
        /// <param name="text">Texte de la question</param>
        /// <param name="dictReponses">Réponses</param>
        /// <returns>Message</returns>
        public string InsertQuestion(string text, Dictionary<string, bool> dictReponses)
        {
            QuestionDatas qm = new QuestionDatas(text, Modes.Create);
            int nbReponseJuste = 0;
            foreach (KeyValuePair<string, bool> item in dictReponses)
            {
                if (item.Value)
                    nbReponseJuste++;
                qm.AddReponse(Qcm.NextIdReponse, new ReponseDatas(item.Key, item.Value, Modes.Create));
                Qcm.NextIdReponse++;
            }

            if (nbReponseJuste == 1)
            {
                if (qm.DictReponseModele.Count >= 4 && qm.DictReponseModele.Count <= 6)
                {
                    Qcm.AddQuestion(Qcm.NextIdQuestion, qm);
                    //AddEditionDatabase(Qcm.NextIdQuestion, qm, Modes.Create, Qcm.IdQCM);
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

        /// <summary>
        /// Récupère le titre du QCM
        /// </summary>
        /// <returns>Titre du QCM</returns>
        public string GetTitreQCM()
        {
            return Qcm.NomQCM;
        }

        /// <summary>
        /// Récupère l'id du QCM
        /// </summary>
        /// <returns>Prochaine id pour les QCMs</returns>
        public int GetIdQCM()
        {
            return Qcm.IdQCM;
        }


        /// <summary>
        /// Récupère le prochaine id pour les questions
        /// </summary>
        /// <returns>Prochaine id pour les questions</returns>
        public int GetNextIdQuestion()
        {
            return Qcm.NextIdQuestion;
        }


        /// <summary>
        /// Récupère le prochaine id pour les réponses
        /// </summary>
        /// <returns>Prochaine id pour les réponses</returns>
        public int GetNextIdReponse()
        {
            return Qcm.NextIdReponse;
        }


        /// <summary>
        /// Récupère le prochaine id pour les mots-clés
        /// </summary>
        /// <returns>Prochaine id pour les mots-clés</returns>
        public int GetNextIdMotCle()
        {
            return Qcm.NextIdMotCle;
        }


        /// <summary>
        /// Prochaine id pour les QCMs
        /// </summary>
        /// <returns></returns>
        public int GetNextIdQCM()
        {
            return _dao.NextIdQCM;
        }

        /// <summary>
        /// Ajoute un QCM
        /// </summary>
        /// <param name="titreQCM">Titre du QCM</param>
        /// <param name="levelQCM">Niveau du QCM</param>
        public void InsertQCM(string titreQCM, int levelQCM)
        {
            Qcm = new QCMDatas(GetNextIdQCM(), titreQCM, levelQCM, Modes.Create);
        }

        /// <summary>
        /// Supprime une question par son id
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <returns>True si réussi, false sinon</returns>
        public bool DeleteQuestionByIdQuestion(int idQuestion)
        {
            //_listDeletedQuestion.Add(idQuestion);
            QuestionDatas question;
            if (Qcm.DictQuestionModele.TryGetValue(idQuestion, out question))
                if (Qcm.DictQuestionModele.Remove(idQuestion))
                {
                    if (question.ModeDatabase != Modes.Create)
                        _dictObjetDelete.Add(idQuestion, question);
                    return true;
                }
                else
                    return false;
            return false;
        }

        /// <summary>
        /// Mets à jour une question par son id et le nouveau texte
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="nouveauTexte">Nouveau texte</param>
        /// <returns>True si réussi, false si échec</returns>
        public bool UpdateQuestionByIdQuestion(int idQuestion, string nouveauTexte)
        {
            QuestionDatas qm;
            if (Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                qm.Question = nouveauTexte;
                if (qm.ModeDatabase == Modes.AddedInBase)
                    qm.ModeDatabase = Modes.Update;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Mets à jour les réponses par l'id de la question et l'id de la réponse
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="idReponse">Id de la réponse</param>
        /// <param name="reponseModele">Réponse</param>
        /// <returns></returns>
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
                        if (rm.ModeDatabase == Modes.AddedInBase)
                            rm.ModeDatabase = Modes.Update;
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

        /// <summary>
        /// Sauvegarde dans la base de données
        /// </summary>
        public void Save()
        {
            string saved = "QCM: " + Qcm.IdQCM + ", " + Qcm.NomQCM + ", Mode: " + Qcm.ModeDatabase + Environment.NewLine;
            string error = "";
            int idQCM = 0;
            try
            {
                if (Qcm.ModeDatabase == Modes.Create)
                {
                    idQCM = _dao.InsertQCM(Qcm.NomQCM, Qcm.Level);
                }
                else if (Qcm.ModeDatabase == Modes.Update)
                {
                    _dao.UpdateQCMByIdQCM(Qcm.IdQCM, Qcm.NomQCM, Qcm.Level);
                }
                if (idQCM == 0)
                    idQCM = Qcm.IdQCM;
                Qcm.ModeDatabase = Modes.AddedInBase;

                foreach (var item in Qcm.DictMotCle)
                {
                    try
                    {
                        if (item.Value.ModeDatabase == Modes.Create)
                            _dao.InsertMotCle(idQCM, item.Value.TextMotCle);
                        else if (item.Value.ModeDatabase == Modes.Update)
                            _dao.UpdateMotCleByIdMotCle(item.Key, item.Value.TextMotCle);
                        saved += "IdMotCle: " + item.Key + ", motcle: " + item.Value.TextMotCle + ", Mode: " + item.Value.ModeDatabase + Environment.NewLine;
                        item.Value.ModeDatabase = Modes.AddedInBase;
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                }
                foreach (var item in Qcm.DictQuestionModele)
                {
                    try
                    {
                        saved += "idQuestion: " + item.Key + ", question: " + item.Value.Question + ", Mode: " + item.Value.ModeDatabase + Environment.NewLine;
                        int idQuestion = 0;
                        if (item.Value.ModeDatabase == Modes.Create)
                            idQuestion = _dao.InsertQuestion(idQCM, item.Value.Question);
                        else if (item.Value.ModeDatabase == Modes.Update)
                            _dao.UpdateQuestionByIdQuestion(item.Key, item.Value.Question);
                        item.Value.ModeDatabase = Modes.AddedInBase;
                        if (idQuestion == 0)
                        {
                            idQuestion = item.Key;
                        }
                        foreach (var item2 in item.Value.DictReponseModele)
                        {
                            try
                            {
                                if (item2.Value.ModeDatabase == Modes.Create)
                                    _dao.InsertReponses(idQuestion, item2.Value.Reponse, item2.Value.BonneReponse);
                                else if (item2.Value.ModeDatabase == Modes.Update)
                                    _dao.UpdateReponseByIdReponse(idQuestion, item2.Key, item2.Value.Reponse, item2.Value.BonneReponse);
                                saved += "idReponse: " + item2.Key + ", reponse: " + item2.Value.Reponse + ", Mode: " + item2.Value.ModeDatabase + Environment.NewLine;
                                item2.Value.ModeDatabase = Modes.AddedInBase;
                            }
                            catch (Exception ex)
                            {
                                error = ex.Message;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }

                }

                foreach (var item in _dictObjetDelete)
                {
                    try
                    {
                        if (item.Value is QCMDatas)
                            DeleteQCM();
                        else if (item.Value is QuestionDatas)
                            _dao.DeleteQuestionByIdQuestion(item.Key);
                        else if (item.Value is ReponseDatas)
                            _dao.DeleteReponsesByIdReponse(item.Key);
                        else if (item.Value is MotsClesDatas)
                            _dao.DeleteMotCleByIdMotCle(item.Key);
                        saved += "idObjetDelete: " + item.Key + ", reponse: " + item.Value + Environment.NewLine;
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                }
                _dictObjetDelete.Clear();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            Console.WriteLine(saved);
        }

        /// <summary>
        /// Supprime le QCM
        /// </summary>
        /// <returns>Message</returns>
        public string DeleteQCM()
        {
            try
            {
                if (Qcm.ModeDatabase != Modes.Create)
                    _dao.DeleteQCMByIdQCM(Qcm.IdQCM);
                //Qcm = null;
                return "Supprimé avec succès !";
            }
            catch (Exception ex)
            {
                return "Erreur lors de la suppression: " + ex.Message;
            }

        }

        /// <summary>
        /// Modifie le QCM avec les informations données
        /// </summary>
        /// <param name="nouveauText">Nouveau texte</param>
        /// <param name="nouveauLevel">Nouveau niveau (level)</param>
        /// <returns>Message</returns>
        public string UpdateQCM(string nouveauText, int nouveauLevel)
        {
            if (nouveauText.Trim() != "")
            {
                try
                {
                    if (!_dao.QCMExists(nouveauText))
                    {
                        Qcm.NomQCM = nouveauText;
                        Qcm.Level = nouveauLevel;
                        if (Qcm.ModeDatabase == Modes.AddedInBase)
                            Qcm.ModeDatabase = Modes.Update;
                        return "Modifié avec succès !";
                    }
                    else return "Ce nom de QCM est déjà pris !";
                }
                catch (Exception ex)
                {
                    return "Erreur lors de la modification: " + ex.Message;
                }
            }
            return "Nom vide !";
        }

        /// <summary>
        /// Insère une réponse dans une question par l'id donnée et avec les informations données
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="reponseText">Texte de la réponse</param>
        /// <param name="bonneReponse">Bonne réponse ou non</param>
        /// <returns></returns>
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
                    ReponseDatas rm = new ReponseDatas(reponseText, bonneReponse, Modes.Create);
                    qm.AddReponse(Qcm.NextIdReponse, rm);
                    Qcm.NextIdReponse++;
                    return "";
                }
            }
            return "Cette question est introuvable !";
        }

        /// <summary>
        /// Supprime une réponse par son id et l'id de la question
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="idReponse">Id de la réponse</param>
        /// <returns>Vrai si réussi, sinon false</returns>
        public bool DeleteReponseByIdReponse(int idQuestion, int idReponse)
        {
            QuestionDatas qm;
            if (Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                ReponseDatas rm;
                qm.DictReponseModele.TryGetValue(idReponse, out rm);
                if (rm.ModeDatabase != Modes.Create)
                    _dictObjetDelete.Add(idReponse, rm);
                qm.DictReponseModele.Remove(idReponse);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Change la réponse correcte grâce à l'id de la question et de la nouvelle réponse à cette question
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="idNewReponse">Id de la nouvelle bonne réponse</param>
        public void ChangeCorrectAnswer(int idQuestion, int idNewReponse)
        {
            foreach (KeyValuePair<int, ReponseDatas> item in GetReponsesByIdQuestion(idQuestion))
            {
                if (item.Key == idNewReponse)
                {
                    if (!item.Value.BonneReponse)
                        if (item.Value.ModeDatabase == Modes.AddedInBase)
                            item.Value.ModeDatabase = Modes.Update;
                    item.Value.BonneReponse = true;
                }
                else
                {
                    if (item.Value.BonneReponse)
                        if (item.Value.ModeDatabase == Modes.AddedInBase)
                            item.Value.ModeDatabase = Modes.Update;
                    item.Value.BonneReponse = false;
                }

            }
        }

        /// <summary>
        /// Récupère la liste des modèles
        /// </summary>
        /// <returns>Lsite des mpdèles</returns>
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

        /// <summary>
        /// Récupère la liste des QCMs
        /// </summary>
        /// <returns>Liste des QCMs</returns>
        public static Dictionary<int, string> GetListQCM()
        {
            return DAO.SelectAllQCM();
        }

        /// <summary>
        /// Insère un mot-clé dans le QCM avec son texte
        /// </summary>
        /// <param name="textMotCle">Texte du mot-clé</param>
        /// <returns>Message</returns>
        public string InsertMotCle(string textMotCle)
        {
            if (Qcm.DictMotCle.Count < 4)
            {
                string returnString = Qcm.AddMotsCles(this.GetNextIdMotCle(), new MotsClesDatas(textMotCle, Modes.Create));
                Qcm.NextIdMotCle++;
                return returnString;
            }
            else
            {
                return "Ce mot-clé ne sera pas ajouté car il y a déjà 4 mots-clés !";
            }
        }

        /// <summary>
        /// Mets à jour un mot-clé grâce à l'id et son nouveau texte
        /// </summary>
        /// <param name="idMotCle">Id du mot-clé</param>
        /// <param name="textMotCle">Nouveau texte du mot-clé</param>
        /// <returns>Message</returns>
        public string UpdateMotCle(int idMotCle, string textMotCle)
        {
            if (Qcm.DictMotCle.ContainsKey(idMotCle))
            {
                try
                {
                    MotsClesDatas motCle;
                    if (Qcm.DictMotCle.TryGetValue(idMotCle, out motCle))
                    {
                        if (motCle.TextMotCle != textMotCle)
                        {
                            Qcm.DictMotCle.Remove(idMotCle);
                            Qcm.DictMotCle.Add(idMotCle, new MotsClesDatas(textMotCle, (motCle.ModeDatabase == Modes.AddedInBase) ? Modes.Update : motCle.ModeDatabase));
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

        /// <summary>
        /// Supprime un mot-clé par son id
        /// </summary>
        /// <param name="idMotCle">Id du mot-clé</param>
        /// <returns>Message</returns>
        public bool DeleteMotCleByIdMotCle(int idMotCle)
        {
            MotsClesDatas motsCd;
            if (Qcm.DictMotCle.TryGetValue(idMotCle, out motsCd))
            {
                if (motsCd.ModeDatabase != Modes.Create)
                    _dictObjetDelete.Add(idMotCle, motsCd);
                return Qcm.DictMotCle.Remove(idMotCle);
            }
            return false;
        }

        /*public void Save()
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
        }*/

        /*private void AddEditionDatabase(int idObjet, object objet, Modes mode, int idLinkedObject)
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
        }*/
    }
}
