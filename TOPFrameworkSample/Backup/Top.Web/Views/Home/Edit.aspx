<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Top.Web.Models.UserViewData>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Edição de Usuário</title>
    </head>
    <body>
        <%: Html.ValidationSummary() %>
        <% using (Html.BeginForm()){%>
        <%: Html.EditorForModel() %>
        <input type="submit" value="Salvar"/>
        <% } %>
    </body>
</html>
