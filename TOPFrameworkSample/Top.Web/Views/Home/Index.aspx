<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<List<Top.Web.Models.UserListViewDataItem>>" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Listagem de Usuário</title>
    </head>
    <body>      
        <%: Html.Grid(Model).AutoGenerateColumns()
                .Columns(col =>
                     {
                         col.For(user => Html.ActionLink("Visualizar", "Detail", new {id = user.Id})).Named("");
                         col.For(user => Html.ActionLink("Editar", "Edit", new {id = user.Id})).Named("");
                         col.For(user => Html.ActionLink("Remover", "Remove", new {id = user.Id})).Named("");
                     }) %>

    </body>
</html>
