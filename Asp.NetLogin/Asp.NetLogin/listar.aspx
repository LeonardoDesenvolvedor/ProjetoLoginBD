<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listar.aspx.cs" Inherits="Asp.NetLogin.listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.0/css/all.min.css" />

    <link rel="stylesheet" type="text/css" hreg="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />

    <script src="Scripts/jquery-3.0.0.min.js"></script>

    <script src="https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-12">
        <div class="text-center text-primary">
            <h2>Listagem de Usuários</h2>

        </div>
        <div class="row" style="margin-top: 15px">
            <div class="col-md-12 text-right">
                <asp:Button ID="btnAdicionar" CssClass="btn btn-primary" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
            </div>
        </div>

        <p>
            <asp:Repeater ID="rptUsuarios" runat="server">
                <HeaderTemplate>
                    <table class="table table-hover" id="sisDataTable">
                        <thead>
                            <tr>
                                <td><strong>ID</strong></td>
                                <td><strong>Nome</strong></td>
                                <td><strong>Nível</strong></td>
                                <td><strong>Funções</strong></td>
                            </tr>

                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "id")%>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "nome")%>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "nivel")%>
                        </td>

                        <td>
                            <asp:LinkButton ID="lnkDetalhes" runat="server">
                                <a href='<%# Eval("id", "detalhes.aspx?id={0}") %>'> <span class="fas fa-eye"></span></a>
                            </asp:LinkButton><nb&p>

                            <asp:LinkButton ID="LinEditar" runat="server">
                                <a href='<%# Eval("id", "editar.aspx?id={0}") %>'> <span class="fas fa-pencil-alt"></span></a>
                            </asp:LinkButton><nb&p>

                            <asp:LinkButton ID="LinRemover" runat="server">
                                <a href='<%# Eval("id", "remover.aspx?id={0}") %>'> <span class="fas fa-trash-alt"></span></a>
                            </asp:LinkButton>


                        </td>
                    </tr>

                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
        </p>
    </div>
    <div class="row">
        <div class="col-md=12">
            <asp:Label runat="server" Text="" ID="lblMsg"></asp:Label>
        </div>
    </div>
    <script>
        $('#sisDataTable').dataTable({
            "language": {
                "url": "https://cdn.datatable.net/plug-ins/ 1.10.20/i18n/Portuguese - Brasil.json"
               }

            });

    </script>

</asp:Content>
