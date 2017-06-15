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

        Modes _modeDatabase;

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

        public MotsClesDatas(string textMotCle, Modes modeDatabase)
        {
            TextMotCle = textMotCle;
            ModeDatabase = modeDatabase;
        }
    }
}
