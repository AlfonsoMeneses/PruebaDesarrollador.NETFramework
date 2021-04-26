<%@ Page Title="" Language="C#" MasterPageFile="~/Weather/WeatherMaster.Master" AutoEventWireup="true" CodeBehind="NewReport.aspx.cs" Inherits="PruebaDesarrolladorNet.App.Weather.NewReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="card mt-2">

            <div class="card-header bg-light ">
                <label class="h5">Nuevo reporte</label>
            </div>

            <div class="card-body">


                <div class="form-group row mt-2">
                    <label class="col-sm-2 col-form-label">Pais</label>

                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddCountries"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="ddCountries_SelectedIndexChanged"
                            DataTextField="Name"
                            CssClass="form-control" runat="server" />

                    </div>
                </div>

                <div class="form-group row mt-2">
                    <label class="col-sm-2 col-form-label">Departamento</label>

                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddStates"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="ddStates_SelectedIndexChanged"
                            DataTextField="Name"
                            DataValueField="Id"
                            CssClass="form-control" runat="server" />

                    </div>
                </div>

                <div class="form-group row mt-2">
                    <label class="col-sm-2 col-form-label">Ciudad</label>

                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddTown"
                            DataTextField="Name"
                            DataValueField="Id"
                            CssClass="form-control" runat="server" />



                    </div>
                </div>


                <div class="form-group row mt-2">
                    <label for="inputEmail3" class="col-sm-2 col-form-label">Temperatura</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtTemperature" runat="server"
                            CssClass="form-control" placeholder="Temperatura..." />

                    </div>
                </div>

               


                <div class="form-group row mt-2">
                    <label for="inputEmail3" class="col-sm-2 col-form-label">Humedad</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtHumicity" runat="server"
                            CssClass="form-control" placeholder="Humedad..." />

                    </div>
                </div>

                <div class="form-group row mt-2">
                    <label for="inputPassword3" class="col-sm-2 col-form-label">Precipitación</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPrecipitation" runat="server"
                            CssClass="form-control" placeholder="Precipitación..." />
                    </div>
                </div>

                <div class="form-group row mt-2">
                    <label for="inputPassword3" class="col-sm-2 col-form-label">Condiciones</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtConditions" runat="server"
                            CssClass="form-control" placeholder="Condiciones..." />
                    </div>
                </div>

                <div class="form-group row mt-2">
                    <label for="inputPassword3" class="col-sm-2 col-form-label">Fecha del reporte</label>
                    <div class="col-sm-10">
                        <asp:Calendar ID="date" runat="server" CssClass="form-control" />

                    </div>
                </div>

                 <div class="form-group mt-1">
                    <asp:Label ID="inValidDataError"
                        CssClass="alert alert-danger form-control"
                        runat="server" Visible="false" />

                </div>

            </div>

            <div class="card-footer">

                <asp:Button ID="btnNewReport" CssClass="btn btn-outline-primary"
                    Text="Ingresar" runat="server"
                    OnClick="btnNewReport_Click" />

            </div>

        </div>

    </div>

</asp:Content>
