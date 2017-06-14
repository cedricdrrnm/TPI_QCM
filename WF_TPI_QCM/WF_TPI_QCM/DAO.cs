using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    class DAO
    {
        static MySqlConnection conn;

        /// <summary>
        /// Initialise la connection
        /// </summary>
        public DAO()
        {
            conn = new MySqlConnection("SERVER=" + Properties.Settings.Default.DB_Host + ";" + "DATABASE=" + Properties.Settings.Default.DB_Name + ";" + "UID=" + Properties.Settings.Default.DB_Username + ";" + "PASSWORD=" + Properties.Settings.Default.DB_Password + ";");
        }

        /// <summary>
        /// Ouvre la connection
        /// </summary>
        /// <returns>Retourne vrai (true) s'il n'y a aucun problème sinon retourne faux (false)</returns>
        public void OpenConnection()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
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
                conn = null;
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
                conn.Close();
            }
            catch (MySqlException ex)
            {
                throw new Exception("La connection ne peut pas être fermée :" + ex.Message);
            }
        }

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
                MySqlCommand cmd = new MySqlCommand(query, conn);
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
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    dictQuestion.Add(dataReader.GetInt32("idQuestion"), new QuestionDatas(dataReader.GetString("question")));
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
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    dictReponse.Add(dataReader.GetInt32("idReponse"), new ReponseDatas(dataReader.GetString("reponse"), dataReader.GetBoolean("bonneReponse")));
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

        public Dictionary<int, string> SelectAllMotCleByIdQCM(int id)
        {
            string query = "SELECT m.`idMotCle`, m.`motCle` FROM `motcle` as m,`qcm_has_motcle` as qhm, `qcm` as q WHERE m.`idMotCle` = qhm.`idMotCle` AND qhm.`idQCM` = q.`idQCM` AND q.`idQCM` = @id;";

            //Create a list to store the result
            Dictionary<int, string> listMotCle = new Dictionary<int, string>();

            //Open connection
            try
            {
                OpenConnection();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    listMotCle.Add(dataReader.GetInt32("idMotCle"), dataReader.GetString("motCle"));
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
                MySqlCommand cmd = new MySqlCommand(query, conn);
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
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Parameters
                cmd.Parameters.AddWithValue("@idQCM", idQCM);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    qcmModele = new QCMDatas(dataReader.GetInt32("idQCM"), dataReader.GetString("nomQCM"), dataReader.GetInt32("level"));
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

        public void InsertQCM(string nomQCM, int level)
        {
            string query = "INSERT INTO `qcm`(`nomQCM`,`level`) VALUES (@nomSubject, @level);";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nomSubject", nomQCM);
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

        public void UpdateQCMByIdQCM(int idQCM, string nomQCM, int level)
        {
            string query = "UPDATE `qcm` SET `nomQCM`=@nomQCM,`level`=@level WHERE `idQCM` = @idQCM";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

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

        public void DeleteQCMByIdQCM(int idQCM)
        {
            string query = "DELETE FROM `qcm` WHERE `idQCM` = @idQCM";

            //open connection
            try
            {
                OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@idQCM", idQCM);
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
    }
}








































///*
// * Changements de la méthode par array en la méthode "GetString", "GetInt32" ou "GetBoolean"
// https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldatareader.getstring(v=vs.110).aspx
// https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldatareader.getint32(v=vs.110).aspx
// https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldatareader.getboolean%28v=vs.110%29.aspx
// */
//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;

//namespace WF_TPI_QCM
//{
//    static class DAO
//    {
//        static MySqlConnection conn;

//        /// <summary>
//        /// Initialise la connection
//        /// </summary>
//        static public void CreateConnection()
//        {
//            if (conn == null)
//                conn = new MySqlConnection("SERVER=" + Properties.Settings.Default.DB_Host + ";" + "DATABASE=" + Properties.Settings.Default.DB_Name + ";" + "UID=" + Properties.Settings.Default.DB_Username + ";" + "PASSWORD=" + Properties.Settings.Default.DB_Password + ";");
//        }

//        /// <summary>
//        /// Ouvre la connection
//        /// </summary>
//        /// <returns>Retourne vrai (true) s'il n'y a aucun problème sinon retourne faux (false)</returns>
//        static public void OpenConnection()
//        {
//            if (conn == null)
//                CreateConnection();
//            try
//            {
//                if (conn.State != System.Data.ConnectionState.Open)
//                {
//                    conn.Open();
//                }
//            }
//            catch (MySqlException ex)
//            {
//                switch (ex.Number)
//                {
//                    case 0:
//                        new Exception("Impossible de se connecter à la base de données");
//                        break;

//                    case 1045:
//                        new Exception("Nom d'utilisateur ou mot de passe invalides !");
//                        break;

//                    default:
//                        new Exception("Erreur lors de la connection: " + ex.Message);
//                        break;
//                }
//                conn = null;
//                throw new Exception("Connection échouée !");
//            }
//        }

//        /// <summary>
//        /// Ferme la connection
//        /// </summary>
//        /// <returns>Retourne vrai (true) s'il n'y a aucun problème sinon retourne faux (false)</returns>
//        static private void CloseConnection()
//        {
//            try
//            {
//                conn.Close();
//            }
//            catch (MySqlException ex)
//            {
//                throw new Exception("La connection ne peut pas être fermée :" + ex.Message);
//            }
//        }

//        #region Select

//        /// <summary>
//        /// Retourne toutes les questions qui sont dans le QCM donné par l'id
//        /// </summary>
//        /// <param name="id">Id du QCM</param>
//        /// <returns>Toutes les questions qui sont dans le QCM donné par l'id</returns>
//        static public Dictionary<int, QuestionModele> SelectAllQuestionByIdQCM(int id)
//        {
//            string query = "SELECT qu.`idQuestion`, qu.`question` FROM `question` as qu,`qcm_has_question` as qhq, `qcm` as q WHERE qu.`idQuestion` = qhq.`idQuestion` AND qhq.`idQCM` = q.`idQCM` AND q.`idQCM` = @id";

//            //Create a list to store the result
//            Dictionary<int, QuestionModele> dictQuestion = new Dictionary<int, QuestionModele>();

//            //Open connection
//            try
//            {
//                OpenConnection();
//                //Create Command
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                //Parameters
//                cmd.Parameters.AddWithValue("@id", id);

//                //Create a data reader and Execute the command
//                MySqlDataReader dataReader = cmd.ExecuteReader();

//                //Read the data and store them in the list
//                while (dataReader.Read())
//                {
//                    dictQuestion.Add(dataReader.GetInt32("idQuestion"), new QuestionModele(dataReader.GetString("question")));
//                }

//                //close Data Reader
//                dataReader.Close();

//                //close Connection
//                CloseConnection();

//                //return list to be displayed
//                return dictQuestion;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        /// <summary>
//        /// Retourne toutes les réponses qui sont reliées à la question donnée par l'id
//        /// </summary>
//        /// <param name="id">Id de la question</param>
//        /// <returns>Toutes les réponses qui sont reliées à la question donnée par l'id</returns>
//        static public Dictionary<string, bool> SelectAllReponseByIdQuestion(int id)
//        {
//            string query = "SELECT r.`idReponse`, r.`reponse`, qhr.`bonneReponse` FROM `reponse` as r, `question` as q, `question_has_reponse` as qhr WHERE r.`idReponse` = qhr.`idReponse` AND qhr.`idQuestion` = q.`idQuestion` AND q.`idQuestion` = @id";

//            //Create a list to store the result
//            Dictionary<string, bool> listReponse = new Dictionary<string, bool>();

//            //Open connection
//            try
//            {
//                OpenConnection();
//                //Create Command
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                //Parameters
//                cmd.Parameters.AddWithValue("@id", id);

//                //Create a data reader and Execute the command
//                MySqlDataReader dataReader = cmd.ExecuteReader();

//                //Read the data and store them in the list
//                while (dataReader.Read())
//                {
//                    listReponse.Add(dataReader.GetString("reponse"), dataReader.GetBoolean("bonneReponse"));
//                }

//                //close Data Reader
//                dataReader.Close();

//                //close Connection
//                CloseConnection();

//                //return list to be displayed
//                return listReponse;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        /// <summary>
//        /// Retourne tous les mots-clés qui sont dans le QCM donné par l'id
//        /// </summary>
//        /// <param name="id">Id du QCM</param>
//        /// <returns>Tous les mots-clés qui sont dans le QCM donné par l'id</returns>
//        static public Dictionary<int, string> SelectAllMotCleByIdQCM(int id)
//        {
//            string query = "SELECT m.`idMotCle`, m.`motCle` FROM `motcle` as m,`qcm_has_motcle` as qhm, `qcm` as q WHERE m.`idMotCle` = qhm.`idMotCle` AND qhm.`idQCM` = q.`idQCM` AND q.`idQCM` = @id;";

//            //Create a list to store the result
//            Dictionary<int, string> listMotCle = new Dictionary<int, string>();

//            //Open connection
//            try
//            {
//                OpenConnection();
//                //Create Command
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                //Parameters
//                cmd.Parameters.AddWithValue("@id", id);

//                //Create a data reader and Execute the command
//                MySqlDataReader dataReader = cmd.ExecuteReader();

//                //Read the data and store them in the list
//                while (dataReader.Read())
//                {
//                    listMotCle.Add(dataReader.GetInt32("idMotCle"), dataReader.GetString("motCle"));
//                }

//                //close Data Reader
//                dataReader.Close();

//                //close Connection
//                CloseConnection();

//                //return list to be displayed
//                return listMotCle;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        /// <summary>
//        /// Retourne le level (niveau) qui est dans le QCM donné par l'id
//        /// </summary>
//        /// <param name="id">Id du QCM</param>
//        /// <returns>Le level (niveau) qui est dans le QCM donné par l'id</returns>
//        static public int SelectLevelByIdQCM(int id)
//        {
//            string query = "SELECT `qcm`.`level` FROM `qcm` WHERE `qcm`.`idQCM` = @id;";
//            int level = 0;

//            //Open connection
//            try
//            {
//                OpenConnection();
//                //Create Command
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                //Parameters
//                cmd.Parameters.AddWithValue("@id", id);

//                //Create a data reader and Execute the command
//                MySqlDataReader dataReader = cmd.ExecuteReader();

//                //Read the data and store them in the list
//                while (dataReader.Read())
//                {
//                    level = dataReader.GetInt32("level");
//                }

//                //close Data Reader
//                dataReader.Close();

//                //close Connection
//                CloseConnection();

//                //return list to be displayed
//                return level;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        /// <summary>
//        /// Retourne le titre du QCM donné par l'id
//        /// </summary>
//        /// <param name="id">Id du QCM</param>
//        /// <returns>Le titre du QCM donné par l'id</returns>
//        static public string SelectTitreQCMByIdQCM(int id)
//        {
//            string query = "SELECT `qcm`.`nomQCM` FROM `qcm` WHERE `qcm`.`idQCM` = @id;";
//            string nomQCM = "";

//            //Open connection
//            try
//            {
//                OpenConnection();
//                //Create Command
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                //Parameters
//                cmd.Parameters.AddWithValue("@id", id);

//                //Create a data reader and Execute the command
//                MySqlDataReader dataReader = cmd.ExecuteReader();

//                //Read the data and store them in the list
//                while (dataReader.Read())
//                {
//                    nomQCM = dataReader.GetString("nomQCM");
//                }

//                //close Data Reader
//                dataReader.Close();

//                //close Connection
//                CloseConnection();

//                //return list to be displayed
//                return nomQCM;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        /// <summary>
//        /// Retourne le texte de la question donnée par l'id
//        /// </summary>
//        /// <param name="id">Id de la question</param>
//        /// <returns>Le texte de la question donnée par l'id</returns>
//        static public string SelectTextQuestionByIdQuestion(int id)
//        {
//            string query = "SELECT q.`question` FROM `question` as q WHERE q.`idQuestion` = @id;";
//            string titre = "";

//            //Open connection
//            try
//            {
//                OpenConnection();
//                //Create Command
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                //Parameters
//                cmd.Parameters.AddWithValue("@id", id);

//                //Create a data reader and Execute the command
//                MySqlDataReader dataReader = cmd.ExecuteReader();

//                //Read the data and store them in the list
//                while (dataReader.Read())
//                {
//                    titre = dataReader.GetString("question");
//                }

//                //close Data Reader
//                dataReader.Close();

//                //close Connection
//                CloseConnection();

//                //return list to be displayed
//                return titre;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        #endregion

//        #region Update

//        /// <summary>
//        /// Change les informations du QCM donné par l'id avec les nouvelles informations
//        /// </summary>
//        /// <param name="nomQCM">Titre (nom) du QCM</param>
//        /// <param name="level">Level (niveau) du QCM</param>
//        /// <param name="idQCM">Id du QCM</param>
//        /// <returns>Message d'erreur</returns>
//        static public string UpdateQCMByIdQCM(string nomQCM, string level, int idQCM)
//        {
//            string query = "UPDATE `qcm` SET `nomQCM`=@nomQCM,`level`=@level WHERE `idQCM`= @idQCM";

//            //open connection
//            try
//            {
//                OpenConnection();
//                //create command and assign the query and connection from the constructor
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                cmd.Parameters.AddWithValue("@nomQCM", nomQCM);
//                cmd.Parameters.AddWithValue("@level", level);
//                cmd.Parameters.AddWithValue("@idQCM", idQCM);
//                //Execute command
//                cmd.ExecuteNonQuery();
//                //close connection
//                CloseConnection();
//                return "";

//            }
//            catch (MySqlException ex)
//            {
//                //close connection
//                CloseConnection();
//                //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
//                if (ex.Number == 1062)
//                    return "Ce qcm existe déjà !";
//                else
//                    return ex.Message;
//            }
//            catch (Exception ex)
//            {
//                return ex.Message;
//            }
//        }

//        #endregion

//        #region Delete

//        /// <summary>
//        /// Retire le mot-clé donné par l'id
//        /// </summary>
//        /// <param name="idMotCle">Id du mot-clé à retirer</param>
//        /// <returns>Le message d'erreur</returns>
//        static public string DeleteMotCleByIdMotCle(int idMotCle)
//        {
//            string query = "DELETE FROM `motcle` WHERE `idMotCle` = @id;";

//            //open connection
//            try
//            {
//                OpenConnection();
//                //create command and assign the query and connection from the constructor
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                cmd.Parameters.AddWithValue("@id", idMotCle);
//                //Execute command
//                cmd.ExecuteNonQuery();
//                //close connection
//                CloseConnection();
//                return "";
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        /*/// <summary>
//        /// Retire la question donné par l'id
//        /// </summary>
//        /// <param name="idQuestion">Id de la question</param>
//        /// <returns>Le message d'erreur</returns>
//        static public string DeleteQuestionByIdQuestion(int idQuestion)
//        {
//            string tempError = DeleteReponsesByIdQuestion(idQuestion);
//            if (tempError != "")
//                return tempError;

//            string query = "DELETE FROM `question` WHERE `idQuestion` = @id;";

//            //open connection
//            if (OpenConnection())
//            {
//                //create command and assign the query and connection from the constructor
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                cmd.Parameters.AddWithValue("@id", idQuestion);
//                try
//                {
//                    //Execute command
//                    cmd.ExecuteNonQuery();
//                    //close connection
//                    CloseConnection();
//                    return "";
//                }
//                catch (Exception ex)
//                {
//                    return ex.Message;
//                }
//            }
//            else
//            {
//                return "Erreur avec la connection !";
//            }
//        }*/

//        /*/// <summary>
//        /// Retire les réponses reliées à l'id de la question
//        /// </summary>
//        /// <param name="idQuestion">Id de la question</param>
//        /// <returns>Le message d'erreur</returns>
//        static public string DeleteReponsesByIdQuestion(int idQuestion)
//        {
//            string query = "DELETE FROM `reponse` WHERE `idReponse` IN (SELECT `idReponse` FROM `question_has_reponse` WHERE `idQuestion` = @idQuestion);";

//            //open connection
//            if (OpenConnection())
//            {
//                //create command and assign the query and connection from the constructor
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                cmd.Parameters.AddWithValue("@idQuestion", idQuestion);
//                try
//                {
//                    //Execute command
//                    cmd.ExecuteNonQuery();
//                    //close connection
//                    CloseConnection();
//                    return "";
//                }
//                catch (Exception ex)
//                {
//                    return ex.Message;
//                }
//            }
//            else
//            {
//                return "Erreur avec la connection !";
//            }
//        }*/

//        /*/// <summary>
//        /// Retire le QCM donné par l'id
//        /// </summary>
//        /// <param name="idQCM">Id du QCM</param>
//        /// <returns>Le message d'erreur</returns>
//        static public string DeleteQCMByIdQCM(int idQCM)
//        {
//            string query = "DELETE FROM `qcm` WHERE `idQCM` = @id;";

//            //open connection
//            if (OpenConnection())
//            {
//                //create command and assign the query and connection from the constructor
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                cmd.Parameters.AddWithValue("@id", idQCM);
//                try
//                {
//                    //Execute command
//                    cmd.ExecuteNonQuery();
//                    //close connection
//                    CloseConnection();
//                    return "";
//                }
//                catch (Exception ex)
//                {
//                    return ex.Message;
//                }
//            }
//            else
//            {
//                return "Erreur avec la connection !";
//            }
//        }*/
//        #endregion

//        public static QCMModele SelectQCMById(int idQCM)
//        {
//            //Open connection
//            try
//            {
//                OpenConnection();
//                string query = "";

//                /*"SELECT qcm.`idQCM`, qcm.`nomQCM`, qcm.`level`, q.`idQuestion`, q.`question`, r.`idReponse`, r.`reponse`, qhr.`bonneReponse`, m.`idMotCle`, m.`motCle`" +
//        "FROM `qcm`, " +
//        "`qcm_has_question` as qhq, " +
//        "`question` as q, " +
//        "`question_has_reponse` as qhr, " +
//        "`reponse` as r, " +
//        "`qcm_has_motcle` as qhm, " +
//        "`motcle` as m " +
//        "WHERE " +
//        "qcm.`idQCM` = qhq.`idQCM` AND " +
//        "qhq.`idQuestion` = q.`idQuestion` AND " +
//        "q.`idQuestion` = qhr.`idQuestion` AND " +
//        "qhr.`idReponse` = r.`idReponse` AND " +
//        "qcm.`idQCM` = qhm.`idQCM` AND " +
//        "qhm.`idMotCle` = m.`idMotCle` AND " +
//        "qcm.`idQCM` = @idQCM " +
//        "ORDER BY `q`.`idQuestion` ASC"*/

//                //Create a QCMModele to store the result
//                QCMModele qcmModele = null;

//                //Create Command
//                MySqlCommand cmd = new MySqlCommand(query, conn);

//                //Parameters
//                cmd.Parameters.AddWithValue("@idQCM", idQCM);

//                //Create a data reader and Execute the command
//                MySqlDataReader dataReader = cmd.ExecuteReader();

//                QuestionModele question = null;
//                ReponseModele reponse = null;
//                List<ReponseModele> listReponse = new List<ReponseModele>();
//                Dictionary<QuestionModele, List<ReponseModele>> dictQuestionReponse = new Dictionary<QuestionModele, List<ReponseModele>>();
//                List<string> listMotCles = new List<string>();
//                //Read the data and store them in the list
//                while (dataReader.Read())
//                {
//                    if (qcmModele == null)
//                    {
//                        qcmModele = new QCMModele(dataReader.GetInt32("idQCM"), dataReader.GetString("nomQCM"), dataReader.GetInt32("level"));
//                    }

//                    qcmModele.AddMotsCles(dataReader.GetInt32("idMotCle"), dataReader.GetString("motCle"));

//                    question = new QuestionModele(dataReader.GetString("question"));
//                    qcmModele.AddQuestion(dataReader.GetInt32("idQuestion"), question);

//                    reponse = new ReponseModele(dataReader.GetString("reponse"), dataReader.GetBoolean("bonneReponse"));
//                    qcmModele.AddReponseToQuestion(dataReader.GetInt32("idQuestion"), dataReader.GetInt32("idReponse"), reponse);

//                    listReponse.Add(reponse);
//                }

//                //close Data Reader
//                dataReader.Close();

//                //close Connection
//                CloseConnection();

//                Dictionary<string, int> auto_increment_value = SelectAutoIncrement();

//                if (qcmModele != null)
//                {
//                    int _nextID;
//                    if (auto_increment_value.TryGetValue("motcle", out _nextID))
//                    {
//                        qcmModele.NextIdMotCle = _nextID;
//                        if (auto_increment_value.TryGetValue("question", out _nextID))
//                        {
//                            qcmModele.NextIdQuestion = _nextID;
//                            if (auto_increment_value.TryGetValue("reponse", out _nextID))
//                            {
//                                qcmModele.NextIdReponse = _nextID;

//                                //return list to be displayed
//                                return qcmModele;
//                            }
//                        }
//                    }
//                }
//                return null;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        public static Dictionary<int, string> SelectAllQCM()
//        {
//            string query = "SELECT * FROM qcm";

//            //Create a list to store the result
//            Dictionary<int, string> listQCMModele = new Dictionary<int, string>();

//            //Open connection
//            try
//            {
//                //Create Command
//                MySqlCommand cmd = new MySqlCommand(query, conn);
//                //Create a data reader and Execute the command
//                MySqlDataReader dataReader = cmd.ExecuteReader();

//                //Read the data and store them in the list
//                while (dataReader.Read())
//                {
//                    listQCMModele.Add(dataReader.GetInt32("idQCM"), dataReader.GetString("nomQCM"));
//                }

//                //close Data Reader
//                dataReader.Close();

//                //close Connection
//                CloseConnection();

//                //return list to be displayed
//                return listQCMModele;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}


