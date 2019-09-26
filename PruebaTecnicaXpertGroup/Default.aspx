<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaTecnicaXpertGroup.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Consulta</td>
                    <td>Resultado Query</td>
                </tr>
                <tr>
                    <td><asp:TextBox Height="200px" ID="consulta" TextMode="MultiLine" runat="server" Width="400px" Wrap="true"></asp:TextBox></td>
                    <td><asp:TextBox Height="200px" ID="resultado" TextMode="MultiLine" ReadOnly="true" runat="server" Width="400px" Wrap="true"></asp:TextBox></td>
                </tr>
            </table>
            <asp:Button Height="40px" ID="botonEvaluar" Text="Evaluar" runat="server" Width="100px" OnClick="botonEvaluar_Click" />
        </div>
        <div>
            <table>
                <tr>
                    <td>Ejemplo 1</td>
                    <td>Ejemplo 2</td>
                </tr>
                <tr>
                    <td style="width: 150px;">
                        <div>
                            4 5 <br />
                            UPDATE 2 2 2 4 <br />
                            QUERY 1 1 1 3 3 3 <br />
                            UPDATE 1 1 1 23 <br />
                            QUERY 2 2 2 4 4 4 <br />
                            QUERY 1 1 1 3 3 3
                        </div>
                    </td>
                    <td>
                        <div><p>
                            2 4 <br />
                            UPDATE 2 2 2 1 <br />
                            QUERY 1 1 1 1 1 1 <br />
                            QUERY 1 1 1 2 2 2 <br />
                            QUERY 2 2 2 2 2 2
                        </p></div></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
