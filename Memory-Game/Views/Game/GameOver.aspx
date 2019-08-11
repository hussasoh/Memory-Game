<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameOver.aspx.cs" Inherits="Memory_Game.Views.Game.GameOver" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:ListView ID="ListView1" runat="server" DataSourceID="ScoresDataSource">
			</asp:ListView>
			<asp:ListView ID="ListView2" runat="server" DataSourceID="ScoresDataSourceUser">
			</asp:ListView>
			<asp:SqlDataSource ID="ScoresDataSourceUser" runat="server" ConnectionString="<%$ ConnectionStrings:MemoryGameDBConnectionString %>" SelectCommand="SELECT [score], [gameMode], [difficulty] FROM [Scores] WHERE ([userID] = @userID) ORDER BY [score]">
				<SelectParameters>
					<asp:Parameter DefaultValue="1" Name="userID" Type="Int32" />
				</SelectParameters>
			</asp:SqlDataSource>
			<asp:SqlDataSource ID="ScoresDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MemoryGameDBConnectionString %>" SelectCommand="SELECT [score], [userID], [gameMode], [difficulty] FROM [Scores] WHERE (([gameMode] = @gameMode) AND ([difficulty] = @difficulty)) ORDER BY [score]">
				<SelectParameters>
					<asp:Parameter DefaultValue="Numbers" Name="gameMode" Type="String" />
					<asp:Parameter DefaultValue="Normal" Name="difficulty" Type="String" />
				</SelectParameters>
			</asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
