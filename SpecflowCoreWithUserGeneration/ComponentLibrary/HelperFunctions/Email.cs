using System;
using Microsoft.Office.Interop.Outlook;

namespace ComponentLibrary.HelperFunctions
{
    public class Email
    {

        public static string GetEmailLink()
        {
            Application outlookApplication = new Application();
            NameSpace outlookNamespace = outlookApplication.GetNamespace("MAPI");
            MAPIFolder inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);

            Microsoft.Office.Interop.Outlook.MailItem item = (Microsoft.Office.Interop.Outlook.MailItem)inboxFolder.Items[1];
            Console.WriteLine("Num Items: {0}", item.Body);
            string emaiLink = "";

            for (int i = 1; i < inboxFolder.Items.Count; i++)
            {
                if (inboxFolder.Items[i] is MailItem) 
                {
                    Microsoft.Office.Interop.Outlook.MailItem item1 = (Microsoft.Office.Interop.Outlook.MailItem)inboxFolder.Items[i];
                    if (item1.Subject != null)
                    {
                        if (item1.Subject.Contains("Calastone password reset request") && item1.UnRead) 
                        {
                            Console.WriteLine(item1.Subject);
                            Console.WriteLine("body contains dmiqa4: " + item1.Body.Contains("dmi"));
                            Console.WriteLine(item1.HTMLBody);
                            Console.WriteLine(item1.ReceivedTime);
                            int pFrom = item1.HTMLBody.IndexOf("click the following link:<a href=") + "click the following link:<a href=".Length + 1;
                            int pTo = item1.HTMLBody.LastIndexOf(">here</a> to complete the process") - 1;

                            string htmlLink = item1.HTMLBody.Substring(pFrom, pTo - pFrom);
                            string clickableLink = htmlLink.Replace("amp;", "");
                            Console.WriteLine("pFrom " + pFrom);
                            Console.WriteLine("pTo " + pTo);
                            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" + clickableLink + "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

                            //emaiLink =  item1.HTMLBody.Substring(pFrom, pTo - pFrom);
                            emaiLink = clickableLink;
                        }
                    }
                }
            }
            return emaiLink;
        }


    }
}
