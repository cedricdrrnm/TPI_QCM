using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    class DAO_V2
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
        static public void OpenConnection()
        {
            if (conn == null)
                CreateConnection();
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
        static private void CloseConnection()
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
        
        static public Dictionary<int, QuestionDatas> SelectAllQuestionByIdQCM(int id)
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
                throw new Exception(ex.Message);
            }
        }
        
        static public Dictionary<int, ReponseDatas> SelectAllReponseByIdQuestion(int id)
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
                throw new Exception(ex.Message);
            }
        }
        
        static public Dictionary<int, string> SelectAllMotCleByIdQCM(int id)
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
                throw new Exception(ex.Message);
            }
        }

        public static Dictionary<int, string> SelectAllQCM()
        {
            string query = "SELECT * FROM qcm";

            //Create a list to store the result
            Dictionary<int, string> listQCMModele = new Dictionary<int, string>();

            //Open connection
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static QCMDatas SelectQCMById(int idQCM)
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

                if(qcmModele != null)
                {
                    qcmModele.DictMotCle = SelectAllMotCleByIdQCM(idQCM);
                    qcmModele.DictQuestionModele = SelectAllQuestionByIdQCM(idQCM);
                }
                return qcmModele;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
