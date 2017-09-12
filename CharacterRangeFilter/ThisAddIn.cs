using Outlook = Microsoft.Office.Interop.Outlook;

namespace CharacterRangeFilter
{
    public partial class ThisAddIn
    {
        Outlook.NameSpace outlookNameSpace;
        Outlook.MAPIFolder inbox;
        Outlook.Items items;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            outlookNameSpace = this.Application.GetNamespace("MAPI");
            inbox = outlookNameSpace.GetDefaultFolder(
                    Microsoft.Office.Interop.Outlook.
                    OlDefaultFolders.olFolderInbox);

            items = inbox.Items;
            items.ItemAdd +=
                new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);
        }

        void items_ItemAdd(object Item)
        {
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            if (Item != null)
            {
                if (mail.MessageClass == "IPM.Note")
                {
                    if (HasChineseCharacters2More(mail) == true)
                    {
                        mail.Move(outlookNameSpace.GetDefaultFolder(
                            Microsoft.Office.Interop.Outlook.
                            OlDefaultFolders.olFolderJunk));
                    }
                }
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        bool HasChineseCharacters2More(Outlook.MailItem mail)
        {
            if (string.IsNullOrEmpty(mail.Subject) == true)
            {
                return false;
            }

            string title = mail.Subject;
            int count = 0;

            // https://ko.wikipedia.org/wiki/%EC%9C%A0%EB%8B%88%EC%BD%94%EB%93%9C_%EB%B8%94%EB%A1%9D
            foreach (char ch in title)
            {
                switch (ch)
                {
                    case char i when i >= 0x2e80 && i <= 0x2eff: // CJK Radicals Supplement
                        count++;
                        break;

                    case char i when i >= 0x2f00 && i <= 0x2fdf: // Kangxi Radicals
                        count++;
                        break;

                    case char i when i >= 0x3000 && i <= 0x303f: // CJK Symbols and Punctuation
                        count++;
                        break;

                    case char i when i >= 0x3400 && i <= 0x4dbf: // CJK Unified Ideographs Extension A
                        count++;
                        break;

                    case char i when i >= 0x4e00 && i <= 0x9fff: // CJK Unified Ideographs
                        count++;
                        break;

                        // for now, except for 2 SIP area
                        /*
                        2 SIP U+20000..U+2A6DF CJK Unified Ideographs Extension B
                        2 SIP U+2A700..U+2B73F CJK Unified Ideographs Extension C
                        2 SIP U+2B740..U+2B81F CJK Unified Ideographs Extension D
                        2 SIP U+2B820..U+2CEAF CJK Unified Ideographs Extension E
                        2 SIP U+2CEB0..U+2EBEF CJK Unified Ideographs Extension F
                        2 SIP U+2F800..U+2FA1F CJK Compatibility Ideographs Supplement
                        */
                }
            }

            return count > 1;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
