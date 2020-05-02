using System;
using Microsoft.SharePoint.Client;

namespace TestApplication
{
    class TestGetListItems
    {
        static void Main()
        {
            string siteUrl = "http://spsite/sites/sitecollname"; 

            ClientContext clientContext = new ClientContext(siteUrl);
            
	        List oList = clientContext.Web.Lists.GetByTitle("TestList");

            CamlQuery camlQuery = new CamlQuery();
            
            //Following query will fetch items from list having ID greater than 5 with row limit 10. 
	        camlQuery.ViewXml = "<View><Query><Where><Geq><FieldRef Name='ID'/><Value Type='Number'>5</Value></Geq></Where></Query><RowLimit>10</RowLimit></View>";
            
            ListItemCollection collListItem = oList.GetItems(camlQuery);

            clientContext.Load(collListItem);

            clientContext.ExecuteQuery();

            foreach (ListItem oListItem in collListItem)
            {
                Console.WriteLine("ID:" + oListItem.Id + " Title: " oListItem["Title"]);
            }
	    }
    }
}