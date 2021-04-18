using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Helpers
{
    class Messages
    {
        public const string RequiredField = "This field is required.";
        public const string RequiredNumber = "Entered value must be a number.";
        public const string SuccessfullyAdded = "Successfully added.";
        public const string SuccessfullyDeleted = "Successfully deleted.";
        public const string SuccessfullyModified = "Data successfully modified.";
        public const string Delete = "Are You sure You want to delete?";
        public const string InvalidUserInput = "The username or password you entered is incorrect.";
        public const string Question = "Question";
        public const string DataNotMatching = "Data is not matching.";

        public static void HandleException(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(
                ex.Message
                + Environment.NewLine
                + ex.InnerException?.Message);
        }
    }
}
