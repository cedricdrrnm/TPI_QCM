﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    class DAO
    {
        private static MySqlConnection _conn;
        private int _nextIdQCM;

        public int NextIdQCM
        {
            get
            {
                return _nextIdQCM;
            }

            set
            {
                _nextIdQCM = value;
            }
        }

        private static MySqlConnection Conn
        {
            get
            {
                return _conn;
            }

            set
            {
                _conn = value;
            }
        }

        /// <summary>
        /// Initialise la connection
        /// </summary>
        public DAO()
        {
            Conn = new MySqlConnection("SERVER=" + Properties.Settings.Default.DB_Host + ";" + "DATABASE=" + Properties.Settings.Default.DB_Name + ";" + "UID=" + Properties.Settings.Default.DB_Username + ";" + "PASSWORD=" + Properties.Settings.Default.DB_Password + ";");
        }

        /// <summary>
        /// Ouvre la connection
        /// </summary>
        /// <returns>Retourne vrai (true) s'il n'y a aucun problème sinon retourne faux (false)</returns>
        public void OpenConnection()
        {
            try
            {
                if (Conn.State != System.Data.ConnectionState.Open)
                {
                    Conn.Open();
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        new Exception("Impossible de se connecter à la base de données");
                        break;

                    case 1045:
                        new Exception("Nom d'utilisateur ou mot de passe invalides !");
                        break;

                    default:
                        new Exception("Erreur lors de la connection: " + ex.Message);
                        break;
                }
                Conn = null;
                throw new Exception("Connection échouée !");
            }
        }

        /// <summary>
        /// Ferme la connection
        /// </summary>
        /// <returns>Retourne vrai (true) s'il n'y a aucun problème sinon retourne faux (false)</returns>
        private void CloseConnection()
        {
            try
            {
                Conn.Close();
            }
            catch (MySqlException ex)
            {
                throw new Exception("La connection ne peut pas être fermée :" + ex.Message);
            }
        }

        #region Select

        /// <summary>
        /// Sélectionne les autoincréments
        /// </summary>
        /// <returns>Auto-incréments</returns>
        Dictionary<string, int> SelectAutoIncrement()
        {
            string query = "SELECT `TABLE_NAME`, `AUTO_INCREMENT` FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '" + Properties.Settings.Default.DB_Name + "' AND AUTO_INCREMENT IS NOT null";

            //Create a list to store the result
            Dictionary<string, int> dictQCMIncrement = new Dictionary<string, int>();

            //Open connection
            try
            {
                OpenConnection();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    dictQCMIncrement.Add(dataReader.GetString("TABLE_NAME"), dataReader.GetInt32("AUTO_INCREMENT"));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return dictQCMIncrement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retourne les questions par l'id QCM
        /// </summary>
        /// <param name="id">Id du QCM</param>
        /// <returns>Question du QCM</returns>
        public Dictionary<int, QuestionDatas> SelectAllQuestionByIdQCM(int id)
        {
            string query = "SELECT qu.`idQuestion`, qu.`question` FROM `question` as qu,`qcm_has_question` as qhq, `qcm` as q WHERE qu.`idQuestion` = qhq.`idQuestion` AND qhq.`idQCM` = q.`idQCM` AND q.`idQCM` = @id";

            //Create a list to store the result
            Dictionary<int, QuestionDatas> dictQuestion = new Dictionary<int, QuestionDatas>();

            //Open connection
            try
            {
                OpenConnection();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    dictQuestion.Add(dataReader.GetInt32("idQuestion"), new QuestionDatas(dataReader.GetString("question"), Modes.AddedInBase));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return dictQuestion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retourne les réponses par l'id de la question
        /// </summary>
        /// <param name="id">Id de la question</param>
        /// <returns>Réponses à la question</returns>
        public Dictionary<int, ReponseDatas> SelectAllReponseByIdQuestion(int id)
        {
            string query = "SELECT r.`idReponse`, r.`reponse`, qhr.`bonneReponse` FROM `reponse` as r, `question` as q, `question_has_reponse` as qhr WHERE r.`idReponse` = qhr.`idReponse` AND qhr.`idQuestion` = q.`idQuestion` AND q.`idQuestion` = @id";

            //Create a list to store the result
            Dictionary<int, ReponseDatas> dictReponse = new Dictionary<int, ReponseDatas>();

            //Open connection
            try
            {
                OpenConnection();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    dictReponse.Add(dataReader.GetInt32("idReponse"), new ReponseDatas(dataReader.GetString("reponse"), dataReader.GetBoolean("bonneReponse"), Modes.AddedInBase));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return dictReponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retourne les mots clé par l'id du QCM
        /// </summary>
        /// <param name="id">Id du QCM</param>
        /// <returns>Retourne l'id du QCM</returns>
        public Dictionary<int, MotsClesDatas> SelectAllMotCleByIdQCM(int id)
        {
            string query = "SELECT m.`idMotCle`, m.`motCle` FROM `motcle` as m,`qcm_has_motcle` as qhm, `qcm` as q WHERE m.`idMotCle` = qhm.`idMotCle` AND qhm.`idQCM` = q.`idQCM` AND q.`idQCM` = @id;";

            //Create a list to store the result
            Dictionary<int, MotsClesDatas> listMotCle = new Dictionary<int, MotsClesDatas>();

            //Open connection
            try
            {
                OpenConnection();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    listMotCle.Add(dataReader.GetInt32("idMotCle"), new MotsClesDatas(dataReader.GetString("motCle"), Modes.AddedInBase));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return listMotCle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sélectionne tous les QCMs
        /// </summary>
        /// <returns>Tous les QCMs</returns>
        public static Dictionary<int, string> SelectAllQCM()
        {
            DAO _daoTemp = new DAO();
            string query = "SELECT * FROM qcm";

            //Create a list to store the result
            Dictionary<int, string> listQCMModele = new Dictionary<int, string>();

            //Open connection
            try
            {
                _daoTemp.OpenConnection();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    listQCMModele.Add(dataReader.GetInt32("idQCM"), dataReader.GetString("nomQCM"));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                _daoTemp.CloseConnection();

                //return list to be displayed
                return listQCMModele;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sélectionne un QCM par son id
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        /// <returns>QCM</returns>
        public QCMDatas SelectQCMById(int idQCM)
        {
            //Open connection
            try
            {
                OpenConnection();
                string query = "SELECT `idQCM`, `nomQCM`, `level` FROM `qcm` WHERE `idQCM` = @idQCM;";

                //Create a QCMModele to store the result
                QCMDatas qcmModele = null;

                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                //Parameters
                cmd.Parameters.AddWithValue("@idQCM", idQCM);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    qcmModele = new QCMDatas(dataReader.GetInt32("idQCM"), dataReader.GetString("nomQCM"), dataReader.GetInt32("level"), Modes.AddedInBase);
                }
                dataReader.Close();
                CloseConnection();

                if (qcmModele != null)
                {
                    qcmModele.DictMotCle = SelectAllMotCleByIdQCM(idQCM);
                    qcmModele.DictQuestionModele = SelectAllQuestionByIdQCM(idQCM);
                    foreach (KeyValuePair<int, QuestionDatas> item in qcmModele.DictQuestionModele)
                    {
                        item.Value.DictReponseModele = SelectAllReponseByIdQuestion(item.Key);
                    }

                    Dictionary<string, int> auto_increment_value = SelectAutoIncrement();
                    int _nextID;

                    if (auto_increment_value.TryGetValue("motcle", out _nextID))
                    {
                        qcmModele.NextIdMotCle = _nextID;
                    }
                    if (auto_increment_value.TryGetValue("question", out _nextID))
                    {
                        qcmModele.NextIdQuestion = _nextID;
                    }
                    if (auto_increment_value.TryGetValue("reponse", out _nextID))
                    {
                        qcmModele.NextIdReponse = _nextID;
                    }
                    if (auto_increment_value.TryGetValue("qcm", out _nextID))
                    {
                        NextIdQCM = _nextID;
                    }
                    //return list to be displayed
                    return qcmModele;

                }
                return qcmModele;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retourne si le QCM existe
        /// </summary>
        /// <param name="nomQCM">Nom du QCM</param>
        /// <returns>Si le QCM existe retourne true, sinon retourne false</returns>
        public bool QCMExists(string nomQCM)
        {
            string query = "SELECT * FROM qcm WHERE `nomQCM` = @nomQCM";

            //Open connection
            try
            {
                bool qcmExists = false;
                OpenConnection();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@nomQCM", nomQCM);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    qcmExists = true;
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return qcmExists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Insert

        /// <summary>
        /// Insère une nouvelle question avec les informations données
        /// </summary>
        /// <param name="nomQCM">Nom du QCM</param>
        /// <param name="level">Niveau du QCM</param>
        /// <returns>Id du QCM</returns>
        public int InsertQCM(string nomQCM, int level)
        {
            string query = "INSERT INTO `qcm`(`nomQCM`,`level`) VALUES (@nomSubject, @level); SELECT LAST_INSERT_ID();";

            //open connection
            try
            {
                int idQCM = 0;
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@nomSubject", nomQCM);
                cmd.Parameters.AddWithValue("@level", level);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    idQCM = dataReader.GetInt32(0);
                }
                dataReader.Close();
                CloseConnection();
                return idQCM;
            }
            catch (MySqlException ex)
            {
                //close connection
                CloseConnection();
                //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                if (ex.Number == 1062)
                    throw new Exception("Ce qcm existe déjà !");
                else
                    throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Créer le lien entre le QCM et sa question
        /// </summary>
        /// <param name="idQCM">L'id du QCM</param>
        /// <param name="idQuestion">L'id de la question</param>
        /// <returns>Le message d'erreur</returns>
        private string InsertQCM_HAS_QUESTION(int idQCM, int idQuestion)
        {
            string query = "INSERT INTO `qcm_has_question`(`idQCM`, `idQuestion`) VALUES (@idQCM, @idQuestion);";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@idQCM", idQCM);
                cmd.Parameters.AddWithValue("@idQuestion", idQuestion);
                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    CloseConnection();
                    return "";
                }
                catch (MySqlException ex)
                {
                    //close connection
                    CloseConnection();
                    //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                    if (ex.Number == 1062)
                        return "Ce lien existe déjà !";
                    else
                        return ex.Message;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Créer le lien entre la question et sa réponse
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="idReponse">Id de la réponse</param>
        /// <param name="bonneReponse">Bonne réponse ou non ?</param>
        /// <returns>Message d'erreur</returns>
        private string InsertQuestions_HAS_Reponses(int idQuestion, int idReponse, bool bonneReponse)
        {
            string query = "INSERT INTO `question_has_reponse`(`idQuestion`, `idReponse`, `bonneReponse`) VALUES (@idQuestion, @idReponse, @bonneReponse);";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@idQuestion", idQuestion);
                cmd.Parameters.AddWithValue("@idReponse", idReponse);
                cmd.Parameters.AddWithValue("@bonneReponse", bonneReponse);
                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    CloseConnection();
                    return "";
                }
                catch (MySqlException ex)
                {
                    //close connection
                    CloseConnection();
                    //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                    if (ex.Number == 1062)
                        return "Ce lien existe déjà !";
                    else
                        return ex.Message;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Créer le lien entre le QCM et son mot-clé
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        /// <param name="idMotCle">Id du mot-clé</param>
        /// <returns>Message d'erreur</returns>
        private string InsertQCM_HAS_MotCle(int idQCM, int idMotCle)
        {
            string query = "INSERT INTO `qcm_has_motcle`(`idQCM`, `idMotCle`) VALUES (@idQCM, @idMotCle);";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@idQCM", idQCM);
                cmd.Parameters.AddWithValue("@idMotCle", idMotCle);
                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    CloseConnection();
                    return "";
                }
                catch (MySqlException ex)
                {
                    //close connection
                    CloseConnection();
                    //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                    if (ex.Number == 1062)
                        return "Ce lien existe déjà !";
                    else
                        return ex.Message;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Créer une question avec les informations données
        /// </summary>
        /// <param name="id">Le titre (nom) du QCM</param>
        /// <param name="question">Le niveau du QCM</param>
        /// <returns>Le message d'erreur</returns>
        public int InsertQuestion(int idQCM, string question)
        {
            string query = "INSERT INTO `question`(`question`) VALUES (@question); SELECT LAST_INSERT_ID() as lastID;";
            int lastIdQuestion = 0;

            //open connection
            try
            {
                OpenConnection();
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, Conn);

                    cmd.Parameters.AddWithValue("@question", question);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        lastIdQuestion = dataReader.GetInt32("lastID");
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close connection
                    CloseConnection();

                    InsertQCM_HAS_QUESTION(idQCM, lastIdQuestion);
                    return lastIdQuestion;
                }
                catch (MySqlException ex)
                {
                    //close connection
                    CloseConnection();
                    //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                    if (ex.Number == 1062)
                        throw new Exception("Cette question existe déjà !");
                    else
                        throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Créer une réponse relié à la question avec l'id donnée et la défini comme vrai ou fausse
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="reponse">Texte de la réponse</param>
        /// <param name="bonneReponse">Bonne réponse ou non ?</param>
        /// <returns>Message d'erreur</returns>
        public string InsertReponses(int idQuestion, string reponse, bool bonneReponse)
        {
            string query = "INSERT INTO `reponse`(`reponse`) VALUES (@reponse); SELECT LAST_INSERT_ID() as lastID;";
            int lastId = 0;

            //open connection
            try
            {
                OpenConnection();
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, Conn);

                    cmd.Parameters.AddWithValue("@reponse", reponse);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        lastId = dataReader.GetInt32("lastID");
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close connection
                    CloseConnection();

                    return InsertQuestions_HAS_Reponses(idQuestion, lastId, bonneReponse);
                }
                catch (MySqlException ex)
                {
                    //close connection
                    CloseConnection();
                    //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                    if (ex.Number == 1062)
                        return "Cette réponse existe déjà !";
                    else
                        return ex.Message;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Créer un nouveau mot-clé avec les informations données
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        /// <param name="motCle">Texte du mot-clé</param>
        /// <returns></returns>
        public string InsertMotCle(int idQCM, string motCle)
        {
            string query = "INSERT INTO `motcle`(`motCle`) VALUES (@motCle); SELECT LAST_INSERT_ID() as lastID;";
            int lastId = 0;

            //open connection
            try
            {
                OpenConnection();
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, Conn);

                    cmd.Parameters.AddWithValue("@motCle", motCle);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        lastId = dataReader.GetInt32("lastID");
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close connection
                    CloseConnection();

                    return InsertQCM_HAS_MotCle(idQCM, lastId);
                }
                catch (MySqlException ex)
                {
                    //close connection
                    CloseConnection();
                    //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                    if (ex.Number == 1062)
                        return "Cette réponse existe déjà !";
                    else
                        return ex.Message;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// Mets à jour un QCM avec les informations fournies
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        /// <param name="nomQCM">Nom du QCM</param>
        /// <param name="level">Niveau du QCM</param>
        public void UpdateQCMByIdQCM(int idQCM, string nomQCM, int level)
        {
            string query = "UPDATE `qcm` SET `nomQCM`=@nomQCM,`level`=@level WHERE `idQCM` = @idQCM";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@idQCM", idQCM);
                cmd.Parameters.AddWithValue("@nomQCM", nomQCM);
                cmd.Parameters.AddWithValue("@level", level);
                //Execute command
                cmd.ExecuteNonQuery();
                //close connection
                CloseConnection();
            }
            catch (MySqlException ex)
            {
                //close connection
                CloseConnection();
                //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                if (ex.Number == 1062)
                    throw new Exception("Ce qcm existe déjà !");
                else
                    throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Mets à jour les réponses avec les informations fournies
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="idReponse">Id de la réponse</param>
        /// <param name="bonneReponse">Bonne réponse ou non</param>
        private void UpdateCorrectAnswerByIdReponseAndIdQuestion(int idQuestion, int idReponse, bool bonneReponse)
        {
            string query = "UPDATE `question_has_reponse` SET `bonneReponse`=@bonneReponse WHERE `idQuestion`=@idQuestion AND `idReponse`=@idReponse";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@idReponse", idReponse);
                cmd.Parameters.AddWithValue("@bonneReponse", bonneReponse);
                cmd.Parameters.AddWithValue("@idQuestion", idQuestion);
                //Execute command
                cmd.ExecuteNonQuery();
                //close connection
                CloseConnection();
            }
            catch (MySqlException ex)
            {
                //close connection
                CloseConnection();
                //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                if (ex.Number == 1062)
                    throw new Exception("Ce lien existe déjà !");
                else
                    throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Mets à jour un mot clé avec les informations fournies
        /// </summary>
        /// <param name="idMotCle">Id du mot-clé</param>
        /// <param name="motCle">Texte du mot-clé</param>
        public void UpdateMotCleByIdMotCle(int idMotCle, string motCle)
        {
            string query = "UPDATE `motcle` SET `motCle`=@motCle WHERE `idMotCle`=@idMotCle";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@idMotCle", idMotCle);
                cmd.Parameters.AddWithValue("@motCle", motCle);
                //Execute command
                cmd.ExecuteNonQuery();
                //close connection
                CloseConnection();
            }
            catch (MySqlException ex)
            {
                //close connection
                CloseConnection();
                //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                if (ex.Number == 1062)
                    throw new Exception("Ce mot-clé existe déjà !");
                else
                    throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Mets à jour une question avec les informations fournies
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="question">Texte de la question</param>
        public void UpdateQuestionByIdQuestion(int idQuestion, string question)
        {
            string query = "UPDATE `question` SET `question`=@question WHERE `idQuestion`=@idQuestion";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@idQuestion", idQuestion);
                cmd.Parameters.AddWithValue("@question", question);
                //Execute command
                cmd.ExecuteNonQuery();
                //close connection
                CloseConnection();
            }
            catch (MySqlException ex)
            {
                //close connection
                CloseConnection();
                //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                if (ex.Number == 1062)
                    throw new Exception("Cette question existe déjà !");
                else
                    throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Mets à jour une réponse avec les informations fournies
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="idReponse">Id de la réponse</param>
        /// <param name="reponse">Réponse</param>
        /// <param name="bonneReponse">Bonne réponse ou non</param>
        public void UpdateReponseByIdReponse(int idQuestion, int idReponse, string reponse, bool bonneReponse)
        {
            string query = "UPDATE `reponse` SET `reponse`=@reponse WHERE `idReponse`=@idReponse;";
            UpdateCorrectAnswerByIdReponseAndIdQuestion(idQuestion, idReponse, bonneReponse);

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                
                cmd.Parameters.AddWithValue("@idReponse", idReponse);
                cmd.Parameters.AddWithValue("@reponse", reponse);
                //Execute command
                cmd.ExecuteNonQuery();
                //close connection
                CloseConnection();
            }
            catch (MySqlException ex)
            {
                //close connection
                CloseConnection();
                //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                if (ex.Number == 1062)
                    throw new Exception("Cette réponse existe déjà !");
                else
                    throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Retire le mot-clé donné par l'id
        /// </summary>
        /// <param name="idMotCle">Id du mot-clé à retirer</param>
        /// <returns>Le message d'erreur</returns>
        public string DeleteMotCleByIdMotCle(int idMotCle)
        {
            string query = "DELETE FROM `motcle` WHERE `idMotCle` = @id;";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@id", idMotCle);
                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    CloseConnection();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Retire la question donné par l'id
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <returns>Le message d'erreur</returns>
        public string DeleteQuestionByIdQuestion(int idQuestion)
        {
            string query = "DELETE FROM `question` WHERE `idQuestion` = @id;";

            //open connection
            try
            {
                DeleteReponsesByIdQuestion(idQuestion);
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@id", idQuestion);
                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    CloseConnection();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteReponsesByIdReponse(int idReponse)
        {
            string query = "DELETE FROM `reponse` WHERE `idReponse` = @idReponse;";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@idReponse", idReponse);
                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    CloseConnection();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retire les réponses reliées à l'id de la question
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <returns>Le message d'erreur</returns>
        public string DeleteReponsesByIdQuestion(int idQuestion)
        {
            string query = "DELETE FROM `reponse` WHERE `idReponse` IN (SELECT `idReponse` FROM `question_has_reponse` WHERE `idQuestion` = @idQuestion);";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@idQuestion", idQuestion);
                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    CloseConnection();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Retire le QCM donné par l'id
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        /// <returns>Le message d'erreur</returns>
        public string DeleteQCMByIdQCM(int idQCM)
        {
            string errorReturn = "";
            foreach (KeyValuePair<int, QuestionDatas> item in SelectAllQuestionByIdQCM(idQCM))
            {
                try
                {
                    DeleteQuestionByIdQuestion(item.Key);
                }
                catch (Exception ex)
                {
                    errorReturn += ((errorReturn != "") ? errorReturn + Environment.NewLine + ex.Message : "");
                }
            }

            if (errorReturn != "")
            {
                return errorReturn;
            }

            foreach (KeyValuePair<int, MotsClesDatas> item in SelectAllMotCleByIdQCM(idQCM))
            {
                try
                {
                    DeleteMotCleByIdMotCle(item.Key);
                }
                catch (Exception ex)
                {
                    errorReturn += ((errorReturn != "") ? errorReturn + Environment.NewLine + ex.Message : "");
                }
            }

            if (errorReturn != "")
            {
                return errorReturn;
            }

            string query = "DELETE FROM `qcm` WHERE `idQCM` = @id;";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Conn);

                cmd.Parameters.AddWithValue("@id", idQCM);
                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    CloseConnection();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
    }
}