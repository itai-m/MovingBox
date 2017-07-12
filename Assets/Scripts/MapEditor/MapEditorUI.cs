using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Completed {
    public class MapEditorUI : MonoBehaviour {

        public Text ColText;
        public Text RowText;
        public Text WarrningText;

        private const string warrningMsgPre = "The input ";
        private const string warrningMsgAfter = " not enter correctly";

        // Use this for initialization
        void Start() {

        }

        public void StartMapEditor() {
            int colNum = 0, rowNum = 0;
            if (!validteColAndRow(ColText.text, RowText.text, out colNum, out rowNum)) {
                return;
            }
            RefManager.Instance.mapEditorCol = colNum;
            RefManager.Instance.mapEditorRow = rowNum;
            RefManager.Instance.mapEditorName = "";
            UIManager.Instance.LoadMapEditor();
        }

        

        private bool validteColAndRow(string col, string row, out int colNum, out int rowNum) {
            rowNum = 0;
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
