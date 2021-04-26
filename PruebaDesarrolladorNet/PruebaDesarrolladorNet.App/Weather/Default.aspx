<%@ Page Title="" Language="C#" MasterPageFile="~/Weather/WeatherMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaDesarrolladorNet.App.Weather.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">

        <div class="card mt-2">
            <div class="card-header bg-info">
              <label class="h3 text-white text-center" >Reportes del clima </label>
            </div>

            <div class="card-body">

                <asp:GridView ID="grdWeatherList" runat="server"
                    DataKeyNames="Id"
                    AllowSorting="True" class="table table-hover text-center"
                    OnRowCommand="grdWeatherList_RowCommand"
                    UseAccessibleHeader="true"
                    AutoGenerateColumns="false">

                    <Columns>

                        <asp:TemplateField>
                            <HeaderTemplate>Ciudad</HeaderTemplate>
                            <ItemTemplate>
                                <%#Eval("Town.Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>Temperatura</HeaderTemplate>
                            <ItemTemplate>
                                <%#Eval("Temperature") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>Condiciones</HeaderTemplate>
                            <ItemTemplate>
                                <%#Eval("Conditions") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>Precipitación</HeaderTemplate>
                            <ItemTemplate>
                                <%#Eval("PrecipitationString") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>Humedad</HeaderTemplate>
                            <ItemTemplate>
                                <%#Eval("HumidityString") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>Fecha</HeaderTemplate>
                            <ItemTemplate>
                                <%#Eval("ReportDateString") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btUpdate"
                                    runat="server"
                                    Text="Editar"
                                    CommandName="onUpdate"
                                    CommandArgument='<%#Eval("Id")%> '>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete"
                                    runat="server"
                                    Text="Eliminar"
                                    CommandName="onDeleted"
                                    OnClientClick='<%# string.Concat("if(!validateDelete(",Eval("Id"),"))return false; ") %>'
                                    CommandArgument='<%#Eval("Id")%> '>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>

            </div>

            <div class="card-body bg-white">
                <asp:Button ID="btnNewReport"
                    Text="Nuevo reporte" runat="server"
                     CssClass="btn btn-outline-info"
                    OnClick="btnNewReport_Click" />
            </div>
        </div>


    </div>

    <script>
        const { Callbacks } = require("jquery");

        function validateDelete(id) {
            var result = confirm("¿Eliminar reporte?");

            return result;
        }
    </script>

</asp:Content>


