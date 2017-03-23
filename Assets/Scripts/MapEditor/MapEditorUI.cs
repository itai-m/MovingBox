using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {
    public class MapEditorUI : MonoBehaviour {

        public UnityEngine.UI.Text ColText;
        public UnityEngine.UI.Text RowText;
        public UnityEngine.UI.Text WarrningText;

        private const string warrningMsgPre = "The input ";
        private const string warrningMsgAfter = " not enter correctly";

        // Use this for initialization
        void Start() {

        }

        public void StartMapEditor() {
            int colNum = 0, rowNum = 0;
            if (!validteColAndRow(ColText.text, RowText.text, colNum, rowNum)) {
                return;
            }
            GameObject.Find("GameManager").GetComponent<GameManager>().OpenMapEditor();
        }

        public void LoadMapEditor(int index) {

        }

        private bool validteColAndRow(string col, string row, int colNum, int rowNum) {
            if (!validNumber(col, out colNum)) {
                sendValidMsg("Columns");
                return false;
            } else if (!validNumber(row, out rowNum)) {
                sendValidMsg("Rows");
                return false;
            }
            return true;
        }

        private bool validNumber(string strNum, out int number) {
            return int.TryParse(strNum, out number);
        }

        private void sendValidMsg(string msg) {
            sendMsg(warrningMsgPre + msg + warrningMsgAfter);
        }

        private void sendMsg(string msg) {
            WarrningText.text = msg;
        }
    }
}
