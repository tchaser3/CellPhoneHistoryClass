/* Title:           Cell Phone History Class
 * Date:            4-18-19
 * Author:          Terry Holmes
 * 
 * Description:     This is the class for Cell Phone History */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace CellPhoneHistoryDLL
{
    public class CellPhoneHistoryClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        CellPhoneHistoryDataSet aCellPhoneHistoryDataSet;
        CellPhoneHistoryDataSetTableAdapters.cellphonehistoryTableAdapter aCellPhoneHistoryTableAdapter;

        InsertCellPhoneHistoryEntryTableAdapters.QueriesTableAdapter aInsertCellPhoneHistoryTableAdapter;

        public bool InsertCellPhoneHistory(int intEmployeeID, int intPhoneID, string strEntryNotes)
        {
            bool blnFatalError = false;

            try
            {
                aInsertCellPhoneHistoryTableAdapter = new InsertCellPhoneHistoryEntryTableAdapters.QueriesTableAdapter();
                aInsertCellPhoneHistoryTableAdapter.InsertCellPhoneHistory(DateTime.Now, intEmployeeID, intPhoneID, strEntryNotes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Cell Phone History Class // Insert Cell Phone History " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public CellPhoneHistoryDataSet GetCellPhoneHistoryInfo()
        {
            try
            {
                aCellPhoneHistoryDataSet = new CellPhoneHistoryDataSet();
                aCellPhoneHistoryTableAdapter = new CellPhoneHistoryDataSetTableAdapters.cellphonehistoryTableAdapter();
                aCellPhoneHistoryTableAdapter.Fill(aCellPhoneHistoryDataSet.cellphonehistory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Cell Phone History Class // Get Cell Phone History Info " + Ex.Message);
            }

            return aCellPhoneHistoryDataSet;
        }
        public void UpdateCellPhoneHistoryDB(CellPhoneHistoryDataSet aCellPhoneHistoryDataSet)
        {
            try
            {
                aCellPhoneHistoryTableAdapter = new CellPhoneHistoryDataSetTableAdapters.cellphonehistoryTableAdapter();
                aCellPhoneHistoryTableAdapter.Update(aCellPhoneHistoryDataSet.cellphonehistory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Cell Phone History Class // Update Cell Phone History DB " + Ex.Message);
            }
        }
    }
}
