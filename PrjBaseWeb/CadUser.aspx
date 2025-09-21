<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadUser.aspx.cs" Inherits="PrjCalculadoraWeb.CadUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:650px; border:solid;">
                <tr>
                    <td style="text-align:center">
                        <h1>
                            <asp:Label ID="lbTitulo" runat="server" 
                                Text="Cadastro de usuários"/></h1>
                    </td>
                   
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>

                <tr>
                    <td>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lbNome" runat="server" Text="Nome" />
                                </td>
                                <td>
                                    <asp:Label ID="lbCPF" runat="server" Text="CPF" />
                                </td>
                                <td>
                                    <asp:Label ID="lbLogin" runat="server" Text="Login" />
                                </td>
                                <td>
                                    <asp:Label ID="lbPerfil" runat="server" Text="Perfil" />
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txBusca" runat="server" Style="width: 50px" />

                                            </td>

                                            <td>
                                                <asp:Button ID="btBusca" runat="server" Text="Busca" Width="50px" OnClick="btBusca_Click" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txNome" runat="server" style="width:150px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txCPF" runat="server"  style="width:100px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txLogin" runat="server"  style="width:100px" />
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                 <asp:RadioButton ID="rbAdm" runat="server" Text="ADM" GroupName="perfil" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbUser" runat="server" Text="USR"  GroupName="perfil"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                                <td>
                                    <asp:Button ID="btOk" runat="server" Text="Insere" Width="70px" OnClick="btOk_Click" />
                                </td>

                            </tr>
                            <tr>
                                <td colspan="5">
                                    <hr />
                                </td>
                            </tr>

                            <tr>
                                <td colspan="5">
                                    <asp:TextBox ID="txRelatorio" 
                                        runat="server" 
                                        ReadOnly="True" 
                                        TextMode="MultiLine" 
                                        Font-Size="Larger" 
                                        Width="650px"
                                        Height="100px"   /> 
                                </td>
                            </tr>

                            <tr>
                                <td colspan="5">
                                    <hr />
                                </td>
                            </tr>

                            <tr>
                                 <td colspan="4" style="text-align:right">
                                    <asp:Button ID="btExcluir" runat="server" Text="Excluir" 
                                        width="70px" OnClick="btExcluir_Click"  />
                                </td>
                                <td colspan="1" style="text-align:right">
                                    <asp:Button ID="btLimpar" runat="server" Text="Limpar" 
                                        width="70px" OnClick="btLimpar_Click"/>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="5">
                                    <asp:Label ID="lbMensagem" runat="server"  style="font-size:x-large" />
                                </td>
                            </tr>

                        </table>
                         
                    </td>
                </tr>
            </table>       
                        
        </div>
    </form>
  
</body>
</html>
