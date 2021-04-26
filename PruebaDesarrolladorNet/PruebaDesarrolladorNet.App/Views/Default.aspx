<%@ Page Title="" Language="C#" MasterPageFile="AppMasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaDesarrolladorNet.App.Index" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView ID="grdWeatherList" runat="server"
        DataKeyNames="Id"
        AllowSorting="True" EditRowStyle-HorizontalAlign="Right"
        CellPadding="4" EnableModelValidation="True"
        OnRowCommand="grdWeatherList_RowCommand"
        AutoGenerateColumns="false"
        ForeColor="#333333" GridLines="None">

        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle HorizontalAlign="Right" BackColor="#2461BF"></EditRowStyle>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

        <Columns>

            <asp:TemplateField>
                <HeaderTemplate>Codigo</HeaderTemplate>
                <ItemTemplate>
                    <%#Eval("Code") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>Codigo</HeaderTemplate>
                <ItemTemplate>
                    <%#Eval("Name") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" 
                                runat="server" 
                                Text="Eliminar" 
                                CommandName="onDeleted"
                                CommandArgument='<%#Eval("Id")%> '>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkproductname"
                        runat="server"
                        CommandArgument='<%#Eval("Id")%> '
                        Text='<%#Eval("Name") %>'
                        CommandName="selectproduct">

                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>
