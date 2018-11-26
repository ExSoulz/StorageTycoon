using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibs.GameController
{
    class GameManager
    {
        private static GameManager instance;

        private GameManager()
        {

        }

        public static GameManager GetInstance()
        {
            if (instance == null)
            {
                return instance = new GameManager();
            }
        }
    }
}
