/*
 * Changements de la méthode par array en la méthode "GetString", "GetInt32" ou "GetBoolean"
 https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldatareader.getstring(v=vs.110).aspx
 https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldatareader.getint32(v=vs.110).aspx
 https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldatareader.getboolean%28v=vs.110%29.aspx
 */
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WF_TPI_QCM
{
    static class DAO
    {
        static MySqlConnection conn;

        /// <summary>
        /// Initialise la connection
        /// </summary>
        static public void CreateConnection()
        {
            if (conn == null)
                conn = new MySqlConnection("SERVER=" + Properties.Settings.Default.DB_Host + ";" + "DATABASE=" + Properties.Settings.Default.DB_Name + ";" + "UID=" + Properties.Settings.Default.DB_Username + ";" + "PASSWORD=" + Properties.Settings.Default.DB_Password + ";");
        }

        /// <summary>
        /// Ouvre la connection
        /// </summary>
        /// <returns>Retourne vrai (true) s'il n'y a aucun problème sinon retourne faux (false)</returns>
        static public bool OpenConnection()
        {
            if (conn == null)
                CreateConnection();
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Impossible de se connecter à la base de données");
                        break;

                    case 1045:
                        MessageBox.Show("Nom d'utilisateur ou mot de passe invalides !");
                        break;

                    default:
                        MessageBox.Show("Erreur lors de la connection");
                        break;
                }
                conn = null;
                return false;
            }
        }

        /// <summary>
        /// Ferme la connection
        /// </summary>
        /// <returns>Retourne vrai (true) s'il n'y a aucun problème sinon retourne faux (false)</returns>
        static private bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /*
        #region Select
        
        /// <summary>
        /// Retourne toutes les questions qui sont dans le QCM donné par l'id
        /// </summary>
        /// <param name="id">Id du QCM</param>
        /// <returns>Toutes les questions qui sont dans le QCM donné par l'id</returns>
        static public Dictionary<int, string> SelectAllQuestionByIdQCM(int id)
        {
            string query = "SELECT qu.`idQuestion`, qu.`question` FROM `question` as qu,`qcm_has_question` as qhq, `qcm` as q WHERE qu.`idQuestion` = qhq.`idQuestion` AND qhq.`idQCM` = q.`idQCM` AND q.`idQCM` = @id";

            //Create a list to store the result
            Dictionary<int, string> listQuestion = new Dictionary<int, string>();

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    listQuestion.Add(dataReader.GetInt32("idQuestion"), dataReader.GetString("question"));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return listQuestion;
            }
            else
            {
                return listQuestion;
            }
        }

        /// <summary>
        /// Retourne toutes les réponses qui sont reliées à la question donnée par l'id
        /// </summary>
        /// <param name="id">Id de la question</param>
        /// <returns>Toutes les réponses qui sont reliées à la question donnée par l'id</returns>
        static public Dictionary<string, bool> SelectAllReponseByIdQuestion(int id)
        {
            string query = "SELECT r.`idReponse`, r.`reponse`, qhr.`bonneReponse` FROM `reponse` as r, `question` as q, `question_has_reponse` as qhr WHERE r.`idReponse` = qhr.`idReponse` AND qhr.`idQuestion` = q.`idQuestion` AND q.`idQuestion` = @id";

            //Create a list to store the result
            Dictionary<string, bool> listReponse = new Dictionary<string, bool>();

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    listReponse.Add(dataReader.GetString("reponse"), dataReader.GetBoolean("bonneReponse"));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return listReponse;
            }
            else
            {
                return listReponse;
            }
        }

        /// <summary>
        /// Retourne tous les mots-clés qui sont dans le QCM donné par l'id
        /// </summary>
        /// <param name="id">Id du QCM</param>
        /// <returns>Tous les mots-clés qui sont dans le QCM donné par l'id</returns>
        static public Dictionary<int, string> SelectAllMotCleByIdQCM(int id)
        {
            string query = "SELECT m.`idMotCle`, m.`motCle` FROM `motcle` as m,`qcm_has_motcle` as qhm, `qcm` as q WHERE m.`idMotCle` = qhm.`idMotCle` AND qhm.`idQCM` = q.`idQCM` AND q.`idQCM` = @id;";

            //Create a list to store the result
            Dictionary<int, string> listMotCle = new Dictionary<int, string>();

            //Open connection
            if (OpenConnection() == true)
            {
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
            else
            {
                return listMotCle;
            }
        }

        /// <summary>
        /// Retourne le level (niveau) qui est dans le QCM donné par l'id
        /// </summary>
        /// <param name="id">Id du QCM</param>
        /// <returns>Le level (niveau) qui est dans le QCM donné par l'id</returns>
        static public int SelectLevelByIdQCM(int id)
        {
            string query = "SELECT `qcm`.`level` FROM `qcm` WHERE `qcm`.`idQCM` = @id;";
            int level = 0;

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    level = dataReader.GetInt32("level");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return level;
            }
            else
            {
                return level;
            }
        }

        /// <summary>
        /// Retourne le titre du QCM donné par l'id
        /// </summary>
        /// <param name="id">Id du QCM</param>
        /// <returns>Le titre du QCM donné par l'id</returns>
        static public string SelectTitreQCMByIdQCM(int id)
        {
            string query = "SELECT `qcm`.`nomQCM` FROM `qcm` WHERE `qcm`.`idQCM` = @id;";
            string nomQCM = "";

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    nomQCM = dataReader.GetString("nomQCM");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return nomQCM;
            }
            else
            {
                return nomQCM;
            }
        }

        /// <summary>
        /// Retourne le texte de la question donnée par l'id
        /// </summary>
        /// <param name="id">Id de la question</param>
        /// <returns>Le texte de la question donnée par l'id</returns>
        static public string SelectTextQuestionByIdQuestion(int id)
        {
            string query = "SELECT q.`question` FROM `question` as q WHERE q.`idQuestion` = @id;";
            string titre = "";

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    titre = dataReader.GetString("question");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return titre;
            }
            else
            {
                return titre;
            }
        }

        #endregion
        */

        #region Insert

        #region Liaisons

        /// <summary>
        /// Créer le lien entre le QCM et sa question
        /// </summary>
        /// <param name="idQCM">L'id du QCM</param>
        /// <param name="idQuestion">L'id de la question</param>
        /// <returns>Le message d'erreur</returns>
        static private string InsertQCM_HAS_QUESTION(int idQCM, int idQuestion)
        {
            string query = "INSERT INTO `qcm_has_question`(`idQCM`, `idQuestion`) VALUES (@idQCM, @idQuestion);";

            //open connection
            if (OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

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
            else
            {
                return "Erreur avec la connection !";
            }
        }

        /// <summary>
        /// Créer le lien entre la question et sa réponse
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="idReponse">Id de la réponse</param>
        /// <param name="bonneReponse">Bonne réponse ou non ?</param>
        /// <returns>Message d'erreur</returns>
        static private string InsertQuestions_HAS_Reponses(int idQuestion, int idReponse, bool bonneReponse)
        {
            string query = "INSERT INTO `question_has_reponse`(`idQuestion`, `idReponse`, `bonneReponse`) VALUES (@idQuestion, @idReponse, @bonneReponse);";

            //open connection
            if (OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

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
            else
            {
                return "Erreur avec la connection !";
            }
        }

        /// <summary>
        /// Créer le lien entre le QCM et son mot-clé
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        /// <param name="idMotCle">Id du mot-clé</param>
        /// <returns>Message d'erreur</returns>
        static private string InsertQCM_HAS_MotCle(int idQCM, int idMotCle)
        {
            string query = "INSERT INTO `qcm_has_motcle`(`idQCM`, `idMotCle`) VALUES (@idQCM, @idMotCle);";

            //open connection
            if (OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

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
            else
            {
                return "Erreur avec la connection !";
            }
        }

        #endregion

        #region Données

        /// <summary>
        /// Créer un QCM avec les informations données
        /// </summary>
        /// <param name="nomQCM">Le titre (nom) du QCM</param>
        /// <param name="level">Le level (niveau) du QCM</param>
        /// <returns>Le message d'erreur</returns>
        static public string InsertQCM(string nomQCM, string level)
        {
            string query = "INSERT INTO `qcm`(`nomQCM`,`level`) VALUES (@nomSubject, @level);";

            //open connection
            if (OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nomSubject", nomQCM);
                cmd.Parameters.AddWithValue("@level", level);
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
                        return "Ce qcm existe déjà !";
                    else
                        return ex.Message;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Erreur avec la connection !";
            }
        }

        /// <summary>
        /// Créer une question avec les informations données
        /// </summary>
        /// <param name="id">Le titre (nom) du QCM</param>
        /// <param name="question">Le niveau du QCM</param>
        /// <returns>Le message d'erreur</returns>
        static public string InsertQuestion(int idQCM, string question, Dictionary<string, bool> reponses)
        {
            string query = "INSERT INTO `question`(`question`) VALUES (@question); SELECT LAST_INSERT_ID() as lastID;";
            int lastIdQuestion = 0;
            string errorReturn = "";
            string tempError = "";

            //open connection
            if (OpenConnection())
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, conn);

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

                    tempError = InsertQCM_HAS_QUESTION(idQCM, lastIdQuestion);
                    errorReturn = ((tempError != "") ? tempError + Environment.NewLine : "");

                    foreach (KeyValuePair<string, bool> item in reponses)
                    {
                        tempError = InsertReponses(lastIdQuestion, item.Key, item.Value);
                        errorReturn += ((tempError != "") ? tempError + Environment.NewLine : "");
                    }
                    return errorReturn;
                }
                catch (MySqlException ex)
                {
                    //close connection
                    CloseConnection();
                    //https://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                    if (ex.Number == 1062)
                        return "Cette question existe déjà !";
                    else
                        return ex.Message;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Erreur avec la connection !";
            }
        }

        /// <summary>
        /// Créer une réponse relié à la question avec l'id donnée et la défini comme vrai ou fausse
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="reponse">Texte de la réponse</param>
        /// <param name="bonneReponse">Bonne réponse ou non ?</param>
        /// <returns>Message d'erreur</returns>
        static private string InsertReponses(int idQuestion, string reponse, bool bonneReponse)
        {
            string query = "INSERT INTO `reponse`(`reponse`) VALUES (@reponse); SELECT LAST_INSERT_ID() as lastID;";
            int lastId = 0;

            //open connection
            if (OpenConnection())
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, conn);

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
            else
            {
                return "Erreur avec la connection !";
            }
        }

        /// <summary>
        /// Créer un nouveau mot-clé avec les informations données
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        /// <param name="motCle">Texte du mot-clé</param>
        /// <returns></returns>
        static public string InsertMotCle(int idQCM, string motCle)
        {
            string query = "INSERT INTO `motcle`(`motCle`) VALUES (@motCle); SELECT LAST_INSERT_ID() as lastID;";
            int lastId = 0;

            //open connection
            if (OpenConnection())
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, conn);

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
            else
            {
                return "Erreur avec la connection !";
            }
        }

        #endregion

        #endregion

        #region Update

        /// <summary>
        /// Change les informations du QCM donné par l'id avec les nouvelles informations
        /// </summary>
        /// <param name="nomQCM">Titre (nom) du QCM</param>
        /// <param name="level">Level (niveau) du QCM</param>
        /// <param name="idQCM">Id du QCM</param>
        /// <returns>Message d'erreur</returns>
        static public string UpdateQCMByIdQCM(string nomQCM, string level, int idQCM)
        {
            string query = "UPDATE `qcm` SET `nomQCM`=@nomQCM,`level`=@level WHERE `idQCM`= @idQCM";

            //open connection
            if (OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nomQCM", nomQCM);
                cmd.Parameters.AddWithValue("@level", level);
                cmd.Parameters.AddWithValue("@idQCM", idQCM);
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
                        return "Ce qcm existe déjà !";
                    else
                        return ex.Message;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Erreur avec la connection !";
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Retire le mot-clé donné par l'id
        /// </summary>
        /// <param name="idMotCle">Id du mot-clé à retirer</param>
        /// <returns>Le message d'erreur</returns>
        static public string DeleteMotCleByIdMotCle(int idMotCle)
        {
            string query = "DELETE FROM `motcle` WHERE `idMotCle` = @id;";

            //open connection
            if (OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

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
            else
            {
                return "Erreur avec la connection !";
            }
        }

        /// <summary>
        /// Retire la question donné par l'id
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <returns>Le message d'erreur</returns>
        static public string DeleteQuestionByIdQuestion(int idQuestion)
        {
            string tempError = DeleteReponsesByIdQuestion(idQuestion);
            if (tempError != "")
                return tempError;

            string query = "DELETE FROM `question` WHERE `idQuestion` = @id;";

            //open connection
            if (OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

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
            else
            {
                return "Erreur avec la connection !";
            }
        }

        /// <summary>
        /// Retire les réponses reliées à l'id de la question
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <returns>Le message d'erreur</returns>
        static public string DeleteReponsesByIdQuestion(int idQuestion)
        {
            string query = "DELETE FROM `reponse` WHERE `idReponse` IN (SELECT `idReponse` FROM `question_has_reponse` WHERE `idQuestion` = @idQuestion);";

            //open connection
            if (OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

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
            else
            {
                return "Erreur avec la connection !";
            }
        }

        /*/// <summary>
        /// Retire le QCM donné par l'id
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        /// <returns>Le message d'erreur</returns>
        static public string DeleteQCMByIdQCM(int idQCM)
        {
            string tempError;
            string errorReturn = "";
            foreach (QuestionModele<int, string> item in SelectAllQuestionByIdQCM(idQCM))
            {
                tempError = DeleteQuestionByIdQuestion(item.Key);
                errorReturn += ((errorReturn != "") ? errorReturn + Environment.NewLine + tempError : "");
            }

            if (errorReturn != "")
            {
                return errorReturn;
            }

            foreach (KeyValuePair<int, string> item in SelectAllMotCleByIdQCM(idQCM))
            {
                tempError = DeleteMotCleByIdMotCle(item.Key);
                errorReturn += ((errorReturn != "") ? errorReturn + Environment.NewLine + tempError : "");
            }

            if (errorReturn != "")
            {
                return errorReturn;
            }

            string query = "DELETE FROM `qcm` WHERE `idQCM` = @id;";

            //open connection
            if (OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

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
            else
            {
                return "Erreur avec la connection !";
            }
        }*/
        #endregion

        public static QCMModele SelectQCMById(int idQCM)
        {
            //Open connection
            if (OpenConnection() == true)
            {
                string query = "SELECT qcm.`idQCM`, qcm.`nomQCM`, qcm.`level`, q.`idQuestion`, q.`question`, r.`idReponse`, r.`reponse`, qhr.`bonneReponse`, m.`idMotCle`, m.`motCle`" +
    "FROM `qcm`, " +
    "`qcm_has_question` as qhq, " +
    "`question` as q, " +
    "`question_has_reponse` as qhr, " +
    "`reponse` as r, " +
    "`qcm_has_motcle` as qhm, " +
    "`motcle` as m " +
    "WHERE " +
    "qcm.`idQCM` = qhq.`idQCM` AND " +
    "qhq.`idQuestion` = q.`idQuestion` AND " +
    "q.`idQuestion` = qhr.`idQuestion` AND " +
    "qhr.`idReponse` = r.`idReponse` AND " +
    "qcm.`idQCM` = qhm.`idQCM` AND " +
    "qhm.`idMotCle` = m.`idMotCle` AND " +
    "qcm.`idQCM` = @idQCM " +
    "ORDER BY `q`.`idQuestion` ASC";

                //Create a QCMModele to store the result
                QCMModele qcmModele = null;

                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Parameters
                cmd.Parameters.AddWithValue("@idQCM", idQCM);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                QuestionModele question = null;
                ReponseModele reponse = null;
                List<ReponseModele> listReponse = new List<ReponseModele>();
                Dictionary<QuestionModele, List<ReponseModele>> dictQuestionReponse = new Dictionary<QuestionModele, List<ReponseModele>>();
                List<string> listMotCles = new List<string>();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    if (qcmModele == null)
                    {
                        qcmModele = new QCMModele(dataReader.GetInt32("idQCM"), dataReader.GetString("nomQCM"), dataReader.GetInt32("level"));
                    }

                    qcmModele.AddMotsCles(dataReader.GetInt32("idMotCle"), dataReader.GetString("motCle"));

                    question = new QuestionModele(dataReader.GetString("question"));
                    qcmModele.AddQuestion(dataReader.GetInt32("idQuestion"), question);

                    reponse = new ReponseModele(dataReader.GetString("reponse"), dataReader.GetBoolean("bonneReponse"));
                    qcmModele.AddReponseToQuestion(dataReader.GetInt32("idQuestion"), dataReader.GetInt32("idReponse"), reponse);

                    listReponse.Add(reponse);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                Dictionary<string, int> auto_increment_value = SelectAutoIncrement();

                int _nextID;
                auto_increment_value.TryGetValue("motcle", out _nextID);
                qcmModele.NextIdMotCle = _nextID;
                auto_increment_value.TryGetValue("question", out _nextID);
                qcmModele.NextIdQuestion = _nextID;
                auto_increment_value.TryGetValue("reponse", out _nextID);
                qcmModele.NextIdReponse = _nextID;

                //return list to be displayed
                return qcmModele;
            }
            else
            {
                return null;
            }
        }

        public static Dictionary<int, string> SelectAllQCM()
        {
            string query = "SELECT * FROM qcm";

            //Create a list to store the result
            Dictionary<int, string> listQCMModele = new Dictionary<int, string>();

            //Open connection
            if (OpenConnection() == true)
            {
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
                CloseConnection();

                //return list to be displayed
                return listQCMModele;
            }
            else
            {
                return listQCMModele;
            }
        }

        private static Dictionary<string, int> SelectAutoIncrement()
        {
            string query = "SELECT `TABLE_NAME`, `AUTO_INCREMENT` FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '" + Properties.Settings.Default.DB_Name + "' AND AUTO_INCREMENT IS NOT null";

            //Create a list to store the result
            Dictionary<string, int> dictQCMIncrement = new Dictionary<string, int>();

            //Open connection
            if (OpenConnection() == true)
            {
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
            else
            {
                return dictQCMIncrement;
            }
        }
    }
}