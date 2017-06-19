using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    public class MotsClesDatas
    {
        private string _textMotCle;

        private Modes _modeDatabase;

        /// <summary>
        /// Permet de dire si c'est un nouveau mot-clé, si c'est une simple édition ou si c'est déjà dans la base de données
        /// </summary>
        public Modes ModeDatabase
        {
            get
            {
                return _modeDatabase;
            }

            set
            {
                _modeDatabase = value;
            }
        }

        public string TextMotCle
        {
            get
            {
                return _textMotCle;
            }

            set
            {
                _textMotCle = value;
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="textMotCle">Texte du mot-clé</param>
        /// <param name="modeDatabase">Mode dans la base de données</param>
        public MotsClesDatas(string textMotCle, Modes modeDatabase)
        {
            TextMotCle = textMotCle;
            ModeDatabase = modeDatabase;
        }
    }
}
