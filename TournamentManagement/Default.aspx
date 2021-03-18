<%@ Page Language="C#" Inherits="TournamentManagement.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">
        <div>
            <h1>Tournament</h1>
                <table>
                    <asp:Button ID="Button1" runat="server" Text="Click Me" OnClick="Button1_Click" />  
                        <tbody>
                               <%foreach(var p in Player)
                            {%>
                            <tr>
                              <td>
                                  <%=p.Id%>  
                               </td>
                               <td>
                                   <%=p.Name%>  
                               </td> 
                               <td>
                                  <%=p.Surname%>  
                              </td> 
                            </tr>
                            <%} %>
                        </tbody>
                </table>
            </div>
    </form>
</body>
</html>